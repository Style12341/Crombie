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
        private readonly SqlConnection _conn;

        public UsuarioDAOSql(DBManager dbManager)
        {
            _dbManager = dbManager;
            _conn = dbManager.GetConnection();
        }

        public Usuario Create(Usuario obj)
        {
            var sql = @"INSERT INTO usuarios(nombre,usertype) OUTPUT INSERTED.Id VALUES(@Nombre,@UserType)";
            using (var connection = _conn)
            {
                connection.Open();
                var id = connection.QuerySingle<int>(sql, obj);

                obj.Id = id;
            }
            return obj;
        }

        public void Delete(int id)
        {
            var sql = @"DELETE FROM usuarios where id=@Id";
            _dbManager.DeleteEntity(sql, id);
        }

        public Usuario Get(int id)
        {
            var sql = @"SELECT * FROM usuarios WHERE id=@Id";
            Usuario user;
            using (var connection = _conn)
            {
                connection.Open();
                var tempUser = connection.QuerySingle<Usuario>(sql, new {Id=id});
                user = UsuarioFactory.CreateUsuarioInstance(tempUser);
            }
            return user;
        }

        public List<Usuario> GetAll()
        {
            var sql = @"SELECT * FROM usuarios";
            IEnumerable<Usuario> users;
            using (var connection = _conn)
            {
                connection.Open();
                var tempUsers = connection.Query<Usuario>(sql);
                users = tempUsers.Select(usuario => UsuarioFactory.CreateUsuarioInstance(usuario));
            }
            return users.ToList();
        }

        public List<Usuario> GetAllByIds(List<int> ids)
        {
            var sql = @"SELECT * FROM usuarios WHERE id IN @Ids";
            IEnumerable<Usuario> users;
            using (var connection = _conn)
            {
                connection.Open();
                var tempUsers = connection.Query<Usuario>(sql, new { Ids = ids });
                users = tempUsers.Select(usuario => UsuarioFactory.CreateUsuarioInstance(usuario));
            }
            return users.ToList();
        }

        public Usuario Update(Usuario obj)
        {
            var sql = @"UPDATE usuarios SET nombre=@Nombre,usertype=@UserType";
            using (var connection = _conn)
            {
                using (var transaction = connection.BeginTransaction())
                {
                    connection.Open();
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
