using SQLite;
using TrabalhoFinal.Models;

namespace TrabalhoFinal.Data
{
    public class LivroRepository
    {
        private readonly SQLiteConnection _database;

        public LivroRepository(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Livro>();
        }

        public List<Livro> GetLivros() => _database.Table<Livro>().ToList();
        public int SaveLivro(Livro livro) => _database.Insert(livro);
        public int UpdateLivro(Livro livro) => _database.Update(livro);
        public int DeleteLivro(int id) => _database.Delete<Livro>(id);
    }
}
