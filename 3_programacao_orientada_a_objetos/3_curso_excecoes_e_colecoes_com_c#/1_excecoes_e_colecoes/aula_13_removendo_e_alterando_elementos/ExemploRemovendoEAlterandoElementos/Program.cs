Dictionary<string, string> estados = new Dictionary<string, string>();

estados.Add("GO", "Goiás");
estados.Add("SP", "São Paulo");
estados.Add("RJ", "Rio de Janeiro");
estados.Add("BA", "Bahia");

foreach (KeyValuePair<string, string> item in estados)
{
    Console.WriteLine($"Chave: {item.Key} - Valor: {item.Value}");
}

// removendo valores
Console.WriteLine("----------------------");
estados.Remove("BA");

foreach (KeyValuePair<string, string> item in estados)
{
    Console.WriteLine($"Chave: {item.Key} - Valor: {item.Value}");
}

// atualizando valores
Console.WriteLine("----------------------");
estados["GO"] = "Goias - atualizado";

foreach (KeyValuePair<string, string> item in estados)
{
    Console.WriteLine($"Chave: {item.Key} - Valor: {item.Value}");
}

// verificando se a chave existe
Console.WriteLine("----------------------");
string chave = "BA";

if (estados.ContainsKey(chave))
{
    Console.WriteLine($"Não é seguro adicionar a chave {chave}. Já existente");
}
else
{
    Console.WriteLine($"É seguro adicionar a chave {chave}.");
}

// OBTENDO VALOR DE UMA CHAVE
Console.WriteLine("----------------------");
Console.WriteLine(estados["GO"]);