using ClosedXML.Excel;

namespace BibliotecaWebAPI.Persistance
{
    // Class that allows to persist objects in an excel file
    // The class that inherits from this class must implement the methods Deserialize and Serialize
    public abstract class ExcelPersistable<T> where T : class
    {
        protected abstract int WORKSHEET_INDEX { get; }
        public List<T> GetData()
        {
            List<List<XLCellValue>> xLCellValues = ExcelReader.GetData(WORKSHEET_INDEX);
            return DeserializeMultiple(xLCellValues);
        }
        public T GetDataById(int id)
        {
            return Deserialize(ExcelReader.GetDataById(WORKSHEET_INDEX, id));
        }
        public List<T> GetDataByIdsList(List<int> ids)
        {
            List<List<XLCellValue>> xLCellValues = ExcelReader.GetDataByIdsList(WORKSHEET_INDEX,ids);
            return DeserializeMultiple(xLCellValues);
        }
        public List<T> InsertData(List<T> data)
        {
            List<List<XLCellValue>> xLCellValues = ExcelReader.InsertData(WORKSHEET_INDEX, data.Select(Serialize).ToList());
            return DeserializeMultiple(xLCellValues);
        }

        public void UpdateData(T data)
        {
            ExcelReader.UpdateDataById(WORKSHEET_INDEX, Serialize(data));
        }

        public void DeleteDataById(int id)
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
