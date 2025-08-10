namespace ExemploMetodoPadraoNaInterface;

public interface ICalculadora
{
    void Somar(int n1, int n2);
    void Subtrair(int n1, int n2);
    void Multiplicar(int n1, int n2);
    // Para que um método seja padrão, e não obrigatório em uma interface,
    // podemos colocar um corpo para ele. Métodos que não possuem corpo são
    // obrigatórios enquanto métodos que possuem corpo não são obrigatórios.
    void Dividir(int n1, int n2)
    {
        Console.WriteLine($"{n1} / {n2} = {n1/n2}");
    }
    
}
