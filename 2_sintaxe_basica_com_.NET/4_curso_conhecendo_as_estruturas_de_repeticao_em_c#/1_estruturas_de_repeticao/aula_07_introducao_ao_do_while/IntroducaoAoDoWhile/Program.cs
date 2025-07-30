int soma = 0;
int numero = 5;
int contador = 0;

do
{
    soma = numero + contador;
    Console.WriteLine($"{numero} x {contador} = {soma}");
    contador++;
} while (contador <= 10);