namespace ExemploBodyExpressions.Models
{
    public class Pessoa
    {
         // propriedades privadas
        private string _nome;
        private int _idade;

        // propriedades publicas
        public string Nome
        {
            get => this._nome.ToUpper();
            set => this._nome = value;
        }
        public int Idade
        {
            get => this._idade;
            set => this._idade = value;    
        }

        public void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {this.Nome} e tenho {this.Idade} anos.");
        }
    }
}
