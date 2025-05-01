using Npgsql;
using Revenda.Bebidas.BFF.Application;
using Revenda.Bebidas.BFF.Application.DependencyInjection;
using Revenda.Bebidas.BFF.Infra.DbAdapter;
using Revenda.Bebidas.BFF.Infra.DbAdapter.DependencyInjection;
using Revenda.Bebidas.WebApi.Middlewares;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataAccess(builder.Configuration.Get<DbAdapterConfiguration>());

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

builder.Services.AddApplication(builder.Configuration.Get<ApplicationConfiguration>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
