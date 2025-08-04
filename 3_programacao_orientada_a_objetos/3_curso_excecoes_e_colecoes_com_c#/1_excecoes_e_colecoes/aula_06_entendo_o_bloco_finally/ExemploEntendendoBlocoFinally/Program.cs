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
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Ocorreu um erro na leitura do arquivo. Arquivo não encontrado! {ex.Message}");
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"Ocorreu um erro na leitura do arquivo. Caminho da pasta não encontrado! {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu uma exceção genérica: {ex.Message}");
}
finally
{
    Console.WriteLine("Chegou até aqui");
}