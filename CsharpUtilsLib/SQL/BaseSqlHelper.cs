namespace CsharpUtilsLib.SQL;

public abstract class BaseSqlHelper : ISqlHelper
{
    protected Compiler _compiler;
    protected readonly List<string> _readMethods = new() { "select", "aggregate" };
    protected readonly DbConnectionStringBuilder _readConnectionBuilder;
    protected readonly DbConnectionStringBuilder _writeConnectionBuilder;
    public int Timeout { get; set; } = 300;
    public string ReadConnectionString => _readConnectionBuilder?.ConnectionString!;
    public string WriteConnectionString => _writeConnectionBuilder?.ConnectionString!;

    protected BaseSqlHelper(string connectionString)
    {
        _compiler = DefineDatabaseCompiler();
        _writeConnectionBuilder = CreateConnectionBuilder(connectionString);
        _readConnectionBuilder = CreateConnectionBuilder(connectionString);
    }

    protected BaseSqlHelper(string writeConnectionString, string readConnectionString)
    {
        _compiler = DefineDatabaseCompiler();
        _writeConnectionBuilder = CreateConnectionBuilder(writeConnectionString);
        _readConnectionBuilder = CreateConnectionBuilder(readConnectionString);
    }

    public long? InsertWithId(Query query, List<KeyValuePair<string, object>> parameters)
    {
        if (parameters.ListIsNullOrEmpty())
        {
            return 0;
        }

        return ExecuteScalar<long?>(query.AsInsert(parameters, true));
    }

    public async Task<long?> InsertWithIdAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default)
    {
        if (parameters.ListIsNullOrEmpty())
        {
            return 0;
        }

        return await ExecuteScalarAsync<long?>(query.AsInsert(parameters, true), token: token);
    }

    public int Insert(Query query, List<KeyValuePair<string, object>> parameters)
    {
        if (parameters.ListIsNullOrEmpty())
        {
            return 0;
        }

        return ExecuteNonQuery(query.AsInsert(parameters));
    }

    public async Task<int> InsertAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default)
    {
        if (parameters.ListIsNullOrEmpty())
        {
            return 0;
        }

        return await ExecuteNonQueryAsync(query.AsInsert(parameters), token);
    }

    public int Update(Query query, List<KeyValuePair<string, object>> parameters)
    {
        if (parameters.ListIsNullOrEmpty())
        {
            return 0;
        }

        return ExecuteNonQuery(query.AsUpdate(parameters));
    }

    public async Task<int> UpdateAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default)
    {
        if (parameters.ListIsNullOrEmpty())
        {
            return 0;
        }

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
        using DbConnection conn = ConfigureConnection(query);
        using QueryFactory factory = new QueryFactory(conn, _compiler);

        if (!CheckIfTypeIsComplex(query))
        {
            return factory.FirstOrDefault<T>(query, timeout: Timeout);
        }

        query = ConvertQueryToXQuery(factory, query);
        dynamic entity = factory.FirstOrDefault<dynamic>(query, timeout: Timeout);
        return ConvertDynamicToEntity<T>(entity);
    }

    public async Task<T> SelectOneAsync<T>(Query query, CancellationToken token = default)
    {
        using DbConnection conn = await ConfigureConnectionAsync(query, token);
        using QueryFactory factory = new QueryFactory(conn, _compiler);

        if (!CheckIfTypeIsComplex(query))
        {
            return await factory.FirstOrDefaultAsync<T>(query, timeout: Timeout, cancellationToken: token);
        }

        query = ConvertQueryToXQuery(factory, query);
        dynamic entity = await factory.FirstOrDefaultAsync<dynamic>(query, timeout: Timeout, cancellationToken: token);
        return ConvertDynamicToEntity<T>(entity);
    }

    public IEnumerable<T> Select<T>(Query query)
    {
        using DbConnection conn = ConfigureConnection(query);
        using QueryFactory factory = new QueryFactory(conn, _compiler);

        if (!CheckIfTypeIsComplex(query))
        {
            return factory.Get<T>(query, timeout: Timeout);
        }

        query = ConvertQueryToXQuery(factory, query);
        IEnumerable<dynamic> entities = factory.Get<dynamic>(query, timeout: Timeout);
        return ConvertDynamicToEntity<IEnumerable<T>>(entities);
    }

    public async Task<IEnumerable<T>> SelectAsync<T>(Query query, CancellationToken token = default)
    {
        using DbConnection conn = await ConfigureConnectionAsync(query, token);
        using QueryFactory factory = new QueryFactory(conn, _compiler);

        if (!CheckIfTypeIsComplex(query))
        {
            return await factory.GetAsync<T>(query, timeout: Timeout, cancellationToken: token);
        }

        query = ConvertQueryToXQuery(factory, query);
        IEnumerable<dynamic> entities = await factory.GetAsync<dynamic>(query, timeout: Timeout, cancellationToken: token);
        return ConvertDynamicToEntity<IEnumerable<T>>(entities);
    }

    public async Task<int> ExecuteNonQueryAsync(Query query, CancellationToken token = default)
    {
        using DbConnection conn = await ConfigureConnectionAsync(query, token);
        using DbCommand command = ConfigureCommand(query, conn);

        return await command.ExecuteNonQueryAsync(token);
    }

    public int ExecuteNonQuery(Query query)
    {
        using DbConnection conn = ConfigureConnection(query);
        using DbCommand command = ConfigureCommand(query, conn);

        return command.ExecuteNonQuery();
    }

    public async Task<T> ExecuteScalarAsync<T>(Query query, T defaultValue = default!, CancellationToken token = default)
    {
        using DbConnection conn = await ConfigureConnectionAsync(query, token);
        using DbCommand command = ConfigureCommand(query, conn);

        object result = (await command.ExecuteScalarAsync(token))!;

        return result.ConvertTo<T, object>(defaultValue);
    }

    public T ExecuteScalar<T>(Query query, T defaultValue = default!)
    {
        using DbConnection conn = ConfigureConnection(query);
        using DbCommand command = ConfigureCommand(query, conn);

        object result = command.ExecuteScalar()!;

        return result.ConvertTo<T, object>(defaultValue);
    }

    public async IAsyncEnumerable<DbDataReader> ExecuteReaderAsync(Query query, [EnumeratorCancellation] CancellationToken token = default)
    {
        using DbConnection conn = await ConfigureConnectionAsync(query, token);
        using DbCommand command = ConfigureCommand(query, conn);
        using DbDataReader cursor = await command.ExecuteReaderAsync(token);

        while (await cursor.ReadAsync(token))
        {
            yield return cursor;
        }
    }

    public IEnumerable<DbDataReader> ExecuteReader(Query query)
    {
        using DbConnection conn = ConfigureConnection(query);
        using DbCommand command = ConfigureCommand(query, conn);
        using DbDataReader cursor = command.ExecuteReader();

        while (cursor.Read())
        {
            yield return cursor;
        }
    }

    protected abstract Compiler DefineDatabaseCompiler();

    protected abstract DbConnection DetermineConnectionString(Query query);

    protected abstract DbConnectionStringBuilder CreateConnectionBuilder(string connectionString);

    protected abstract DbCommand ConfigureCommand(Query query, DbConnection connection);

    protected virtual DbConnection ConfigureConnection(Query query)
    {
        DbConnection conn = DetermineConnectionString(query);
        conn.Open();
        return conn;
    }

    protected virtual async Task<DbConnection> ConfigureConnectionAsync(Query query, CancellationToken token)
    {
        DbConnection conn = DetermineConnectionString(query);
        await conn.OpenAsync(token);
        return conn;
    }

    protected virtual bool ReadConnectionIsAvailable(Query query) => Transaction.Current == null && _readMethods.Contains(query.Method);

    protected virtual Query ConvertQueryToXQuery(QueryFactory factory, Query query)
    {
        query = factory.FromQuery(query);

        if (query.Includes.ListIsNullOrEmpty())
        {
            return query;
        }

        foreach (int index in Enumerable.Range(0, query.Includes.Count))
        {
            query.Includes[index].Query = ConvertQueryToXQuery(factory, query.Includes[index].Query);
        }

        return query;
    }

    protected virtual T ConvertDynamicToEntity<T>(object entity)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Newtonsoft.Json.JsonConvert.SerializeObject(entity))!;
    }

    protected virtual bool CheckIfTypeIsComplex(Query query)
    {
        if (query.Includes.ListIsNullOrEmpty())
        {
            return false;
        }

        foreach (Include include in query.Includes)
        {
            if (CheckIfTypeIsComplex(include.Query))
            {
                return true;
            }
        }

        return true;
    }
}