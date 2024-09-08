
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Persistence.Data;
using CleanArchitecture.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //services regestration (Iservice Collection)

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.AddInfrastructureRegestration();
            builder.AddServicesRegestrations();

            builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer());

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
