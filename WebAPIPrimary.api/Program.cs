using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPrimary.api.DbContexts;
using WebAPIPrimary.api.Entites;
using WebAPIPrimary.api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolaDbContext>(
      o => o.UseSqlite(builder.Configuration["ConnectionStrings:EscolaDbConStr"])
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


//app.MapGet("/alunos", async Task<Results<NoContent, Ok<List<Alunos>>>>
//    (EscolaDbContext escolaDbContext,
//    [FromQuery(Name = "name")] string? alunonome) => {

//        var alunosEntity = await escolaDbContext.Alunos
//                                    .Where(x => alunonome == null || x.Nome.ToLower().Contains(alunonome.ToLower()))
//                                    .ToListAsync();
//        if (alunosEntity.Count <= 0 || alunosEntity == null)
//            return TypedResults.NoContent();
//        else
//            return TypedResults.Ok(alunosEntity);

//    });

app.MapGet("/alunos", async (HttpContext httpContext) =>
{
    var escolaDbContext = httpContext.RequestServices.GetRequiredService<EscolaDbContext>();
    var mapper = httpContext.RequestServices.GetRequiredService<IMapper>();
    var alunonome = httpContext.Request.Query["name"].ToString();

    var alunos = await escolaDbContext.Alunos
        .AsNoTracking()
        .Where(a => string.IsNullOrEmpty(alunonome) ||
                    EF.Functions.Like(a.Nome, $"%{alunonome}%"))
        .ToListAsync();

    if (alunos == null || alunos.Count == 0)
        return Results.NoContent();

    var alunosDto = mapper.Map<IEnumerable<AlunoDTO>>(alunos);

    return Results.Ok(alunosDto);
});

app.MapGet("/aluno/{alunoId:int}/cursos", async (
    EscolaDbContext escolaDbContext,
    IMapper mapper,
    int alunoId) =>
{
    return mapper.Map<IEnumerable<CursoDTO>>((await escolaDbContext.Alunos
                                .Include(aluno => aluno.Cursos)
                                .FirstOrDefaultAsync(aluno => aluno.Id == alunoId))?.Cursos);

});

app.MapGet("/aluno/{id:int}", async (
    EscolaDbContext escolaDbContext,
    IMapper mapper,
    int id) =>
{
    var aluno = await escolaDbContext.Alunos
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);

    if (aluno == null)
        return Results.NotFound();

    var alunoDto = mapper.Map<AlunoDTO>(aluno);

    return Results.Ok(alunoDto);
});

    app.Run();
