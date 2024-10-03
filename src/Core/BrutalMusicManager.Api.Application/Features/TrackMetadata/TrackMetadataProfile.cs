using AutoMapper;
using BrutalMusicManager.Api.Domain.Model;

namespace BrutalMusicManager.Api.Application.Features.TrackMetadata;

public class TrackMetadataProfile : Profile
{
    public TrackMetadataProfile()
    {
        CreateMap<TrackMetadataModel, TrackMetadataDto>()
            .ForMember(dest => dest.Hash, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            ;
    }
}