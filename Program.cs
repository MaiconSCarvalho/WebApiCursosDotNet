using Microsoft.EntityFrameworkCore;
using WebAPIPrimary.api.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolaDbContext>(
      o => o.UseSqlite(builder.Configuration["ConnectionStrings:EscolaDbConStr"])
    );

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
