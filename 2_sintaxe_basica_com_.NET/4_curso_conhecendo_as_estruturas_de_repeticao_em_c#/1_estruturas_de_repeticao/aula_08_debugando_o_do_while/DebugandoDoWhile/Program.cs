int numero = 0, soma = 0;

do
{
    Console.WriteLine($"Digite um número para somar ou 0 para sair.");
    string entradaUsuario = Console.ReadLine();
    numero = Convert.ToInt32(entradaUsuario);
    soma += numero;

} while (numero != 0);

Console.WriteLine($"Soma dos números digitados: {soma}");