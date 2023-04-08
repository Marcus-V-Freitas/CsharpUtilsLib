namespace CsharpUtilsLib.SQL;

public abstract class BaseSqlHelper
{
    protected Compiler _compiler;
    public readonly string ConnectionString;
    public int Timeout = 300;

    public BaseSqlHelper(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public long? InsertWithId(Query query, List<KeyValuePair<string, object>> parameters)
    {
        return ExecuteScalar<long?>(query.AsInsert(parameters, true));
    }

    public async Task<long?> InsertWithIdAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default)
    {
        return await ExecuteScalarAsync<long?>(query.AsInsert(parameters, true), token: token);
    }

    public int Insert(Query query, List<KeyValuePair<string, object>> parameters)
    {
        return ExecuteNonQuery(query.AsInsert(parameters));
    }

    public async Task<int> InsertAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default)
    {
        return await ExecuteNonQueryAsync(query.AsInsert(parameters), token);
    }

    public int Update(Query query, List<KeyValuePair<string, object>> parameters)
    {
        return ExecuteNonQuery(query.AsUpdate(parameters));
    }

    public async Task<int> UpdateAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default)
    {
        return await ExecuteNonQueryAsync(query.AsUpdate(parameters), token);
    }

    public int Delete(Query query)
    {
        return ExecuteNonQuery(query.AsDelete());
    }

    public async Task<int> DeleteAsync(Query query, CancellationToken token = default)
    {
        return await ExecuteNonQueryAsync(query.AsDelete(), token);
    }

    public bool Exists(Query query)
    {
        foreach (DbDataReader _ in ExecuteReader(query))
        {
            return true;
        }

        return false;
    }

    public async Task<bool> ExistsAsync(Query query, CancellationToken token = default)
    {
        await foreach (DbDataReader _ in ExecuteReaderAsync(query, token))
        {
            return true;
        }

        return false;
    }

    public T SelectOne<T>(Query query)
    {
        using QueryFactory factory = new QueryFactory(ConfigureConnection(), _compiler);

        return factory.FirstOrDefault<T>(query, timeout: Timeout);
    }

    public async Task<T> SelectOneAsync<T>(Query query, CancellationToken token = default)
    {
        using QueryFactory factory = new QueryFactory(await ConfigureConnectionAsync(token), _compiler);

        return await factory.FirstOrDefaultAsync<T>(query, timeout: Timeout, cancellationToken: token);
    }

    public IEnumerable<T> Select<T>(Query query)
    {
        using QueryFactory factory = new QueryFactory(ConfigureConnection(), _compiler);

        return factory.Get<T>(query, timeout: Timeout);
    }

    public async Task<IEnumerable<T>> SelectAsync<T>(Query query, CancellationToken token = default)
    {
        using QueryFactory factory = new QueryFactory(await ConfigureConnectionAsync(token), _compiler);

        return await factory.GetAsync<T>(query, timeout: Timeout, cancellationToken: token);
    }

    public async Task<int> ExecuteNonQueryAsync(Query query, CancellationToken token = default)
    {
        using DbConnection conn = await ConfigureConnectionAsync(token);
        using DbCommand command = ConfigureCommand(query, conn);

        return await command.ExecuteNonQueryAsync(token);
    }

    public int ExecuteNonQuery(Query query)
    {
        using DbConnection conn = ConfigureConnection();
        using DbCommand command = ConfigureCommand(query, conn);

        return command.ExecuteNonQuery();
    }

    public async Task<T> ExecuteScalarAsync<T>(Query query, T defaultValue = default!, CancellationToken token = default)
    {
        using DbConnection conn = await ConfigureConnectionAsync(token);
        using DbCommand command = ConfigureCommand(query, conn);

        object result = (await command.ExecuteScalarAsync(token))!;

        return SecureNullableReturnScalarValue(result, defaultValue);
    }

    public T ExecuteScalar<T>(Query query, T defaultValue = default!)
    {
        using DbConnection conn = ConfigureConnection();
        using DbCommand command = ConfigureCommand(query, conn);

        object result = command.ExecuteScalar()!;

        return SecureNullableReturnScalarValue(result, defaultValue);
    }

    public async IAsyncEnumerable<DbDataReader> ExecuteReaderAsync(Query query, [EnumeratorCancellation] CancellationToken token)
    {
        using DbConnection conn = await ConfigureConnectionAsync(token);
        using DbCommand command = ConfigureCommand(query, conn);
        using DbDataReader cursor = await command.ExecuteReaderAsync(token);

        while (await cursor.ReadAsync(token))
        {
            yield return cursor;
        }
    }

    public IEnumerable<DbDataReader> ExecuteReader(Query query)
    {
        using DbConnection conn = ConfigureConnection();
        using DbCommand command = ConfigureCommand(query, conn);
        using DbDataReader cursor = command.ExecuteReader();

        while (cursor.Read())
        {
            yield return cursor;
        }
    }

    protected static T SecureNullableReturnScalarValue<T>(object result, T defaultValue)
    {
        if (result == null || DBNull.Value.Equals(result))
        {
            return defaultValue;
        }

        Type type = typeof(T);
        return (T)Convert.ChangeType(result, Nullable.GetUnderlyingType(type) ?? type);
    }

    protected abstract DbConnection ConfigureConnection();

    protected abstract Task<DbConnection> ConfigureConnectionAsync(CancellationToken token);

    protected abstract DbCommand ConfigureCommand(Query query, DbConnection connection);
}
