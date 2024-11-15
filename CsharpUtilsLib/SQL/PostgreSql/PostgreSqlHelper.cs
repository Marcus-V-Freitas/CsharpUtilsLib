namespace CsharpUtilsLib.SQL.PostgreSql;

public class PostgreHelper : BaseSqlHelper
{
    public PostgreHelper(string connectionString) : base(connectionString)
    {
    }

    public PostgreHelper(string writeConnectionString, string readConnectionString) : base(writeConnectionString, readConnectionString)
    {

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

    protected override DbConnectionStringBuilder CreateConnectionBuilder(string connectionString) => new NpgsqlConnectionStringBuilder(connectionString);

    protected override Compiler DefineDatabaseCompiler() => new PostgresCompiler();

    protected override DbConnection DetermineConnectionString(Query query)
    {
        if (ReadConnectionIsAvailable(query))
        {
            return new NpgsqlConnection(_readConnectionBuilder.ConnectionString);
        }

        return new NpgsqlConnection(_writeConnectionBuilder.ConnectionString);
    }
}