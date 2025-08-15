using Microsoft.EntityFrameworkCore;
using Rplace.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<rplaceDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.Run();
