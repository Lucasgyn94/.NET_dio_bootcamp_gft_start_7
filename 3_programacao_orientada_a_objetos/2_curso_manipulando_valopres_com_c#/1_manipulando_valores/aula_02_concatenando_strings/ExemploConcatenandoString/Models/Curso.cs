namespace ExemploConcatenandoString.Models
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
            // concatenando string
            Console.WriteLine("Alunos do curso: " + this.Nome);

            for (int contador = 0; contador < this.Alunos.Count; contador++)
            {
                string texto = "Nº " + contador + " - " + this.Alunos[contador].NomeCompleto;
                Console.WriteLine(texto);
            }

        }
    }
}