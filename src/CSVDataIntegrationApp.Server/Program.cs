
using CSVDataIntegrationApp.Application.Services;
using CSVDataIntegrationApp.Application.Validators;
using CSVDataIntegrationApp.Domain;
using CSVDataIntegrationApp.Infrastructure.Repositories;
using CSVDataIntegrationApp.Server.ActionHelpers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CSVDataIntegrationApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration["ConnectionStrings:SqlConnectionString"];
            builder.Services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(connectionString)
            );

            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeDtoValidator>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("AllowLocalhost"); // Apply CORS policy

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
