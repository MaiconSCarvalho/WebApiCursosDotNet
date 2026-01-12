namespace WebAPIPrimary.api.Models
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public object AlunoId { get; internal set; }
    }
}
