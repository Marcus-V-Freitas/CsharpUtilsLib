namespace CsharpUtilsLib.SQL.SqlServer;

public class SqlServerHelper : BaseSqlHelper
{
    public SqlServerHelper(string connectionString) : base(connectionString)
    {
    }

    public SqlServerHelper(string writeConnectionString, string readConnectionString) : base(writeConnectionString, readConnectionString)
    {

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

    protected override DbConnectionStringBuilder CreateConnectionBuilder(string connectionString) => new SqlConnectionStringBuilder(connectionString);

    protected override Compiler DefineDatabaseCompiler() => new SqlServerCompiler();

    protected override DbConnection DetermineConnectionString(Query query)
    {
        if (ReadConnectionIsAvailable(query))
        {
            return new SqlConnection(_readConnectionBuilder.ConnectionString);
        }

        return new SqlConnection(_writeConnectionBuilder.ConnectionString);
    }
}