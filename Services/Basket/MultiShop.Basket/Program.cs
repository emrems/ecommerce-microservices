using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using MultiShop.Basket.Settings;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = builder.Configuration["IdentityServerUrl"];
            opt.Audience = "ResourceBasket";
            opt.RequireHttpsMetadata = false;
        });
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddScoped<IBasketService, BasketService>();
        //redis yapilandirmasi
        builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
        builder.Services.AddSingleton<RedisService>(opt =>
        {
            var redisSettings = opt.GetRequiredService<IOptions<RedisSettings>>().Value;
            var redis = new RedisService(redisSettings.Host, redisSettings.Port);
            return redis;
        });


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}