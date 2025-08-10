namespace ExemploClasseAbstrataNaPratica;

public abstract class Conta
{
    protected double _saldo;
    public abstract void Creditar(double valor);

    public void ExibirSaldo()
    {
        Console.WriteLine($"Seu saldo é de: {this._saldo}");
    }
}
