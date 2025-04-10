using ArtSystem.Application.DTOs;
using ArtSystem.Domain.Entities;
using AutoMapper;

namespace ArtSystem.Application.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Artworks, ArtworksDto>().ReverseMap();
        }
    }
}
