int numero = 5;
int contador = 0;

while (contador <= 10)
{
    int calculo = numero * contador;
    Console.WriteLine($"{numero} x {contador} = {calculo}");
    contador++;
}