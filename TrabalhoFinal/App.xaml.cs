using TrabalhoFinal.Data;

namespace TrabalhoFinal
{
    public partial class App : Application
    {
        public static LivroRepository LivroRepo { get; private set; }
        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "livros.db");
            LivroRepo = new LivroRepository(dbPath);

            MainPage = new AppShell();
        }
    }
}
