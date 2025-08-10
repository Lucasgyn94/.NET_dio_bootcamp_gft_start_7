namespace ExemploMetodoSeladoNaPratica;

public class Aluno : Pessoa
{
    public Aluno()
    {
        // construtor vazio
    }
    public Aluno(string nome) : base(nome)
    {
        // metodo construtor por herança
    }

    public double Nota { get; set; }
    public override void Apresentar()
    {
        Console.WriteLine(
            $"Olá, meu nome é {this.Nome} " +
            $"tenho {this.Idade}, " +
            $"e sou aluno nota {this.Nota}"
        );
    }
}
