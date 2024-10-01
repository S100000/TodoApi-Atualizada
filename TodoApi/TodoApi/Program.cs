using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services.Author;
using TodoApi.Services.Book;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthorInterface, AuthorService>();//configuring the methods implemented in AuthorInterface to be implemented in AuthorServices.
builder.Services.AddScoped<BookInterface, BookService>();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//adcionando a string de conexão do appsettings ao appdbcontext
                                                                                                                                             

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
