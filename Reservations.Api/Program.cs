using System.Reflection;
using Reservations.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
var applicationAssembly = Assembly.Load("Reservations.Application");

builder.Services.AddControllers();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(applicationAssembly));
builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("ApplicationDbContext"));
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

