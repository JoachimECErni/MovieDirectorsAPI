using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MovieDirectorsAPI.Controllers;
using MovieDirectorsAPI.Converter;
using MovieDirectorsAPI.Data.Context;
using MovieDirectorsAPI.Data.Repositories;
using MovieDirectorsAPI.Data.Repositories.Interfaces;
using MovieDirectorsAPI.Mapping;

namespace MovieDirectorsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new CountryConverter());
                    options.JsonSerializerOptions.Converters.Add(new SexConverter());
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
            });

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(ICastRepository<>), typeof(CastRepository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

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
