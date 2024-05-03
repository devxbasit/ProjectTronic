using AutoMapper;
using ProjectTronic.Backend.Application.Dto;
using ProjectTronic.Backend.Core.Models;

namespace ProjectTronic.Backend.Application.MappingProfiles;

public class MappingProfile :  Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}