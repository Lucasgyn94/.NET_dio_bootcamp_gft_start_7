
using ExemploDescartes;

LeituraArquivo arquivo = new LeituraArquivo();
//(bool sucesso, string[] linhas, int quantidade) = arquivo.LerArquivo("Arquivos/arquivoLeitura.txt");
var (sucesso, linhasArquivo, _) = arquivo.LerArquivo("Arquivos/arquivoLeitura.txt");

if (sucesso)
{
    //Console.WriteLine($"Quantidade de linhas: {quantidadeDeLinhas}");
    foreach (string linha in linhasArquivo)
    {
        Console.WriteLine(linha);
    }
}
else
{
    Console.WriteLine("Não foi possível ler o arquivo!");
}

