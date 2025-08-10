namespace ExemploPolimorfismoEmTempoDeExecucao;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    // Ao colocar o método como virtual, estamos dizendo que esse método pode ser sobreescrito pela classe herdante
    public virtual void Apresentar()
    {
        Console.WriteLine(
            $"Olá, meu nome é {this.Nome} e tenho {this.Idade}");
    }
}
