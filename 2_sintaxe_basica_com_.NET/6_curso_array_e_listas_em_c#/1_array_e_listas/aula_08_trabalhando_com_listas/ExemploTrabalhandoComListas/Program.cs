List<string> estados = new List<string>();
estados.Add("GO");
estados.Add("SP");
estados.Add("RJ");
estados.Add("BA");

Console.WriteLine($"Quantidade de itens na lista: {estados.Count}\n" +
$"Capacidade da lista: {estados.Capacity}");

Console.WriteLine("\nAdicionando mais um estado");
estados.Add("MG");
Console.WriteLine($"Quantidade de itens na lista: {estados.Count}\n" +
$"Capacidade da lista: {estados.Capacity}");

Console.WriteLine("\nRemovendo um estado");
estados.Remove("SP");
Console.WriteLine($"Quantidade de itens na lista: {estados.Count}\n" +
$"Capacidade da lista: {estados.Capacity}");

Console.WriteLine("\nImpressão dos estados atual:");
estados.ForEach(e => Console.WriteLine(e));

Console.WriteLine("\nPercorrendo a lista com for:");
for (int i = 0; i < estados.Count; i++)
{
    Console.WriteLine($"{estados[i]}");
    
}

Console.WriteLine("\nPercorrendo a lista com foreach:");
foreach (string i in estados)
{
    Console.WriteLine($"{i}");
    
}
