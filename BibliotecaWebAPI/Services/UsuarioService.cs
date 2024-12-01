using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Interfaces;
using BibliotecaWebAPI.Services.Interfaces;

namespace BibliotecaWebAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDAO<Usuario> _usuarioDAO;

        public UsuarioService(IDAO<Usuario> usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }
        public Usuario CreateUser(Usuario usuario)
        {
            return _usuarioDAO.Create(usuario);
        }
        public Estudiante CreateEstudiante(Estudiante est)
        {
            return (Estudiante)CreateUser(est);
        }
        public Profesor CreateProfesor(Profesor prof)
        {
            return (Profesor)CreateUser(prof);
        }
        public Usuario GetUser(int id)
        {
            return _usuarioDAO.Get(id);
        }
        public List<Usuario> GetAllUsers()
        {
            return _usuarioDAO.GetAll();
        }
        public List<Usuario> GetAllUsersByIds(List<int> ids)
        {
            return _usuarioDAO.GetAllByIds(ids);
        }
        public Usuario UpdateUser(Usuario usuario)
        {
            return _usuarioDAO.Update(usuario);
        }

        public void DeleteUser(int id)
        {
            Usuario usuario = _usuarioDAO.Get(id);
            if (usuario == null)
            {
                throw new Exception("The user does not exist");
            }
            if (usuario.LibrosPrestados.Count > 0)
            {
                throw new Exception("The user has books borrowed, it can't be deleted");
            }
            _usuarioDAO.Delete(id);
        }
        public Profesor GetProfessorById(int professorId)
        {
            Usuario user = GetUser(professorId);
            if (user is Profesor)
            {
                return (Profesor)user;
            }
            throw new Exception("The user is not a professor");
        }

        public Estudiante GetStudentById(int studentId)
        {
            Usuario user = GetUser(studentId);
            if (user is Estudiante)
            {
                return (Estudiante)user;
            }
            throw new Exception("The user is not a student");
        }
        public List<Profesor> GetAllProffesors()
        {
            return GetAllUsers().Where(u => u is Profesor).Cast<Profesor>().ToList();
        }
        public List<Estudiante> GetAllStudents()
        {
            return GetAllUsers().Where(u => u is Estudiante).Cast<Estudiante>().ToList();
        }
    }
}
