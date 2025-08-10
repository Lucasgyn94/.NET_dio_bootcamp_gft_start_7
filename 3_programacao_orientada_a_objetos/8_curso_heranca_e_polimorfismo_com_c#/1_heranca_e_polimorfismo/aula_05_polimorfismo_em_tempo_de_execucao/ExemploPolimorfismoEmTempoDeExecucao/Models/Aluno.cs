namespace ExemploPolimorfismoEmTempoDeExecucao;

public class Aluno : Pessoa
{
    public double Nota{ get; set; }
    public override void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {this.Nome}. Sou um aluno de nota {this.Nota}");
    }

}
