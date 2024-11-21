
using BibliotecaApp;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance;
using BibliotecaWebAPI.Persistance.Interfaces;
using BibliotecaWebAPI.Services;
using BibliotecaWebAPI.Services.Interfaces;

namespace BibliotecaWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDAO<Usuario>, UsuarioDAOExcel>();
            builder.Services.AddScoped<IDAO<Libro>, LibroDAOExcel>();
            builder.Services.AddScoped<IBibliotecaHistoryDAO, BibliotecaHistoryDAOExcel>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<ILibroService, LibroService>();
            builder.Services.AddScoped<IBibliotecaService, BibliotecaService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
