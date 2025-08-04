Stack<int> carga = new Stack<int>();
carga.Push(100);
carga.Push(90);
carga.Push(80);
carga.Push(70);
carga.Push(60);
carga.Push(50);
carga.Push(40);
carga.Push(30);
carga.Push(20);
carga.Push(10);

foreach (int pique in carga)
{
    Console.WriteLine(pique);
}

Console.WriteLine("REMOVENDO O ELEMENTO DO TOPO: " + carga.Pop());

foreach (int pique in carga)
{
    Console.WriteLine(pique);
}

Console.WriteLine("ADICIONANDO ELEMENTO AO TOPO: ");
carga.Push(15);


foreach (int pique in carga)
{
    Console.WriteLine(pique);
}
