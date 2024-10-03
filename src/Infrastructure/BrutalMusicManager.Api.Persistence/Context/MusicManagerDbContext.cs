using BrutalMusicManager.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BrutalMusicManager.Api.Persistence.Context;

public class MusicManagerDbContext : DbContext
{
    public MusicManagerDbContext(DbContextOptions<MusicManagerDbContext> options) : base(options)
    {
    }

    public DbSet<TrackMetadataModel> TrackMetadataItems { get; set; }
}