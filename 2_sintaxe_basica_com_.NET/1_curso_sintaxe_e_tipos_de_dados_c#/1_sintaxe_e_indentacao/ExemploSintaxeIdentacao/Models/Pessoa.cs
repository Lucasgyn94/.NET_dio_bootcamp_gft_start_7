namespace ExemploSintaxeIdentacao.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos!");
        }

        public void ApresentarUsandoPalavraReservada(string @class) {
            @class = "teste";
            Console.WriteLine($"Olá {@class}");
        }
    }
}