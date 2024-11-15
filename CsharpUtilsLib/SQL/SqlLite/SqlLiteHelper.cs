namespace CsharpUtilsLib.SQL.SqlLite;

public class SqlLiteHelper : BaseSqlHelper
{
    public SqlLiteHelper(string connectionString) : base(connectionString)
    {
    }

    public SqlLiteHelper(string writeConnectionString, string readConnectionString) : base(writeConnectionString, readConnectionString)
    {

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

    protected override DbConnectionStringBuilder CreateConnectionBuilder(string connectionString) => new SQLiteConnectionStringBuilder(connectionString);

    protected override Compiler DefineDatabaseCompiler() => new SqliteCompiler();

    protected override DbConnection DetermineConnectionString(Query query)
    {
        if (ReadConnectionIsAvailable(query))
        {
            return new SQLiteConnection(_readConnectionBuilder.ConnectionString);
        }

        return new SQLiteConnection(_writeConnectionBuilder.ConnectionString);
    }
}