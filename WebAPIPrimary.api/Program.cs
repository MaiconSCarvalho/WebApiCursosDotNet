using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPrimary.api.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolaDbContext>(
      o => o.UseSqlite(builder.Configuration["ConnectionStrings:EscolaDbConStr"])
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/aluno/{nome}", async (EscolaDbContext escolaDbContext, string nome ) => {

    return await escolaDbContext.Alunos.FirstOrDefaultAsync(x => x.Nome == nome);

});

app.MapGet("/aluno/{id:int}", async (EscolaDbContext escolaDbContext, [FromQuery(Name = "AlunoId")] int id) => {

    return await escolaDbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id);

});

app.MapGet("/alunos", async (EscolaDbContext escolaDbContext) => {

    return await escolaDbContext.Alunos.ToListAsync();

});

app.Run();
