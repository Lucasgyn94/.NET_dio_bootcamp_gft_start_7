string[] linhas = File.ReadAllLines("Arquivos/arquivosLeitura.txt");

foreach (string linha in linhas)
{
    Console.WriteLine(linha);
}