using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Interfaces;
using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;

namespace BibliotecaWebAPI.Persistance.Dao
{
    public class UsuarioDAOSql : IDAO<Usuario>
    {
        private readonly DBManager _dbManager;

        public UsuarioDAOSql(DBManager dbManager)
        {
            _dbManager = dbManager;
        }

        public Usuario Create(Usuario obj)
        {
            var sql = @"INSERT INTO usuarios(nombre, usertype) OUTPUT INSERTED.Id VALUES(@Nombre, @UserType)";
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var id = connection.QuerySingle<int>(sql, obj);
                obj.Id = id;
            }
            return obj;
        }

        public void Delete(int id)
        {
            var sql = @"DELETE FROM usuarios WHERE id=@Id";
            _dbManager.DeleteEntity(sql, id);
        }

        public Usuario Get(int id)
        {
            var sql = @"
                    SELECT u.*, l.id as Id, l.titulo as Titulo, l.autor as Autor, l.available AS Available
                    FROM usuarios u
                    LEFT JOIN libros l ON l.prestante_id = u.id
                    WHERE u.id = @Id";

            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var userDictionary = new Dictionary<int, Usuario>();

                var users = connection.Query<Usuario, Libro, Usuario>(
                    sql,
                    (user, libro) =>
                    {
                        if (!userDictionary.TryGetValue(user.Id, out var currentUser))
                        {
                            currentUser = UsuarioFactory.CreateUsuarioInstance(user);
                            userDictionary.Add(currentUser.Id, currentUser);
                        }

                        if (libro != null)
                        {
                            currentUser.LibrosPrestados.Add(libro);
                        }

                        return currentUser;
                    },
                    new { Id = id },
                    splitOn: "Id"
                );

                return users.FirstOrDefault();
            }
        }

        public List<Usuario> GetAll()
        {
            var sql = @"
                    SELECT u.*, l.id as Id, l.titulo as Titulo, l.autor as Autor, l.available AS Available
                    FROM usuarios u
                    LEFT JOIN libros l ON l.prestante_id = u.id";

            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var userDictionary = new Dictionary<int, Usuario>();

                var users = connection.Query<Usuario, Libro, Usuario>(
                    sql,
                    (user, libro) =>
                    {
                        if (!userDictionary.TryGetValue(user.Id, out var currentUser))
                        {
                            currentUser = UsuarioFactory.CreateUsuarioInstance(user);
                            userDictionary.Add(currentUser.Id, currentUser);
                        }

                        if (libro != null)
                        {
                            currentUser.LibrosPrestados.Add(libro);
                        }

                        return currentUser;
                    },
                    splitOn: "Id"
                );

                return users.Distinct().ToList();
            }
        }

        public List<Usuario> GetAllByIds(List<int> ids)
        {
            var sql = @"
                    SELECT u.*, l.id as Id, l.titulo as Titulo, l.autor as Autor, l.available AS Available
                    FROM usuarios u
                    LEFT JOIN libros l ON l.prestante_id = u.id
                    WHERE u.id IN @Ids";

            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                var userDictionary = new Dictionary<int, Usuario>();

                var users = connection.Query<Usuario, Libro, Usuario>(
                    sql,
                    (user, libro) =>
                    {
                        if (!userDictionary.TryGetValue(user.Id, out var currentUser))
                        {
                            currentUser = UsuarioFactory.CreateUsuarioInstance(user);
                            userDictionary.Add(currentUser.Id, currentUser);
                        }

                        if (libro != null)
                        {
                            currentUser.LibrosPrestados.Add(libro);
                        }

                        return currentUser;
                    },
                    new { Ids = ids },
                    splitOn: "Id"
                );

                return users.Distinct().ToList();
            }
        }

        public Usuario Update(Usuario obj)
        {
            var sql = @"UPDATE usuarios SET nombre=@Nombre, usertype=@UserType WHERE id=@Id";
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var rowsAffected = connection.Execute(sql, obj, transaction);
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
