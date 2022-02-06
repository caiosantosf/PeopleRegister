using PeopleRegister.Application.Mappers;
using PeopleRegister.CrossCutting.IOC;
using PeopleRegister.CrossCutting.Filters;
using PeopleRegister.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDepencyInjection();
builder.Services.AddProfiles();

builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());
builder.Services.AddMvc(options => options.Filters.Add<GlobalExceptionFilter>());

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<Context>();

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
