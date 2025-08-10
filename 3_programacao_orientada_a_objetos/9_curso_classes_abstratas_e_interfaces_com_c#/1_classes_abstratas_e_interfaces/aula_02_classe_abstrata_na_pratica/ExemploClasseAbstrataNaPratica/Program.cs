using ExemploClasseAbstrataNaPratica;

Corrente contaCorrente1 = new Corrente();
contaCorrente1.ExibirSaldo();

Console.WriteLine();

contaCorrente1.Creditar(5);
contaCorrente1.ExibirSaldo();