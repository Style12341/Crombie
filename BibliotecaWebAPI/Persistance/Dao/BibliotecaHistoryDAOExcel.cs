using BibliotecaWebAPI.Models.Dto;
using BibliotecaWebAPI.Persistance.ExcelUtils;
using BibliotecaWebAPI.Persistance.Interfaces;
using ClosedXML.Excel;

namespace BibliotecaWebAPI.Persistance.Dao
{
    public class BibliotecaHistoryDAOExcel : ExcelPersistable<BibliotecaHistoryDTO>, IBibliotecaHistoryDAO
    {

        protected override int WORKSHEET_INDEX => 2;
        private const int USER_ID_INDEX = 0;
        private const int USER_NAME_INDEX = 1;
        private const int ACTION_INDEX = 2;
        private const int BOOK_ID_INDEX = 3;
        private const int MAX_ELEMENTS = 4;
        public BibliotecaHistoryDTO Create(BibliotecaHistoryDTO obj)
        {
            return InsertData([obj]).First();
        }

        public void Delete(int id)
        {
            throw new Exception("Delete is not supported for History objects");
        }

        public BibliotecaHistoryDTO Get(int id)
        {
            throw new Exception("Get is not supported for History objects");
        }

        public List<BibliotecaHistoryDTO> GetByBook(int id)
        {
            return GetAllByIds([id], BOOK_ID_INDEX);
        }
        public List<BibliotecaHistoryDTO> GetByUser(int id)
        {
            return GetAllByIds([id], USER_ID_INDEX);
        }
        public List<BibliotecaHistoryDTO> GetAll()
        {
            return GetData();
        }
        public BibliotecaHistoryDTO Update(BibliotecaHistoryDTO obj)
        {
            throw new Exception("Update is not supported for History objects");
        }
        public List<BibliotecaHistoryDTO> GetAllByIds(List<int> ids)
        {
            throw new Exception("GetAllByIds is not supported for History objects");
        }
        public List<BibliotecaHistoryDTO> GetAllByIds(List<int> ids, int idColumn)
        {
            return GetDataByIdsList(ids, idColumn);
        }

        public override List<XLCellValue> Serialize(BibliotecaHistoryDTO obj)
        {
            XLCellValue[] row =
           [
               obj.UserId,
               obj.UserName,
               obj.Action,
               obj.BookId
            ];
            return row.ToList();
        }
        public override BibliotecaHistoryDTO Deserialize(List<XLCellValue> row)
        {
            if (row.Count != MAX_ELEMENTS)
            {
                throw new Exception("The data structure does not match the excel file");
            }
            return new BibliotecaHistoryDTO((int)row[USER_ID_INDEX], (string)row[USER_NAME_INDEX], (string)row[ACTION_INDEX], (int)row[BOOK_ID_INDEX]);
        }

    }
}
