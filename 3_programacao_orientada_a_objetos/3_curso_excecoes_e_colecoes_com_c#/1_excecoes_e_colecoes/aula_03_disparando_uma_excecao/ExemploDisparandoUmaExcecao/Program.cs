// disparando uma exceção colocando o nome do arquivo.txt errado
string[] linhas = File.ReadAllLines("Arquivos/arquivos_Lesitura.txt");

foreach (string linha in linhas)
{
    Console.WriteLine(linha);
}