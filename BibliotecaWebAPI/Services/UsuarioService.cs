using BibliotecaWebAPI.Exceptions;
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
            Usuario usuario = _usuarioDAO.Get(id);
            if (usuario == null)
            {
                throw new EntityNotFoundException($"El usuario con id {id} no ha sido encontrado");
            }
            return usuario;
        }

        public List<Usuario> GetAllUsers()
        {
            return _usuarioDAO.GetAll();
        }

        public List<Usuario> GetAllUsersByIds(List<int> ids)
        {
            var usuarios = _usuarioDAO.GetAllByIds(ids);
            if (usuarios == null || !usuarios.Any())
            {
                throw new EntityNotFoundException("No se encontraron usuarios con los ids proporcionados");
            }
            return usuarios;
        }

        public Usuario UpdateUser(Usuario usuario)
        {
            if (_usuarioDAO.Get(usuario.Id) == null)
            {
                throw new EntityNotFoundException($"El usuario con id {usuario.Id} no ha sido encontrado");
            }
            return _usuarioDAO.Update(usuario);
        }

        public void DeleteUser(int id)
        {
            Usuario usuario = _usuarioDAO.Get(id);
            if (usuario == null)
            {
                throw new EntityNotFoundException($"El usuario con id {id} no ha sido encontrado");
            }
            if (usuario.LibrosPrestados.Count > 0)
            {
                throw new InvalidOperationException("El usuario tiene libros prestados, no puede ser eliminado");
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
            throw new InvalidOperationException("El usuario no es un profesor");
        }

        public Estudiante GetStudentById(int studentId)
        {
            Usuario user = GetUser(studentId);
            if (user is Estudiante)
            {
                return (Estudiante)user;
            }
            throw new InvalidOperationException("El usuario no es un estudiante");
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
