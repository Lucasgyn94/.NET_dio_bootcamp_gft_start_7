using System;

namespace ExemploRedimensionandoUmArray {
    class Program
    {
        static void PercorreArrayComFor(int[] array)
        {
            Console.WriteLine("Percorrendo array com for");
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Array na posição {i}: {array[i]}");
            }
        }

        static void PercorreArrayComForeach(int[] array)
        {
            Console.WriteLine("Percorrendo array com foreach");
            Console.WriteLine();
            int posicao = 0;
            foreach (int a in array)
            {
                Console.WriteLine($"Array na posição {posicao}: {a}");
                posicao++;
            }
        }


        public static void Main(string[] args)
        {

            int[] arrayDeInteiros = new int[3];
            arrayDeInteiros[0] = 5;
            arrayDeInteiros[1] = 10;
            arrayDeInteiros[2] = 15;

            Console.WriteLine($"Tamanho do array: {arrayDeInteiros.Length}");
            Console.WriteLine();

            Array.Resize(ref arrayDeInteiros, arrayDeInteiros.Length * 2);
            Console.WriteLine($"Tamanho do array após redimensionamento: {arrayDeInteiros.Length}");
        }
    }
}

