using DAL.Data;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using server.MiddleWares;
using Serilog;

string Cors = "_cors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IToDo, ToDoData>();
builder.Services.AddScoped<IPhoto, PhotoData>();
builder.Services.AddScoped<IPost, PostData>();
builder.Services.AddScoped<IUser,UsersData>();
builder.Services.AddDbContext<ProjectContext>(item =>
item.UseSqlServer("Data Source=DESKTOP-SI8MC0H ;Initial Catalog=MyPoject;Integrated Security=SSPI;Trusted_Connection=True;"));

builder.Services.AddCors(op =>
{
    op.AddPolicy(Cors, builder =>
    {
       
        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
    });
});

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(@"C:\Users\LocalUser\Desktop\shulamit\ιγ\react\ReactProject\j\log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorMiddleWare>();
app.UseMiddleware<InfoMiddleWare>();

app.UseCors(Cors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
