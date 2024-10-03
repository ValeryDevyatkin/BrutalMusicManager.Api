using BrutalMusicManager.Api.Application.Repository;
using BrutalMusicManager.Api.Domain.Model;
using BrutalMusicManager.Api.Persistence.Context;
using BrutalMusicManager.Api.Persistence.Repository.Base;

namespace BrutalMusicManager.Api.Persistence.Repository;

public class TrackMetadataRepository : RepositoryBase<TrackMetadataModel>, ITrackMetadataRepository
{
    public TrackMetadataRepository(MusicManagerDbContext context) : base(context)
    {
    }
}