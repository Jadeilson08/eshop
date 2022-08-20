using Microsoft.EntityFrameworkCore;
using ProductApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MySqlDbContext>();

var app = builder.Build();

/*var connection = app.Configuration["MySQlConnection:MySQlConnectionString"];

builder
    .Services
    .AddDbContext<MySqlDbContext>
    (options => 
        options.UseMySql(connection)
    );*/

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
