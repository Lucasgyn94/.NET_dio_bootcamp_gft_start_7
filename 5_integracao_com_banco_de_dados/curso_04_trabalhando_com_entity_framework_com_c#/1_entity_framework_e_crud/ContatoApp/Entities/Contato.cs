namespace ContatoApp;

public class Contato
{
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Telefone { get; set; } = default!;
    public bool Ativo { get; set; } = default!;
}
