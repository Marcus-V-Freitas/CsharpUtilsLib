namespace CsharpUtilsLib.SQL.MySql;

public class MySqlHelper : BaseSqlHelper
{
    public MySqlHelper(string connectionString) : base(connectionString)
    {
        _compiler = new MySqlCompiler();
    }

    protected override DbCommand ConfigureCommand(Query query, DbConnection connection)
    {
        SqlResult compiledSql = _compiler.Compile(query);
        MySqlCommand command = new MySqlCommand(compiledSql.Sql, (MySqlConnection)connection)
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
        MySqlConnection conn = new MySqlConnection(ConnectionString);
        conn.Open();
        return conn;
    }

    protected override async Task<DbConnection> ConfigureConnectionAsync(CancellationToken token)
    {
        MySqlConnection conn = new MySqlConnection(ConnectionString);
        await conn.OpenAsync(token);
        return conn;
    }
}
