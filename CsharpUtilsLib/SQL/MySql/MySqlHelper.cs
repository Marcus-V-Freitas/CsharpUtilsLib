namespace CsharpUtilsLib.SQL.MySql;

public class MySqlHelper : BaseSqlHelper
{
    public MySqlHelper(string connectionString) : base(connectionString)
    {
    }

    public MySqlHelper(string writeConnectionString, string readConnectionString) : base(writeConnectionString, readConnectionString)
    {

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

    protected override DbConnectionStringBuilder CreateConnectionBuilder(string connectionString) => new MySqlConnectionStringBuilder(connectionString);

    protected override Compiler DefineDatabaseCompiler() => new MySqlCompiler();

    protected override DbConnection DetermineConnectionString(Query query)
    {
        if (ReadConnectionIsAvailable(query))
        {
            return new MySqlConnection(_readConnectionBuilder.ConnectionString);
        }

        return new MySqlConnection(_writeConnectionBuilder.ConnectionString);
    }
}