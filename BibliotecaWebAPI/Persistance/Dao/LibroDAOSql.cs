using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BibliotecaWebAPI.Persistance.Dao
{

    public class LibroDAOSql : IDAO<Libro>
    {
        private readonly SqlConnection _conn;

        public LibroDAOSql(DBManager dbManager)
        {
            _conn = dbManager.GetConnection();
        }
        public Libro Create(Libro obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Libro Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Libro> GetAll()
        {
            var sql = "SELECT * FROM Libros";
            IEnumerable<Libro> libros;
            using (var connection = _conn)
            {
                connection.Open();
                libros = connection.Query<Libro>(sql);
            }
            return libros.ToList();
        }

        public List<Libro> GetAllByIds(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Libro Update(Libro obj)
        {
            throw new NotImplementedException();
        }
    }
}
