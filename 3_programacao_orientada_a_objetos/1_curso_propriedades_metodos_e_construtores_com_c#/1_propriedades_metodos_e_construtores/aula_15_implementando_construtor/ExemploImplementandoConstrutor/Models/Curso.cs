namespace ExemploImplementandoConstrutor.Models
{
    public class Curso
    {
        // metodo construtor
        public Curso()
        {
            this.Alunos = new List<Pessoa>();
        }
        // propriedades privadas
        private string _nome;
        private List<Pessoa> _alunos;

        // propriedades publicas
        public string Nome
        {
            get => this._nome;
            set => this._nome = value;
        }
        public List<Pessoa> Alunos
        {
            get => this._alunos;
            set => this._alunos = value;
        }

        // metodos
        public void AdicionarAluno(Pessoa aluno) => this.Alunos.Add(aluno);
        
        public int ObterQuantidadeDeAlunosMatriculados() => this.Alunos.Count();

        public bool RemoverAluno(Pessoa aluno) => this.Alunos.Remove(aluno);
        
        public void ListarAlunos()
        {
            Console.WriteLine("Alunos do curso:");
            foreach(Pessoa aluno in this.Alunos)
            {
                 Console.WriteLine(aluno.NomeCompleto);
            }
        }
 
        
    }
}