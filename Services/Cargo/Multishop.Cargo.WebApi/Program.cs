using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Multishop.Cargo.BusinessLayer;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.BusinessLayer.Concreate;
using Multishop.Cargo.DataAccessLayer;
using Multishop.Cargo.DataAccessLayer.Abstract;
using Multishop.Cargo.DataAccessLayer.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = builder.Configuration["IdentityServerUrl"];
            opt.Audience = "ResourceCargo";//ResourceCatalog tokenine sahip olanlar ?dentityServer configde tan?ml? permissionlara sahip olabilecek
            opt.RequireHttpsMetadata = false;
        });
        builder.Services.AddDbContext<CargoContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        // Add services to the container.
        builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
        builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
        builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
        builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();

        builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
        builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
        builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
        builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();



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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}