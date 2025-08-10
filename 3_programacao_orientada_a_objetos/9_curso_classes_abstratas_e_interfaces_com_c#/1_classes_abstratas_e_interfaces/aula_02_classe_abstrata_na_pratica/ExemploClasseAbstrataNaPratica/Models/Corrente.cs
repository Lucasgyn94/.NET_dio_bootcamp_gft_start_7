namespace ExemploClasseAbstrataNaPratica;

public class Corrente : Conta
{
    private double _tarifa = 10.00;

    public override void Creditar(double valor)
    {
        if (valor > 0 && valor > 10)
        {
            double tarifa = valor * _tarifa / 100;
            this._saldo += valor - tarifa;
            Console.WriteLine($"Valor de R$ {valor} depositado com sucesso com tarifa de {tarifa}%");
        }
        else if (valor > 0)
        {
            this._saldo += valor;
            Console.WriteLine($"Valor de R$ {valor} depositado com sucesso!");
        }
        
    }
 
}
