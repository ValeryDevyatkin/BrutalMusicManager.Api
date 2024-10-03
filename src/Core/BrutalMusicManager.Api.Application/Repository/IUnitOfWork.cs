namespace BrutalMusicManager.Api.Application.Repository;

public interface IUnitOfWork
{
    ITrackMetadataRepository TrackMetadataRepository { get; }

    public Task SaveChangesAsync();
}