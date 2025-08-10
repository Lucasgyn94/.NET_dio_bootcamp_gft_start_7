namespace ExemploDeserializandoUmObjeto;

public class Venda
{
    public int Id { get; set; }
    public string Produto { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public DateTime DataHoraVenda{ get; set; }
}
