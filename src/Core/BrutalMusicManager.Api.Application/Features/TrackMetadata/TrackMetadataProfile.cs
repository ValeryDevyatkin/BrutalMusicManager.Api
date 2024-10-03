using AutoMapper;
using BrutalMusicManager.Api.Domain.Model;

namespace BrutalMusicManager.Api.Application.Features.TrackMetadata;

public class TrackMetadataProfile : Profile
{
    public TrackMetadataProfile()
    {
        CreateMap<TrackMetadataModel, TrackMetadataDto>().ReverseMap();
    }
}