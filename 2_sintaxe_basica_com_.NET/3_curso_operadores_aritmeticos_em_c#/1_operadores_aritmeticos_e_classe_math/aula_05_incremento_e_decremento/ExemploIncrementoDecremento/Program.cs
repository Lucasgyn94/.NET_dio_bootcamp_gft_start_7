static void Incremento()
{
    Console.WriteLine("### INCREMENTAÇÃO DE NÚMEROS ###");
    Console.WriteLine("Digite um número para incrementação: ");
    string entradaUsuario = Console.ReadLine();
    int numero = Convert.ToInt32(entradaUsuario);

    numero++;

    Console.WriteLine($"Número incrementado = {numero}"); // numero+=1 (numero = numero + 1)

    Console.WriteLine("#################################");

}

static void Decremento()
{
    Console.WriteLine("### DECREMENTAÇÃO DE NÚMEROS ###");

    Console.WriteLine("Digite um número para decrementação: ");
    string entradaUsuario = Console.ReadLine();
    int numero = Convert.ToInt32(entradaUsuario);

    numero--; // numero-- é o mesmo que: numero = numero - 1;

    Console.WriteLine($"Número decrementado: {numero}"); 
    Console.WriteLine("#################################");
}

Incremento();
Decremento();