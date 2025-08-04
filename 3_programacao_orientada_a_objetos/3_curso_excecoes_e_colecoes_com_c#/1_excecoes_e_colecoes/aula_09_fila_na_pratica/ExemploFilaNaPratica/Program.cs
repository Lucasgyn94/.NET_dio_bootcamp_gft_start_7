Queue<int> fila = new Queue<int>();
fila.Enqueue(2);
fila.Enqueue(4);
fila.Enqueue(5);
fila.Enqueue(6);

foreach (int valor in fila)
{
    Console.WriteLine(valor);
}

Console.WriteLine($"Removendo o valor {fila.Dequeue()}");


foreach (int valor in fila)
{
    Console.WriteLine(valor);
}

Console.WriteLine($"Adicionando valor ao final da fila: ");
fila.Enqueue(10);

foreach (int valor in fila)
{
    Console.WriteLine(valor);
}