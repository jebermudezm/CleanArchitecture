using Api.Extensions.Features;
using Api.Extensions.Injections;
using EF.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<AppDbContext>(options =>
//            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConection")));
#region Extensions

builder.Services.AddMainModules(builder.Configuration);
builder.Services.AddRepositoryModules();
builder.Services.AddServiceModules();
builder.Services.AddFeature(builder.Configuration);
//builder.Services.AddSwagger();

#endregion
//builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
