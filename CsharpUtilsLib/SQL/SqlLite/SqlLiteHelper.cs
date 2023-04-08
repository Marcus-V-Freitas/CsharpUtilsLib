namespace CsharpUtilsLib.SQL.SqlLite;

public class SqlLiteHelper : BaseSqlHelper
{
    public SqlLiteHelper(string connectionString) : base(connectionString)
    {
        _compiler = new SqliteCompiler();
    }

    protected override DbCommand ConfigureCommand(Query query, DbConnection connection)
    {
        SqlResult compiledSql = _compiler.Compile(query);
        SQLiteCommand command = new SQLiteCommand(compiledSql.Sql, (SQLiteConnection)connection)
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
        SQLiteConnection conn = new SQLiteConnection(ConnectionString);
        conn.Open();
        return conn;
    }

    protected override async Task<DbConnection> ConfigureConnectionAsync(CancellationToken token)
    {
        SQLiteConnection conn = new SQLiteConnection(ConnectionString);
        await conn.OpenAsync(token);
        return conn;
    }
}
