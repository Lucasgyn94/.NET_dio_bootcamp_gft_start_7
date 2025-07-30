namespace ExemploOrganizandoEReferenciandoProjetos.Common.Models
{
    public class Pessoa
    {
        public string Nome { get; set; } = "";
        public int Idade { get; set; } = 0;

        public void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {this.Nome} e tenho {this.Idade}");
        }
        
    }
}