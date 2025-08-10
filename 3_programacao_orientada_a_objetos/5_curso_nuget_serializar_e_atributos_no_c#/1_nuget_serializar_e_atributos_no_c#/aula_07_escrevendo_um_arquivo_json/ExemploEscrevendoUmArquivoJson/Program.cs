using ExemploEscrevendoUmArquivoJson;
using Newtonsoft.Json;

Venda venda = new Venda(id: 1, produto: "Borracha", preco: 1.90M);

string vendaJson = JsonConvert.SerializeObject(venda, Formatting.Indented);

File.WriteAllText("Arquivos/vendas.json", vendaJson);

Console.WriteLine(vendaJson);