using Newtonsoft.Json;

namespace ExemploAtributos;

public class Venda
{
    public int Id { get; set; }

    [JsonProperty("Nome_Produto")]
    public string Produto { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public DateTime DataHoraVenda{ get; set; }
}
