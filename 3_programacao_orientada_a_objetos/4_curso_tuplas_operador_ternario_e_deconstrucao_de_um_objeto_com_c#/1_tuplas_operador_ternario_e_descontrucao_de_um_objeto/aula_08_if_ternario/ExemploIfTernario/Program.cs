Console.WriteLine("Digite um número para saber se par ou ímpar.");
string entradaUsuario = Console.ReadLine();

int numero = Convert.ToInt32(entradaUsuario);

bool ehPar = false;

ehPar = numero % 2 == 0;

Console.WriteLine($"O número {numero} é " + (ehPar ? "par": "ímpar"));