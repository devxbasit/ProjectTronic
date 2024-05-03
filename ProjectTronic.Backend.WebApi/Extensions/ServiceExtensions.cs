using AutoMapper;
using ProjectTronic.Backend.Application.MappingProfiles;

namespace ProjectTronic.Backend.WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddMvc();
    }
}