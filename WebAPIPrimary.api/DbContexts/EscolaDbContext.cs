using Microsoft.EntityFrameworkCore;
using WebAPIPrimary.api.Entites;

namespace WebAPIPrimary.api.DbContexts
{
    public class EscolaDbContext : DbContext
    {
        public EscolaDbContext(DbContextOptions<EscolaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alunos> Alunos { get; set; } = null!;
        public DbSet<Cursos> Cursos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do seeding para Cursos
            modelBuilder.Entity<Cursos>().HasData(
                new { Id = 1, Nome = "C#" },
                new { Id = 2, Nome = "Javascript" },
                new { Id = 3, Nome = "CSS" },
                new { Id = 4, Nome = "POO" },
                new { Id = 5, Nome = "Angular" },
                new { Id = 6, Nome = "Java" },
                new { Id = 7, Nome = "Swift" },
                new { Id = 8, Nome = "Spark" },
                new { Id = 9, Nome = "Glue" },
                new { Id = 10, Nome = "Git" },
                new { Id = 11, Nome = "EC2" },
                new { Id = 12, Nome = "Terraform" },
                new { Id = 13, Nome = "S3" },
                new { Id = 14, Nome = "SQS" },
                new { Id = 15, Nome = "API Gateway" },
                new { Id = 16, Nome = "Lambda" },
                new { Id = 17, Nome = "Python" },
                new { Id = 18, Nome = "Metodologia Agil" },
                new { Id = 19, Nome = "TDD" },
                new { Id = 20, Nome = "Nodejs" });

            // Configuração do seeding para Alunos
            modelBuilder.Entity<Alunos>().HasData(
                new { Id = 1, Nome = "Maicon" },
                new { Id = 2, Nome = "Bruno" },
                new { Id = 3, Nome = "Isadora" },
                new { Id = 4, Nome = "Mateus" },
                new { Id = 5, Nome = "Gleice" });

            // Configuração do relacionamento muitos-para-muitos e seeding de dados
            modelBuilder.Entity<Alunos>()
                .HasMany(a => a.Cursos)
                .WithMany(c => c.Alunos)
                .UsingEntity<Dictionary<string, object>>(
                    "AlunosCursos",
                    j => j.HasData(
                        new { CursosId = 1, AlunosId = 1 },
                        new { CursosId = 1, AlunosId = 2 },
                        new { CursosId = 1, AlunosId = 3 },
                        new { CursosId = 1, AlunosId = 4 },
                        new { CursosId = 1, AlunosId = 5 },
                        new { CursosId = 2, AlunosId = 2 },
                        new { CursosId = 2, AlunosId = 3 },
                        new { CursosId = 3, AlunosId = 1 },
                        new { CursosId = 3, AlunosId = 2 },
                        new { CursosId = 4, AlunosId = 5 },
                        new { CursosId = 1, AlunosId = 6 },
                        new { CursosId = 1, AlunosId = 7 },
                        new { CursosId = 1, AlunosId = 8 },
                        new { CursosId = 1, AlunosId = 9 },
                        new { CursosId = 1, AlunosId = 10 },
                        new { CursosId = 2, AlunosId = 11 },
                        new { CursosId = 2, AlunosId = 12 },
                        new { CursosId = 3, AlunosId = 13 },
                        new { CursosId = 3, AlunosId = 14 },
                        new { CursosId = 4, AlunosId = 15 },
                        new { CursosId = 4, AlunosId = 16 },
                        new { CursosId = 1, AlunosId = 18 },
                        new { CursosId = 1, AlunosId = 17 },
                        new { CursosId = 1, AlunosId = 19 },
                        new { CursosId = 1, AlunosId = 20 }

                    )
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
