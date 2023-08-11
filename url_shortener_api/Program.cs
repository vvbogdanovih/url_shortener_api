using BLL.Services;
using DAL;
using DAL.Models.Data;
using Microsoft.AspNetCore.Identity;
using url_shortener_api.Controllers;

namespace url_shortener_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins("*") // або "*" для доступу з будь-якого джерела
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            DALShortenerModule.Load(builder.Services, builder.Configuration);
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ShortenerDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddTransient<IAuthorizeService, AuthorizeService>();
            builder.Services.AddTransient<IDataService, DataService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("AllowSpecificOrigin");

            app.MapControllers();

            app.Run();
        }
    }
}