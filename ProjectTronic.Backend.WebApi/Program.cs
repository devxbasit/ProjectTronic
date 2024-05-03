using ProjectTronic.Backend.Application.Services;
using ProjectTronic.Backend.Application.Services.IService;
using ProjectTronic.Backend.Contracts;
using ProjectTronic.Backend.Core.Services;
using ProjectTronic.Backend.Core.Services.IService;
using ProjectTronic.Backend.Infrastructure.Repositories;
using ProjectTronic.Backend.WebApi;
using ProjectTronic.Backend.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IRepositoryManager, RepositoryManager>();
builder.Services.AddSingleton<IServiceManager, ServiceManager>();
builder.Services.AddSingleton<ISqlConnectionFactory>(serviceProvider =>
{
    var connectionString = builder.Configuration.GetConnectionString("ProjectTronicDbConnectionString");
    return new SqlConnectionFactory(connectionString);
});

builder.Services.ConfigureCors();

builder.Services.ConfigureAutoMapper();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(options => { });

app.UseCors(CorsPolicyNames.ProjectTronicAllowSpecificOrigins.ToString());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();