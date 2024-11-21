using BibliotecaApp;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Interfaces;
using ClosedXML.Excel;

namespace BibliotecaWebAPI.Persistance
{
    public class UsuarioDAOExcel : ExcelPersistable<Usuario>, IDAO<Usuario>
    {
        protected override int WORKSHEET_INDEX { get; } = 1;
        private const int MAX_ELEMENTS = 4;
        private const int ID_INDEX = 0;
        private const int NOMBRE_INDEX = 1;
        private const int TIPO_INDEX = 2;
        private const int LIBROS_INDEX = 3;

        public Usuario Create(Usuario obj)
        {
            return InsertData([obj]).First();
        }

        public void Delete(int id)
        {
            DeleteDataById(id);
        }

        public Usuario Update(Usuario obj)
        {
            UpdateData(obj);
            return obj;
        }

        public Usuario Get(int id)
        {
            return GetDataById(id);
        }

        public List<Usuario> GetAll()
        {
            return GetData();
        }

        public override List<XLCellValue> Serialize(Usuario obj)
        {
            List<Libro> librosPrestados = obj.LibrosPrestados;
            string librosPrestadosString = string.Join(",", librosPrestados.Select(libro => libro.Id).ToList());
            XLCellValue[] row =
           [
               obj.Id,
               obj.Nombre,
               obj.UserType,
               librosPrestadosString
            ];
            return row.ToList();
        }
        public List<Usuario> GetAllByIds(List<int> ids)
        {
            return GetDataByIdsList(ids);
        }
        public override Usuario Deserialize(List<XLCellValue> row)
        {
            if (row.Count != MAX_ELEMENTS)
            {
                throw new Exception("The data structure does not match the excel file");
            }
            int id = (int)row[ID_INDEX];
            string nombre = (string)row[NOMBRE_INDEX];
            string tipo = (string)row[TIPO_INDEX];
            List<int> librosPrestadosIds;
            if (row[LIBROS_INDEX].IsNumber)
                librosPrestadosIds = [(int)row[LIBROS_INDEX]];
            else
            {
                string libros = (string)row[LIBROS_INDEX];
                if (libros == "")
                    librosPrestadosIds = [];
                else
                    librosPrestadosIds = ((string)row[LIBROS_INDEX]).Split(",").Select(int.Parse).ToList();
            }
            IDAO<Libro> libroDAO = new LibroDAOExcel();
            List<Libro> librosPrestados = libroDAO.GetAllByIds(librosPrestadosIds);
            if (tipo == "Profesor")
            {
                return new Profesor(id, nombre, librosPrestados);
            }
            else
            {
                return new Estudiante(id, nombre, librosPrestados);
            }
        }
    }
}
