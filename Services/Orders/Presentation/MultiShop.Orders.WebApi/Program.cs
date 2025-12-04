using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MultiShop.Orders.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Orders.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Orders.Application.Interfaces;
using MultiShop.Orders.Application.Services;
using MultiShop.Orders.Persistance.Context;
using MultiShop.Orders.Persistance.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // HttpClient factory ekle (performans için)
        builder.Services.AddHttpClient();

        // Authentication Configuration
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ResourceOrder";
                opt.RequireHttpsMetadata = false;

                // Token validation parametrelerini ayarla
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = "ResourceOrder",
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["IdentityServerUrl"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    // Signing key'leri cache'le (her requestte çekme)
                    IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
                    {
                        using var client = new HttpClient(); // using ile dispose et
                        var response = client.GetAsync($"{builder.Configuration["IdentityServerUrl"]}/.well-known/openid-configuration/jwks").Result;
                        var jwks = new JsonWebKeySet(response.Content.ReadAsStringAsync().Result);
                        return jwks.Keys;
                    }
                };

                // Event handlers (opsiyonel - debug için)
                opt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        if (context.Exception.InnerException != null)
                        {
                            Console.WriteLine($"Inner exception: {context.Exception.InnerException.Message}");
                        }
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("✓ Token validated successfully!");
                        return Task.CompletedTask;
                    }
                };
            });

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddAplicationService(builder.Configuration);

        #region CQRS Handlers
        builder.Services.AddScoped<GetAdressByIdQueryHandler>();
        builder.Services.AddScoped<GetAdressQueryHandler>();
        builder.Services.AddScoped<CreateAdressCommandHandler>();
        builder.Services.AddScoped<UpdateAdressCommandHandler>();
        builder.Services.AddScoped<RemoveAdressCommandHandler>();
        builder.Services.AddScoped<GetOrderDetailQueryHandler>();
        builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
        builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
        builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
        builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
        #endregion

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<OrderContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}