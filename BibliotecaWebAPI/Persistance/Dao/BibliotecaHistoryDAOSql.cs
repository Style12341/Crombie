using BibliotecaWebAPI.Models.Dto;
using BibliotecaWebAPI.Persistance.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BibliotecaWebAPI.Persistance.Dao
{
    public class BibliotecaHistoryDAOSql : IBibliotecaHistoryDAO
    {
        private readonly DBManager _dbManager;

        public BibliotecaHistoryDAOSql(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
        public BibliotecaHistoryDTO Create(BibliotecaHistoryDTO obj)
        {
            var sql = @"INSERT INTO ledger (libro_id,usuario_id,accion) VALUES (@BookId,@UserId,@Action)";
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                connection.Execute(sql, obj);
            }
            return obj;
        }

        public void Delete(int id)
        {
            throw new Exception("Delete is not supported for History objects");
        }

        public BibliotecaHistoryDTO Get(int id)
        {
            throw new Exception("Get by id is not supported for History objects");
        }

        public List<BibliotecaHistoryDTO> GetAll()
        {
            var sql = @"SELECT usuario_id as UserID, libro_id as BookId, fecha, accion as Action FROM ledger";
            IEnumerable<BibliotecaHistoryDTO> history;
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                history = connection.Query<BibliotecaHistoryDTO>(sql);
            }
            return history.ToList();
        }

        public List<BibliotecaHistoryDTO> GetAllByIds(List<int> ids)
        {
            throw new Exception("Get by ids is not supported for History objects");
        }

        public List<BibliotecaHistoryDTO> GetByBook(int id)
        {
            var sql = @"SELECT usuario_id as UserID, libro_id as BookId, fecha, accion as Action FROM ledger WHERE libro_id=@Id";
            IEnumerable<BibliotecaHistoryDTO> history;
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                history = connection.Query<BibliotecaHistoryDTO>(sql, new { Id = id });
            }
            return history.ToList();
        }

        public List<BibliotecaHistoryDTO> GetByUser(int id)
        {
            var sql = @"SELECT usuario_id as UserID, libro_id as BookId, fecha, accion as Action FROM ledger WHERE usuario_id=@Id";
            IEnumerable<BibliotecaHistoryDTO> history;
            using (var connection = _dbManager.GetConnection())
            {
                connection.Open();
                history = connection.Query<BibliotecaHistoryDTO>(sql, new { Id = id });
            }
            return history.ToList();
        }

        public BibliotecaHistoryDTO Update(BibliotecaHistoryDTO obj)
        {
            throw new Exception("Update is not supported for History objects");
        }
    }
}
