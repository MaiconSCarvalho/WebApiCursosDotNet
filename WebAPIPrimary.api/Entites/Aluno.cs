using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAPIPrimary.api.Entites;

public class Alunos {
[Key]
public int Id { get; set; }
[Required]
[MaxLength(200)]
public string Nome { get; set; }

    public ICollection<Cursos> Cursos { get; set; } = [];

public Alunos()
{

}
    [SetsRequiredMembers]
    public Alunos(int id, string nome)
{

    Id = id;
    Nome = nome;

}
}

