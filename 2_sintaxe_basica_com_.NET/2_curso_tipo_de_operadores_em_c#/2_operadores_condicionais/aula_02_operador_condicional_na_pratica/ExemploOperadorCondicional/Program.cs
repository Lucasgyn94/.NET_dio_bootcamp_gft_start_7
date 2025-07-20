int quantidadeEstoque = 10;

Console.WriteLine($"Quantidade em estoque: {quantidadeEstoque}.");

Console.WriteLine("Digite a quantidade desejada do produto: ");
string leituraUsuario = Console.ReadLine();
int quantidadeEscolhidaUsuario = Convert.ToInt32(leituraUsuario);

Console.WriteLine($"Quantidade escolhida usuário: {quantidadeEscolhidaUsuario}.");

bool possivelVenda = quantidadeEscolhidaUsuario <= quantidadeEstoque ;

Console.WriteLine($"É possível realizar a venda? {possivelVenda}");

if (possivelVenda)
{
    Console.WriteLine($"Venda realizada com sucesso!");
}
else
{
    Console.WriteLine($"Venda não realizada.\n" +
    $"Quantidade escolhida {quantidadeEscolhidaUsuario}" + "\n" +
    $"Quantidade em estoque {quantidadeEstoque}"
    );
}
