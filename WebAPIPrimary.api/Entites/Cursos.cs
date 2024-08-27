using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAPIPrimary.api.Entites;

public class Cursos
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Nome { get; set; }

    public ICollection<Alunos> Alunos { get; set; } = [];

    public Cursos()
    {
            
    }
    [SetsRequiredMembers]
    public Cursos(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

