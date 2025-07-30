int[] arrayDeInteiros = new int[3];
arrayDeInteiros[0] = 5;
arrayDeInteiros[1] = 10;
arrayDeInteiros[2] = 15;

Console.WriteLine($"Tamanho do array: {arrayDeInteiros.Length}");

int posicao = 0;
foreach (int a in arrayDeInteiros)
{
    Console.WriteLine($"Array na posição {posicao}: {a}");
    posicao++;
}