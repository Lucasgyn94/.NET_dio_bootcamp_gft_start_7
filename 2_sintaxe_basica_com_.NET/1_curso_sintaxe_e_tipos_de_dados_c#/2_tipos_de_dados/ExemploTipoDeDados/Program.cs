using System;

namespace ExemploTipoDeDados
{
    class Program
    {
        public static void Main(string[] args)
        {

            /*DECLARANDO OS TIPOS DE VARIÁVEIS */

            // string apresentacao = "Olá, sejam todos bem-vindos ao curso GFT 7 Start com .NET";
            // int quantidade = 1;
            // double altura = 1.80;
            // decimal preco = 1.50M;
            // Boolean condicao = true;

            // Console.WriteLine(apresentacao);
            // Console.WriteLine($"Quantidade: {quantidade} unidade.");
            // Console.WriteLine($"Altura: {altura.ToString("0.00")}");
            // Console.WriteLine($"Preço: {preco}");
            // Console.WriteLine($"Condição: {condicao}");

            /*MANIPULANDO VARIÁVEIS */

            // int quantidade = 1;
            // Console.WriteLine($"Quantidade: {quantidade} unidade.");

            // quantidade = 10;
            // Console.WriteLine($"Quantidade: {quantidade} unidade.");

            /*O TIPO DATETIME*/

            DateTime dataAtual = DateTime.Now;
            Console.WriteLine(dataAtual);

            /*ADICIONANDO DIAS */
            dataAtual = DateTime.Now.AddDays(5);
            Console.WriteLine(dataAtual.ToString("MM/dd/yyyy HH:mm"));

        }
    }
}