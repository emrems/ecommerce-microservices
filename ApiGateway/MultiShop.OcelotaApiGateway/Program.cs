using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme",opt =>
        {
            opt.Authority = builder.Configuration["IdentityServerUrl"];
            opt.Audience = "ResourceOcelot";
            opt.RequireHttpsMetadata = false;
        });
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
        builder.Services.AddOcelot(configuration);
        var app = builder.Build();
        await app.UseOcelot();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}