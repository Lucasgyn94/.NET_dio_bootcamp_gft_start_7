using ExemploDeserializandoUmObjeto;
using Newtonsoft.Json;

string conteudoArquivo = File.ReadAllText("Arquivos/vendas.json");

List<Venda> listaDeVendas = JsonConvert.DeserializeObject<List<Venda>>(conteudoArquivo);

foreach (Venda v in listaDeVendas)
{
    Console.WriteLine(
        $"Id: {v.Id}" + " - " +
        $"Produto: {v.Produto}" + " - " +
        $"Preço: {v.Preco}" + " - " +
        $"DataHora: {v.DataHoraVenda}"
    );
}