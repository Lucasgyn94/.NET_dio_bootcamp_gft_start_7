namespace ExemploClasseSeladaNaPratica;

public class Pessoa
{
    public Pessoa() {
        //construtor vazio
    }

    public Pessoa(string nome)
    {
        this.Nome = nome;
    }
    public string Nome { get; set; }
    public int Idade { get; set; }

    public virtual void Apresentar()
    {
        Console.WriteLine(
            $"Olá, meu nome é {this.Nome} " +
            $"e tenho {this.Idade}, "
        );
    }
}
