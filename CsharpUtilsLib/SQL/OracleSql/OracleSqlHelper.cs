namespace CsharpUtilsLib.SQL.OracleSql
{
    public sealed class OracleSqlHelper : BaseSqlHelper
    {
        public OracleSqlHelper(string connectionString) : base(connectionString)
        {
            _compiler = new OracleCompiler();
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

        protected override DbConnection ConfigureConnection()
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        protected override async Task<DbConnection> ConfigureConnectionAsync(CancellationToken token)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            await conn.OpenAsync(token);
            return conn;
        }
    }
}
