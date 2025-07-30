int[] arrayDeInteiros = new int[3];
arrayDeInteiros[0] = 5;
arrayDeInteiros[1] = 10;
arrayDeInteiros[2] = 15;

Console.WriteLine($"Tamanho do array: {arrayDeInteiros.Length}");

for (int i = 0; i < arrayDeInteiros.Length; i++)
{
    Console.WriteLine($"Posição nº {i} - {arrayDeInteiros[i]}");
}