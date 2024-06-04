using API.Extensions;
using HROnion.Application.Services;
using HROnion.Domain.Repositories;
using HROnion.Persistence.Database;
using HROnion.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<EmployeeService>();
    builder.Services.AddScoped<DepartmentService>();
    builder.Services.AddScoped<PositionService>();

    builder.Services.AddScoped<IPositionRepository, PositionRepository>();
    builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
        options.UseLazyLoadingProxies();
    });
}



WebApplication? app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapDepartmentEndpoints();

    app.MapEmployeeEndpoints();

    app.MapPositionEndpoints();

    app.Run();

}
