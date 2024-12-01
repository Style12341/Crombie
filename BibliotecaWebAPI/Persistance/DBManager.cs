using Microsoft.Data.SqlClient;

namespace BibliotecaWebAPI.Persistance
{
    public static class DBManager
    {
        public static SqlConnection GetConnection()
        {
            var connectionString = "data source=BMLP;initial catalog=BibliotecaWeb;trusted_connection=true;Integrated Security=true; TrustServerCertificate=True";
            return new SqlConnection(connectionString);
        }
    }
}
