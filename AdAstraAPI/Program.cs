
using AdAstraAPI.DAL;
using Microsoft.EntityFrameworkCore;

namespace AdAstraAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64; // Optional: Increase the depth limit if needed
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = builder.Configuration;
            var optionsBuilder = new DbContextOptionsBuilder<AdAstraDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AdAstraContextConnection"));

            var app = builder.Build();

            var context = new AdAstraDbContext(optionsBuilder.Options);
            CategoryData.Initialize(context);


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
