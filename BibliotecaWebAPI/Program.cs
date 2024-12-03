
using BibliotecaWebAPI;
using BibliotecaWebAPI.Logging;
using BibliotecaWebAPI.Middlewares;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Dao;
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
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDAO<Usuario>, UsuarioDAOExcel>();
            builder.Services.AddScoped<IDAO<Libro>, LibroDAOSql>();
            builder.Services.AddScoped<IBibliotecaHistoryDAO, BibliotecaHistoryDAOExcel>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<ILibroService, LibroService>();
            builder.Services.AddScoped<IBibliotecaService, BibliotecaService>();
            var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "api.log");
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
            builder.Services.AddSingleton(new FileLogger(logFilePath));
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //Add Logger to FileLogger
            FileLogger fileLogger = app.Services.GetRequiredService<FileLogger>();
            fileLogger.SetLogger(app.Logger);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<LatencyLogMiddleware>();
            app.UseMiddleware<ErrorLoggingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
