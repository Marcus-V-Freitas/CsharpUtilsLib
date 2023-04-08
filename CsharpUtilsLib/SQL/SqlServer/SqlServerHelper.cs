namespace CsharpUtilsLib.SQL.SqlServer;

public class SqlServerHelper : BaseSqlHelper
{
    public SqlServerHelper(string connectionString) : base(connectionString)
    {
        _compiler = new SqlServerCompiler();
    }

    protected override DbCommand ConfigureCommand(Query query, DbConnection connection)
    {
        SqlResult compiledSql = _compiler.Compile(query);
        SqlCommand command = new SqlCommand(compiledSql.Sql, (SqlConnection)connection)
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
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        return conn;
    }

    protected override async Task<DbConnection> ConfigureConnectionAsync(CancellationToken token)
    {
        DbConnection conn = new SqlConnection(ConnectionString);
        await conn.OpenAsync(token);
        return conn;
    }
}
