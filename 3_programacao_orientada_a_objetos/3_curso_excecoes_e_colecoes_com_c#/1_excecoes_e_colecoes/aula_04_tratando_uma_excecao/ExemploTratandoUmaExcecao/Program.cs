// string[] linhasExemplo = File.ReadAllLines("Arquivos/arq1uivoLeitura.txt");
// Console.WriteLine("Chegou até aqui");

try
{
    string[] linhas = File.ReadAllLines("Arquivos/arquiivoLeitura.txt");

    foreach (string linha in linhas)
    {
        Console.WriteLine($"{linha}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu uma exceção genérica: {ex.Message}");
}

Console.WriteLine("Chegou até aqui");
