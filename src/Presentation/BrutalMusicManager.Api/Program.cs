using BrutalMusicManager.Api.Application.Features.TrackMetadata;
using BrutalMusicManager.Api.Application.Repository;
using BrutalMusicManager.Api.Persistence.Context;
using BrutalMusicManager.Api.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace BrutalMusicManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.Services.AddDbContext<MusicManagerDbContext>(options => options.UseNpgsql(connectionString));

            // TODO: Run migrations
            //using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<MusicManagerDbContext>();
            //    dbContext.Database.Migrate();
            //}

            builder.Services.AddAutoMapper(typeof(TrackMetadataProfile));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITrackMetadataRepository, TrackMetadataRepository>();
            builder.Services.AddScoped<TrackMetadataService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
