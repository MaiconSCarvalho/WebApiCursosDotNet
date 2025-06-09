using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPrimary.api.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolaDbContext>(
      o => o.UseSqlite(builder.Configuration["ConnectionStrings:EscolaDbConStr"])
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/alunos", async (EscolaDbContext escolaDbContext, [FromQuery(Name = "name")] string? alunonome) =>
{
    var query = escolaDbContext.Alunos.AsQueryable(); // Começa com a query base

    if (!string.IsNullOrEmpty(alunonome))
    {
        // Aplica o filtro SOMENTE se alunonome não for null ou vazio
        query = query.Where(x => x.Nome.Contains(alunonome));
    }

    // Executa a query (filtrada ou não)
    return await query.ToListAsync();
});

app.MapGet("/aluno/{id:int}", async (EscolaDbContext escolaDbContext, int id) => {

    return await escolaDbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id);

});

app.Run();
