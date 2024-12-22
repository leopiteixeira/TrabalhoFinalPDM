using SQLite;

namespace TrabalhoFinal.Models
{
    public class Livro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? NomeLivro { get; set; }
        public string? NomeAutor { get; set; }
        public string? EmailAutor { get; set; }
        public string? ISBN { get; set; }
    }
}
