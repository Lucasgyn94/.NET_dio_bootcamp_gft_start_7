namespace ExemploPropriedadeSomenteLeitura.Models
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

            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O Campo não deve ser vazio");
                }
                this._nome = value;
            }
        }
        public string Sobrenome{ get; set; }
        public string NomeCompleto => $"{this._nome} {this.Sobrenome}"; /*Propriedade NomeCompleto com apenas uma propriedade de leitura GET */
        public int Idade
        {
            get => this._idade;

            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException("Idade inválida. Escolha entre 0 e 120 anos.");
                }
                this._idade = value;
            }
        }

        public void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {this.NomeCompleto} e tenho {this.Idade} anos");
        }
 
    }
}