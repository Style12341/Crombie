using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BibliotecaWebAPI.Persistance.ExcelUtils
{
    // Class that allows to persist objects in an excel file
    // The class that inherits from this class must implement the methods Deserialize and Serialize
    public abstract class ExcelPersistable<T> where T : class
    {
        protected abstract int WORKSHEET_INDEX { get; }
        protected List<T> GetData()
        {
            List<List<XLCellValue>> xLCellValues = ExcelReader.GetData(WORKSHEET_INDEX);
            return DeserializeMultiple(xLCellValues);
        }
        protected T GetDataById(int id, int idColumn = -1)
        {
            var data = ExcelReader.GetDataById(WORKSHEET_INDEX, id, idColumn + 1);
            if (data.Count == 0)
            {
                return null;
            }
            return Deserialize(data);
        }
        protected List<T> GetDataByIdsList(List<int> ids, int idColumn = -1)
        {
            List<List<XLCellValue>> xLCellValues = ExcelReader.GetDataByIdsList(WORKSHEET_INDEX, ids, idColumn + 1);
            return DeserializeMultiple(xLCellValues);
        }
        protected List<T> InsertData(List<T> data)
        {
            List<List<XLCellValue>> xLCellValues = ExcelReader.InsertData(WORKSHEET_INDEX, data.Select(Serialize).ToList());
            return DeserializeMultiple(xLCellValues);
        }

        protected void UpdateData(T data)
        {
            ExcelReader.UpdateDataById(WORKSHEET_INDEX, Serialize(data));
        }

        protected void DeleteDataById(int id)
        {
            ExcelReader.DeleteDataById(WORKSHEET_INDEX, id);
        }
        private List<T> DeserializeMultiple(List<List<XLCellValue>> xLCellValues)
        {
            List<T> objs = [];
            if (xLCellValues.Count == 0)
            {
                return objs;
            }
            foreach (List<XLCellValue> row in xLCellValues)
            {
                T obj = Deserialize(row);
                objs.Add(obj);
            }
            return objs;
        }
        public abstract T Deserialize(List<XLCellValue> row);
        public abstract List<XLCellValue> Serialize(T obj);
    }
}
