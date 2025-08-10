
using ExemploDateTimeEmJson;
using Newtonsoft.Json;

DateTime dataHora = DateTime.Now;

List<Venda> listaDeVendas = new List<Venda>();

Venda venda1 = new Venda(id: 1, produto: "Borracha", preco: 1.90M, dataHoraVenda: Convert.ToDateTime(dataHora.ToShortDateString()));

Venda venda2 = new Venda(id: 2, produto: "Caneta", preco: 2.89M, dataHoraVenda: Convert.ToDateTime(dataHora.ToShortTimeString()));

listaDeVendas.Add(venda1);
listaDeVendas.Add(venda2);

string vendasJson = JsonConvert.SerializeObject(listaDeVendas, Formatting.Indented);

File.WriteAllText("Arquivos/vendas.json", vendasJson);

Console.WriteLine(vendasJson);