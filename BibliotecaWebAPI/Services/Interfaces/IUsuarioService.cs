using BibliotecaApp;
using BibliotecaWebAPI.Models;

namespace BibliotecaWebAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Estudiante CreateEstudiante(Estudiante est);
        Profesor CreateProfesor(Profesor prof);
        Usuario CreateUser(Usuario usuario);
        void DeleteUser(int id);
        List<Profesor> GetAllProffesors();
        List<Estudiante> GetAllStudents();
        List<Usuario> GetAllUsers();
        List<Usuario> GetAllUsersByIds(List<int> ids);
        Profesor GetProfessorById(int professorId);
        Estudiante GetStudentById(int studentId);
        Usuario GetUser(int id);
        Usuario UpdateUser(Usuario usuario);
    }
}