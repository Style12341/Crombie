using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace BibliotecaWebAPI.Persistance.ExcelUtils
{
    public class ExcelReader
    {
        // Classes that use this class should know the data structure
        private static string FilePath = @".\Public\BibliotecaBaseDatos.xlsx";
        private static int DATA_START_ROW = 2;
        public static void SetFilePath(string path)
        {
            FilePath = path;
        }
        public static List<List<XLCellValue>> GetData(int worksheetIndex)
        {
            using var workbook = new XLWorkbook(FilePath);
            var worksheet = workbook.Worksheet(worksheetIndex);
            int lastRowUsed = worksheet.LastRowUsed().RowNumber();
            int lastColumnUsed = worksheet.LastColumnUsed().ColumnNumber();
            List<List<XLCellValue>> data = [];
            for (int i = DATA_START_ROW; i <= lastRowUsed; i++)
            {
                List<XLCellValue> row = new List<XLCellValue>();
                for (int j = 1; j <= lastColumnUsed; j++)
                {
                    row.Add(worksheet.Cell(i, j).Value);
                }
                data.Add(row);
            }
            return data;
        }
        public static List<XLCellValue> GetDataById(int worksheetIndex, int id, int idColumn = 0)
        {
            using var workbook = new XLWorkbook(FilePath);
            var worksheet = workbook.Worksheet(worksheetIndex);
            int lastRowUsed = worksheet.LastRowUsed().RowNumber();
            int lastColumnUsed = worksheet.LastColumnUsed().ColumnNumber();
            idColumn = idColumn == 0 ? 1 : idColumn;
            List<XLCellValue> data = [];
            for (int i = DATA_START_ROW; i <= lastRowUsed; i++)
            {
                int read_id = (int)worksheet.Cell(i, idColumn).Value;
                if (read_id != id)
                    continue;
                for (int j = 1; j <= lastColumnUsed; j++)
                {
                    data.Add(worksheet.Cell(i, j).Value);
                }
                break;
            }
            return data;
        }
        public static List<List<XLCellValue>> GetDataByIdsList(int worksheetIndex, List<int> ids, int idColumn = 0)
        {
            using var workbook = new XLWorkbook(FilePath);
            var worksheet = workbook.Worksheet(worksheetIndex);
            int lastRowUsed = worksheet.LastRowUsed().RowNumber();
            int lastColumnUsed = worksheet.LastColumnUsed().ColumnNumber();
            idColumn = idColumn == 0 ? 1 : idColumn;
            List<List<XLCellValue>> data = [];
            for (int i = DATA_START_ROW; i <= lastRowUsed; i++)
            {
                int read_id = (int)worksheet.Cell(i, idColumn).Value;
                if (!ids.Contains(read_id))
                    continue;
                List<XLCellValue> row = [];
                for (int j = 1; j <= lastColumnUsed; j++)
                {
                    row.Add(worksheet.Cell(i, j).Value);
                }
                data.Add(row);
            }
            return data;
        }

        public static void DeleteDataById(int worksheetIndex, int id)
        {
            using var workbook = new XLWorkbook(FilePath);
            var worksheet = workbook.Worksheet(worksheetIndex);
            int lastRowUsed = worksheet.LastRowUsed().RowNumber();
            int lastColumnUsed = worksheet.LastColumnUsed().ColumnNumber();
            bool found = false;
            for (int i = DATA_START_ROW; i <= lastRowUsed; i++)
            {
                int read_id = (int)worksheet.Cell(i, 1).Value;
                if (read_id == id)
                {
                    found = true;
                    worksheet.Row(i).Delete();
                    break;
                }
            }
            if (!found)
            {
                throw new Exception("The object was not found");
            }
            workbook.Save();
        }
        public static List<List<XLCellValue>> InsertData(int worksheetIndex, List<List<XLCellValue>> data)
        {
            using var workbook = new XLWorkbook(FilePath);
            var worksheet = workbook.Worksheet(worksheetIndex);
            int lastRowUsed = worksheet.LastRowUsed().RowNumber();
            int lastColumnUsed = worksheet.LastColumnUsed().ColumnNumber();
            if (data[0].Count != lastColumnUsed)
            {
                throw new Exception("The data structure does not match the excel file");
            }
            int nextId = (int)worksheet.Cell(lastRowUsed, 1).Value + 1;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    int iExcel = lastRowUsed + i + 1;
                    int jExcel = j + 1;
                    if (j == 0 && (int)data[i][j] <= 0)
                    {
                        data[i][j] = nextId++;
                    }
                    worksheet.Cell(iExcel, jExcel).Value = data[i][j];
                }
            }
            workbook.Save();
            return data;
        }
        public static void UpdateDataById(int worksheetIndex, List<XLCellValue> data)
        {
            // All objects have ids which is found on the first element
            using var workbook = new XLWorkbook(FilePath);
            var worksheet = workbook.Worksheet(worksheetIndex);
            int lastRowUsed = worksheet.LastRowUsed().RowNumber();
            int lastColumnUsed = worksheet.LastColumnUsed().ColumnNumber();
            bool found = false;
            for (int i = DATA_START_ROW; i <= lastRowUsed; i++)
            {
                int id = (int)worksheet.Cell(i, 1).Value;
                if (id == (int)data[0])
                {
                    found = true;
                    for (int j = 0; j < lastColumnUsed; j++)
                    {
                        int jExcel = j + 1;
                        worksheet.Cell(i, jExcel).Value = data[j];
                    }
                    workbook.Save();
                    break;
                }
            }
            if (!found)
            {
                throw new Exception("The object was not found");
            }

        }
    }
}
