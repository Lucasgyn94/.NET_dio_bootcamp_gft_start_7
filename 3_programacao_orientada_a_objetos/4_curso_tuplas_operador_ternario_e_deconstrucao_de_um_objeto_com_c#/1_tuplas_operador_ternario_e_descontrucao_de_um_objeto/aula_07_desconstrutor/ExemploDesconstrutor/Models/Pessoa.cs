namespace ExemploDesconstrutor;

public class Pessoa
{

    public Pessoa(string nome, string sobrenome)
    {
        this.Nome = nome;
        this.Sobrenome = sobrenome;
    }

    public void Deconstruct(out string nome,  out string sobrenome)
    {
        nome = this.Nome;
        sobrenome = this.Sobrenome;
    }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public string NomeCompleto => this.Nome + " " + this.Sobrenome;

    public void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {this.NomeCompleto}");
    }

}
