int[] arrayDeInteiros = new int[3];
arrayDeInteiros[0] = 5;
arrayDeInteiros[1] = 10;
arrayDeInteiros[2] = 15;

int[] arrayDeInteirosCopia = new int[arrayDeInteiros.Length * 2];
Array.Copy(arrayDeInteiros, arrayDeInteirosCopia, arrayDeInteiros.Length);
Console.WriteLine($"Tamanho do array copia: {arrayDeInteirosCopia.Length}");

int posicao = 0;
foreach (int a in arrayDeInteirosCopia)
{
    Console.WriteLine($"Array na posição {posicao}: {a}");
    posicao++;
}