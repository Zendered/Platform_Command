using AutoMapper;
using PlatformService.API.Dtos;
using PlatformService.API.Models;

namespace PlatformService.API.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}
