using Microsoft.EntityFrameworkCore;
using MultiShop.Orders.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Orders.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Orders.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Orders.Application.Interfaces;
using MultiShop.Orders.Application.Services;
using MultiShop.Orders.Persistance.Context;
using MultiShop.Orders.Persistance.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddAplicationService(builder.Configuration);// extension method
        #region
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
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<OrderContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"));
        });

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