global using BookLibrary.Services;
global using BookLibrary.Models;
global using BookLibrary.Models.Dtos;
global using BookLibrary.Data;
global using BookLibrary.Config;
global using BookLibrary.Utils;

global using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBookLibraryServices(builder.Configuration);

var app = builder.Build();

app.Run();