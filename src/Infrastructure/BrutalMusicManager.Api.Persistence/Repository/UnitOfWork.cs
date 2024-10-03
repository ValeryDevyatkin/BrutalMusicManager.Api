using BrutalMusicManager.Api.Application.Repository;
using BrutalMusicManager.Api.Persistence.Context;

namespace BrutalMusicManager.Api.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly MusicManagerDbContext _context;

    public UnitOfWork(
        MusicManagerDbContext context,
        ITrackMetadataRepository trackMetadataRepository)
    {
        _context = context;

        TrackMetadataRepository = trackMetadataRepository;
    }

    public ITrackMetadataRepository TrackMetadataRepository { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}