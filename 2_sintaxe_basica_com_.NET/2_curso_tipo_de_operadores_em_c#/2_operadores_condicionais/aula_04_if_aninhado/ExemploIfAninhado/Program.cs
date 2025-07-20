int quantidadeEstoque = 10;

Console.WriteLine("Digite a quantidade desejada do produto: ");
string leituraUsuario = Console.ReadLine();

int quantidadeEscolhidaUsuario = Convert.ToInt32(leituraUsuario);
bool possivelVenda = quantidadeEscolhidaUsuario > 0 && quantidadeEscolhidaUsuario <= quantidadeEstoque ;

Console.WriteLine($"Quantidade em estoque: {quantidadeEstoque}.");
Console.WriteLine($"Quantidade escolhida usuário: {quantidadeEscolhidaUsuario}.");
Console.WriteLine($"É possível realizar a venda? {possivelVenda}");

if (quantidadeEscolhidaUsuario <= 0)
{
    Console.WriteLine("Venda inválida!");
} else if (possivelVenda)
{
    Console.WriteLine($"Venda realizada com sucesso!");
} else
{
    Console.WriteLine($"Venda não realizada.\n" +
    $"Quantidade escolhida {quantidadeEscolhidaUsuario}" + "\n" +
    $"Quantidade em estoque {quantidadeEstoque}"
    );
}
