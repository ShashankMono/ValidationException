
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidationExample.Data;
using ValidationExample.Exceptions;
using ValidationExample.Repository;
using ValidationExample.Services;

namespace ValidationExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<StudentContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connect"));
            });
            builder.Services.AddTransient(typeof(IRepository<>),typeof(GenricRepository<>));
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionHandler<AppExceptionHandler>();
            builder.Services.Configure<ApiBehaviorOptions>(options => { 
                options.SuppressModelStateInvalidFilter = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler(_ => { });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
