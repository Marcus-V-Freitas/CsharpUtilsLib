namespace CsharpUtilsLib.SQL.OracleSql;

public class OracleSqlHelper : BaseSqlHelper
{
    public OracleSqlHelper(string connectionString) : base(connectionString)
    {
    }

    public OracleSqlHelper(string writeConnectionString, string readConnectionString) : base(writeConnectionString, readConnectionString)
    {

    }

    protected override DbCommand ConfigureCommand(Query query, DbConnection connection)
    {
        SqlResult compiledSql = _compiler.Compile(query);
        OracleCommand command = new OracleCommand(compiledSql.Sql, (OracleConnection)connection)
        {
            CommandTimeout = Timeout
        };

        foreach (string paramName in compiledSql.NamedBindings.Keys)
        {
            command.Parameters.Add(paramName.TrimStart(':'), compiledSql.NamedBindings[paramName]);
        }

        return command;
    }

    protected override DbConnectionStringBuilder CreateConnectionBuilder(string connectionString) => new OracleConnectionStringBuilder(connectionString);

    protected override Compiler DefineDatabaseCompiler() => new OracleCompiler();

    protected override DbConnection DetermineConnectionString(Query query)
    {
        if (ReadConnectionIsAvailable(query))
        {
            return new OracleConnection(_readConnectionBuilder.ConnectionString);
        }

        return new OracleConnection(_writeConnectionBuilder.ConnectionString);
    }
}