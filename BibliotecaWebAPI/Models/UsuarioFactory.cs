namespace BibliotecaWebAPI.Models
{
    public class UsuarioFactory
    {
        public static Usuario CreateUsuarioInstance(Usuario usuario)
        {
            return usuario.UserType switch
            {
                "Profesor" => new Profesor(usuario.Id, usuario.Nombre),
                "Estudiante" => new Estudiante(usuario.Id, usuario.Nombre, []),
                _ => throw new InvalidOperationException("Unknown user type"),
            };
        }
    }
}
