namespace CsharpUtilsLib.SQL;

public interface ISqlHelper
{
    long? InsertWithId(Query query, List<KeyValuePair<string, object>> parameters);

    Task<long?> InsertWithIdAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default);

    int Insert(Query query, List<KeyValuePair<string, object>> parameters);

    Task<int> InsertAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default);

    int Update(Query query, List<KeyValuePair<string, object>> parameters);

    Task<int> UpdateAsync(Query query, List<KeyValuePair<string, object>> parameters, CancellationToken token = default);

    int Delete(Query query);

    Task<int> DeleteAsync(Query query, CancellationToken token = default);

    bool Exists(Query query);

    Task<bool> ExistsAsync(Query query, CancellationToken token = default);

    T SelectOne<T>(Query query);

    Task<T> SelectOneAsync<T>(Query query, CancellationToken token = default);

    IEnumerable<T> Select<T>(Query query);

    Task<IEnumerable<T>> SelectAsync<T>(Query query, CancellationToken token = default);

    Task<int> ExecuteNonQueryAsync(Query query, CancellationToken token = default);

    int ExecuteNonQuery(Query query);

    Task<T> ExecuteScalarAsync<T>(Query query, T defaultValue = default!, CancellationToken token = default);

    T ExecuteScalar<T>(Query query, T defaultValue = default!);

    IAsyncEnumerable<DbDataReader> ExecuteReaderAsync(Query query, CancellationToken token = default);

    IEnumerable<DbDataReader> ExecuteReader(Query query);
}