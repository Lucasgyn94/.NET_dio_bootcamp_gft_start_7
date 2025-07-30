namespace ExemploPropriedadesNaPratica.Models
{
    public class Pessoa
    {
        /*PROPRIEDADES DA CLASSE PESSOA */
        public string Nome { get; set; }
        public int Idade { get; set; }

        /*METODOS = AÇÃO */
        public void Apresentar()
        {
            Console.WriteLine($"Olá meu nome é {this.Nome} e tenho {this.Idade}.");
        }
    }
}