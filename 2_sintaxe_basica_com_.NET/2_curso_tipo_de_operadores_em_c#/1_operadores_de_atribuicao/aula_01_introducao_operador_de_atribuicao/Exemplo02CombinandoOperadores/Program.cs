using System;

namespace Exemplo02CombinandoOperadores
{
    class Program
    {
        public static void Main(string[] args)
        {
            int a = 10;
            int b = 5;

            int c = a + b;

            Console.WriteLine(c += a);

        }
    }
}