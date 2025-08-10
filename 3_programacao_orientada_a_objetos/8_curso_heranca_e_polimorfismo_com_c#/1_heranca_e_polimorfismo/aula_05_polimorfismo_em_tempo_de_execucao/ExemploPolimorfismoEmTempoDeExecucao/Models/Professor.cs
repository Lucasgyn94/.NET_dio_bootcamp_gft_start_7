namespace ExemploPolimorfismoEmTempoDeExecucao;

public class Professor : Pessoa
{
    public decimal Salario{ get; set; }

    public override void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {this.Nome}. Sou um professor, ganho um salário de R$ {this.Salario}");
    }
}
