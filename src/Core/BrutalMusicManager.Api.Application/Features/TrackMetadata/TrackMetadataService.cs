using AutoMapper;
using BrutalMusicManager.Api.Application.Repository;

namespace BrutalMusicManager.Api.Application.Features.TrackMetadata;

public class TrackMetadataService
{
    private readonly ITrackMetadataRepository _trackMetadataRepository;
    private readonly IMapper _mapper;

    public TrackMetadataService(
        ITrackMetadataRepository trackMetadataRepository,
        IMapper mapper)
    {
        _trackMetadataRepository = trackMetadataRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TrackMetadataDto>> GetAllAsync()
    {
        var models = await _trackMetadataRepository.GetAsync();
        var dtoList = _mapper.Map<IEnumerable<TrackMetadataDto>>(models);

        return dtoList;
    }
}