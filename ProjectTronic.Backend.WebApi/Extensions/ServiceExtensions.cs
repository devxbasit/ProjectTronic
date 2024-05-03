using System.Net.Http.Headers;
using AutoMapper;
using Microsoft.Net.Http.Headers;
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


    public static void ConfigureCors(this IServiceCollection service)
    {
        // ***
        // Place UseCors() before UseAuthorization()

        // 1. WithHeaders:
        // This header is used in the response from the server to the browser.
        // It specifies which request headers from the browser's original request are allowed to be sent by the browser when making a cross-origin request.
        // This provides the browser with control over which headers it can include in the request to the server.

        // 2. WithExposedHeaders:
        // This header is also used in the response from the server to the browser.
        // It specifies which response headers from the server the browser is allowed to access.
        // By default, browsers restrict access to certain response headers for security reasons. WithExposedHeaders allows the server to explicitly whitelist specific response headers that the browser can include in its response object (like custom headers containing data).

        // Example
        // Imagine a scenario where a server wants to allow the browser to send an authorization header (Authorization) and expose a custom header containing user data (X-User-Data) in the response.
        // The server would include WithHeaders: Authorization in the response to inform the browser that the Authorization header is allowed in the request.
        // Additionally, the server would include WithExposedHeaders: X-User-Data to allow the browser to access the X-User-Data header in the response.
        // By using both WithHeaders and WithExposedHeaders, the server can control the flow of information between the browser and itself in a CORS scenario.

        
        service.AddCors(options =>
        {
            // policy 1
            options.AddPolicy(CorsPolicyNames.AllowAll.ToString(), builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            
            
            // policy 2
            options.AddPolicy(CorsPolicyNames.AllowAll.ToString(), builder =>
            {
                builder.WithOrigins("www.facebook.com", "www.tiwiter.com")
                    .WithMethods(HttpMethods.Get, HttpMethods.Post)
                    .WithHeaders(HeaderNames.Accept, HeaderNames.ContentType)
                    .WithExposedHeaders("X-Pagination");
            });
        });
    }
}