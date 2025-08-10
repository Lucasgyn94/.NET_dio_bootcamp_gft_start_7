namespace ExemploConstrutorPorHeranca;

public class Professor : Pessoa
{
    public Professor()
    {
        // construtor vazio
    }

    public Professor(string nome) : base(nome)
    {
        // metodo construtor por herança    
    }

    public decimal Salario { get; set; }
    public override void Apresentar()
    {
        Console.WriteLine(
            $"Olá, meu nome é {this.Nome} " +
            $"tenho {this.Idade}, " +
            $"sou professor e ganho salário de R$ {this.Salario}"
        );
    }

}
