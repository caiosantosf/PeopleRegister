global using PeopleRegister.Data;
global using Microsoft.EntityFrameworkCore;

using PeopleRegister.Application.Mappers;
using PeopleRegister.CrossCutting.IOC;
using PeopleRegister.CrossCutting.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDepencyInjection();
builder.Services.AddProfiles();

builder.Services.AddMvc(options => options.Filters.Add<GlobalExceptionFilter>());

builder.Services.AddDbContext<Context>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<Context>();
await context.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
