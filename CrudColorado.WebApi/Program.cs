using CrudColorado.Application.Service;
using CrudColorado.Application.Service.Interface;
using CrudColorado.Infrastructure;
using CrudColorado.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register Configuration
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database Service
builder.Services.AddDbContext<ClientDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
    b => b.MigrationsAssembly("CrudColorado.WebApi")));
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

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
