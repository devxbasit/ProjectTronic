using Hangfire;
using HangfireBasicAuthenticationFilter;
using ProjectTronic.Backend.BugApi.Services;
using ProjectTronic.Backend.BugApi.Services.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSingleton<IEmailService, EmailService>();


// Add Hangfire services.
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("ProjectTronicHangFireDbConnectionString")));

// Add Hangfire Server
builder.Services.AddHangfireServer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

Console.Clear();
Console.WriteLine(
    builder.Configuration.GetValue<string>("HangFireOptions:BasicAuthenticationFilterValues:User1:UserName")
);

app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter
        {
            // set username and password
            User = builder.Configuration.GetValue<string>(
                "HangFireOptions:BasicAuthenticationFilterValues:User1:UserName"),
            Pass = builder.Configuration.GetValue<string>(
                "HangFireOptions:BasicAuthenticationFilterValues:User1:Password"),
        }
    }
});

app.UseHangfireServer();

app.MapControllers();
app.Run();