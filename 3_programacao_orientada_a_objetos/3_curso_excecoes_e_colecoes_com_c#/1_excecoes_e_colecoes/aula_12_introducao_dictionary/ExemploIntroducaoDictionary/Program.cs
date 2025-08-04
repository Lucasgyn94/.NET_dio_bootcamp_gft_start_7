Dictionary<string, string> estados = new Dictionary<string, string>();

estados.Add("GO", "Goiás");
estados.Add("SP", "São Paulo");
estados.Add("RJ", "Rio de Janeiro");
estados.Add("BA", "Bahia");

foreach (KeyValuePair<string, string> item in estados)
{
    Console.WriteLine($"Chave: {item.Key} - Valor: {item.Value}");
}