using System;
using System.Security.Cryptography.X509Certificates;

namespace ExemploIntroducaoFor
{
    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("### tabuada ###");
            Console.WriteLine("Qual operação matemática deseja fazer: " +
            "adição (+), subtração (-), multiplicação (*) ou divisão(/)?");
            string entradaUsuario = Console.ReadLine();
            string operacao = entradaUsuario.Trim().ToLower().Substring(0, 1);

            Console.WriteLine("De qual número deseja ver a tabuada? ");
            entradaUsuario = Console.ReadLine();
            int numero = Convert.ToInt32(entradaUsuario);

            switch (operacao)
            {
                case "a":
                case "+":
                    Console.Write($"Você escolheu adição do número: {numero}");
                    Console.WriteLine();

                    for (int i = 1; i <= 10; i++)
                    {
                        int calculo = numero + i;
                        Console.WriteLine($"{numero} + {i} = {calculo}.");
                    }
                    break;
                case "s":
                case "-":
                    Console.Write($"Você escolheu subtração do número: {numero}");
                    Console.WriteLine();
                    for (int i = 1; i <= 10; i++)
                    {
                        int calculo = numero - i;
                        Console.WriteLine($"{numero} - {i} = {calculo}.");
                    }
                    break;
                case "m":
                case "*":
                    Console.Write($"Você escolheu multiplicação do número: {numero}");
                    Console.WriteLine();

                    for (int i = 1; i <= 10; i++)
                    {
                        int calculo = numero * i;
                        Console.WriteLine($"{numero} * {i} = {calculo}.");
                    }
                    break;
                case "d":
                case "/":
                    Console.Write($"Você escolheu divisão do número: {numero}");
                    Console.WriteLine();

                    if (numero == 0)
                    {
                        throw new Exception("Não é possível divisão por zero.");
                        
                    }

                    double numeroConvertidoToDouble = Convert.ToDouble(numero);

                    for (double i = 1; i <= 10; i++)
                    {
                        double calculo = numeroConvertidoToDouble / i;
                        
                        Console.WriteLine($"{numero} / {i} = {calculo.ToString("0.00")}.");
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;

            }
        }
    }
}