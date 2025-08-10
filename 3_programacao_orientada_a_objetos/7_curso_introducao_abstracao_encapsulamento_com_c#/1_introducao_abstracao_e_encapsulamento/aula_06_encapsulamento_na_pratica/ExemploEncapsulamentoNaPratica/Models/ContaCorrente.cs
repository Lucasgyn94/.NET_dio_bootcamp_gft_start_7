using System.Text;

namespace ExemploEncapsulamentoNaPratica;

public class ContaCorrente
{
    public int Numero;
    private decimal _saldo;

    public ContaCorrente(int numero, decimal saldo)
    {
        this.Numero = numero;
        this._saldo = saldo;

    }


    public void Sacar(decimal valor)
    {
        if (this._saldo >= valor)
        {
            this._saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine($"Você não tem {valor} disponível em conta.\nSaldo: {this._saldo}");
        }
    }
    public void MostrarSaldo()
    {
        Console.WriteLine($"Seu saldo atual é de: {this._saldo}");
    }

}
