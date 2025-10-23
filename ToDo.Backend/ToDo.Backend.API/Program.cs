
using Microsoft.EntityFrameworkCore;
using ToDo.Backend.API.Interface;
using ToDo.Backend.API.MappingProfiles;
using ToDo.Backend.API.Service;
using ToDo.Backend.Data;
using ToDo.Backend.Data.Interface;
using ToDo.Backend.Data.Repository;

namespace ToDo.Backend.API
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

            builder.Services.AddScoped<IToDoService, ToDoService>()
                .AddScoped<IToDoRepository, ToDoRepository>();

            builder.Services.AddDbContext<ToDoContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(ToDoProfile).Assembly);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularClient", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ToDoContext>();
                    db.Database.Migrate();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAngularClient");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
