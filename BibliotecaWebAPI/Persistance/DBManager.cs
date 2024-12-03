using Microsoft.Data.SqlClient;

namespace BibliotecaWebAPI.Persistance
{
    public class DBManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DBManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
