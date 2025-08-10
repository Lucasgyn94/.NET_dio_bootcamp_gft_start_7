using System.Runtime.Intrinsics.X86;

namespace ExemploIntroducaoInterfaces;

public class CalculadoraComum : ICalculadora
{
    public void Somar(int n1, int n2)
    {
        Console.WriteLine("Calculadora Comum Somando: ");
        int calculo = n1 + n2;
        Console.WriteLine($"{n1} + {n2} = {calculo}");
    }
    public void Subtrair(int n1, int n2)
    {
        Console.WriteLine("Calculadora Comum Subtraindo: ");
        int calculo = n1 - n2;
        Console.WriteLine($"{n1} - {n2} = {calculo}");

    }
    public void Multiplicar(int n1, int n2)
    {
        Console.WriteLine("Calculadora Comum Multiplicando: ");
        int calculo = n1 * n2;
        Console.WriteLine($"{n1} * {n2} = {calculo}");
    }
    public void Dividir(int n1, int n2)
    {
        Console.WriteLine("Calculadora Comum Dividindo: ");
        if (n2 != 0)
        {
            int calculo = n1 / n2;
            Console.WriteLine($"{n1} + {n2} = {calculo}");
        }
        else
        {
            Console.WriteLine($"Não é possível divisão pelo número {n2}");
        }
    }
}
