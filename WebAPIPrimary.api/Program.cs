using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPrimary.api.DbContexts;
using WebAPIPrimary.api.Entites;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolaDbContext>(
      o => o.UseSqlite(builder.Configuration["ConnectionStrings:EscolaDbConStr"])
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/alunos", async Task<Results<NoContent, Ok<List<Alunos>>>> 
    (EscolaDbContext escolaDbContext,
    [FromQuery(Name = "name")] string? alunonome) => {

    var alunosEntity = await escolaDbContext.Alunos
                                .Where(x => alunonome ==null || x.Nome.Contains(alunonome))
                                .ToListAsync();
    if (alunosEntity.Count <= 0 || alunosEntity == null)
        return TypedResults.NoContent();
    else
        return TypedResults.Ok(alunosEntity);         
});  

app.MapGet("/aluno/{id:int}", async (EscolaDbContext escolaDbContext, int id) => {

    return await escolaDbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id);

});

app.Run();
