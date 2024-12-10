using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Interfaces;
using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Data.SqlClient;

namespace BibliotecaWebAPI.Persistance.Dao
{

    public class LibroDAOSql : IDAO<Libro>
    {
        private readonly SqlConnection _conn;
        private readonly DBManager _dbManager;

        public LibroDAOSql(DBManager dbManager)
        {
            _dbManager = dbManager;
            _conn = dbManager.GetConnection();
        }
        public Libro Create(Libro obj)
        {
            var sql = @"INSERT INTO libros (titulo,autor,available,prestante_id) OUTPUT INSERTED.Id VALUES (@Titulo,@Autor,@Available,@PrestanteID)";
            var parameters = new
            {
                Titulo = obj.Titulo,
                Autor = obj.Autor,
                PrestanteID = obj.Prestante?.Id,
                Available = obj.Available
            };
            using (var connection = _conn)
            {
                connection.Open();
                var id = connection.QuerySingle<int>(sql, parameters);
                obj.Id = id;
            }
            return obj;
        }

        public void Delete(int id)
        {
            var sql = @"DELETE FROM libros WHERE id=@Id";
            _dbManager.DeleteEntity(sql, id);
        }

        public Libro Get(int id)
        {
            var sql = @"SELECT l.id as Id, l.titulo as Titulo, l.autor as Autor, l.available AS Available,
                u.id AS Id, u.nombre AS Nombre, u.UserType AS UserType
                FROM Libros AS l
                LEFT JOIN Usuarios AS u ON u.id = l.prestante_id
                WHERE l.id = @Id";

            using (var connection = _conn)
            {
                connection.Open();
                var libro = connection.Query<Libro, Usuario, Libro>(
                    sql,
                    (libro, usuario) =>
                    {
                        if (usuario != null)
                        {
                            libro.Prestante = UsuarioFactory.CreateUsuarioInstance(usuario);
                        }
                        return libro;
                    },
                    new { Id = id },
                    splitOn: "Id"
                ).FirstOrDefault();

                return libro;
            }
        }

        public List<Libro> GetAll()
        {
            var sql = @"SELECT l.id as Id, l.titulo as Titulo, l.autor as Autor, l.available AS Available,
                u.id AS Id, u.nombre AS Nombre, u.UserType AS UserType
                FROM Libros AS l
                LEFT JOIN Usuarios AS u ON u.id = l.prestante_id";
            IEnumerable<Libro> libros;
            using (var connection = _conn)
            {
                connection.Open();
                libros = connection.Query<Libro, Usuario, Libro>(
                    sql,
                    (libro, usuario) =>
                    {
                        if (usuario != null)
                        {
                            libro.Prestante = UsuarioFactory.CreateUsuarioInstance(usuario);
                        }
                        return libro;
                    },
                    splitOn: "Id"
                );
            }
            return libros.ToList();
        }

        public List<Libro> GetAllByIds(List<int> ids)
        {
            var sql = @"SELECT l.id as Id, l.titulo as Titulo, l.autor as Autor, l.available AS Available,
                u.id AS Id, u.nombre AS Nombre, u.UserType AS UserType
                FROM Libros AS l
                LEFT JOIN Usuarios AS u ON u.id = l.prestante_id
                WHERE l.id IN @Ids";
            IEnumerable<Libro> libros;
            using (var connection = _conn)
            {
                connection.Open();
                libros = connection.Query<Libro, Usuario, Libro>(
                    sql,
                    (libro, usuario) =>
                    {
                        if (usuario != null)
                        {
                            libro.Prestante = UsuarioFactory.CreateUsuarioInstance(usuario);
                        }
                        return libro;
                    }, new { Ids = ids },
                    splitOn: "Id"
                );
            }
            return libros.ToList();
        }

        public Libro Update(Libro obj)
        {
            var sql = @"UPDATE libros SET titulo=@Titulo,autor=@Autor,prestante_id=@PrestanteID,available=@Available WHERE id=@Id";
            using (var connection = _conn)
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new
                        {
                            Id = obj.Id,
                            Titulo = obj.Titulo,
                            Autor = obj.Autor,
                            PrestanteID = obj.Prestante?.Id,
                            Available = obj.Available
                        };
                        var rowsAffected = connection.Execute(sql, parameters, transaction);
                        transaction.Commit();
                        return obj;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
        }
    }
}
