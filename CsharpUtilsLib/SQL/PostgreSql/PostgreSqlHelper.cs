namespace CsharpUtilsLib.SQL.PostgreSql;

public class PostgreHelper : BaseSqlHelper
{
    public PostgreHelper(string connectionString) : base(connectionString)
    {
        _compiler = new PostgresCompiler();
    }

    protected override DbCommand ConfigureCommand(Query query, DbConnection connection)
    {
        SqlResult compiledSql = _compiler.Compile(query);
        NpgsqlCommand command = new NpgsqlCommand(compiledSql.Sql, (NpgsqlConnection)connection)
        {
            CommandTimeout = Timeout
        };

        foreach (string paramName in compiledSql.NamedBindings.Keys)
        {
            command.Parameters.AddWithValue(paramName, compiledSql.NamedBindings[paramName]);
        }

        return command;
    }

    protected override DbConnection ConfigureConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(ConnectionString);
        conn.Open();
        return conn;
    }

    protected override async Task<DbConnection> ConfigureConnectionAsync(CancellationToken token)
    {
        NpgsqlConnection conn = new NpgsqlConnection(ConnectionString);
        await conn.OpenAsync(token);
        return conn;
    }
}
