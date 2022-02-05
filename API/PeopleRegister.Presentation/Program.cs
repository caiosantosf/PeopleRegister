using PeopleRegister.Application.Mappers;
using PeopleRegister.CrossCutting.IOC;
using PeopleRegister.CrossCutting.Notifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDepencyInjection();
builder.Services.AddProfiles();

builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();