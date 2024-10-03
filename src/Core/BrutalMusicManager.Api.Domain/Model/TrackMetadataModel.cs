using BrutalMusicManager.Api.Domain.Model.Base;

namespace BrutalMusicManager.Api.Domain.Model;

public class TrackMetadataModel : ModelBase<string>
{
    public string? Name { get; set; }
}