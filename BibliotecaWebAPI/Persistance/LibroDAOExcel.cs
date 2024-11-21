using BibliotecaApp;
using BibliotecaWebAPI.Persistance.Interfaces;
using ClosedXML.Excel;

namespace BibliotecaWebAPI.Persistance
{
    public class LibroDAOExcel : ExcelPersistable<Libro>, IDAO<Libro>
    {
        protected override int WORKSHEET_INDEX { get; } = 3;
        private const int ID_INDEX = 0;
        private const int TITULO_INDEX = 1;
        private const int AUTOR_INDEX = 2;
        private const int DISPONIBLE_INDEX = 3;
        private const int MAX_ELEMENTS = 4;
        public Libro Create(Libro obj)
        {
            return InsertData([obj]).First();
        }
        public Libro Update(Libro obj)
        {
            UpdateData(obj);
            return obj;
        }
        public void Delete(int id)
        {
            DeleteDataById(id);
        }

        public Libro Get(int id)
        {
            return GetDataById(id);
        }
        public List<Libro> GetAllByIds(List<int> ids)
        {
            return GetDataByIdsList(ids);
        }
        public List<Libro> GetAll()
        {
            return GetData();
        }
        public override Libro Deserialize(List<XLCellValue> row)
        {
            if (row.Count != MAX_ELEMENTS)
            {
                throw new Exception("The data structure does not match the excel file");
            }
            bool disponible = ((string)row[DISPONIBLE_INDEX]) == "Disponible";
            return new Libro((int)row[ID_INDEX], (string)row[TITULO_INDEX], (string)row[AUTOR_INDEX], disponible);
        }
        public override List<XLCellValue> Serialize(Libro libro)
        {
            XLCellValue[] row =
            [
                libro.Id,
                libro.Titulo,
                libro.Autor,
                libro.Available ? "Disponible": "Prestado",
            ];
            return row.ToList();
        }
    }
}
