namespace ExemploDateTimeEmJson;

public class Venda
{
    public Venda(int id, string produto, decimal preco, DateTime dataHoraVenda)
    {
        this.Id = id;
        this.Produto = produto;
        this.Preco = preco;
        this.DataHoraVenda = dataHoraVenda;
    }
    public int Id { get; set; }
    public string Produto { get; set; }
    public decimal Preco { get; set; }

    public DateTime DataHoraVenda{ get; set; }

}
