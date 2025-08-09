using ExemploTestandoNossoMetodo;

LeituraArquivo arquivo = new LeituraArquivo();
(bool sucesso, string[] linhas, int quantidade) = arquivo.LerArquivo("Arquivos/arquivoLeitura.txt");

if (sucesso)
{
    Console.WriteLine($"Quantidade de linhas: {quantidade}");
    foreach (string linha in linhas)
    {
        Console.WriteLine(linha);
    }
}
else
{
    Console.WriteLine("Não foi possível ler o arquivo!");
}

