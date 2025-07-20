using System;

namespace ExemploUsandoPotencia.Models
{
    class Calculadora
    {
        public Calculadora()
        {
            // metodo construtor vazio - padrão mesmo se não colocar
        }
        public void Somar(int n1, int n2)
        {
            int soma = n1 + n2;
            Console.WriteLine($"{n1} + {n2} = {soma}");
        }

        public void Subtrair(int n1, int n2)
        {
            int subtracao = n1 - n2;
            Console.WriteLine($"{n1} + {n2} = {subtracao}");
        }

        public void Multiplicar(int n1, int n2)
        {
            int multiplicacao = n1 + n2;
            Console.WriteLine($"{n1} * {n2} = {multiplicacao}");
        }

        public void Dividir(int n1, int n2)
        {

            if (n2 == 0)
            {
                Console.WriteLine("Não é possível divisão por zero.");
            }
            else
            {
                int divisao = n1 / n2;
                Console.WriteLine($"{n1} / {n2} = {divisao}");
            }
        }

        public void Potencia(int n1, int n2)
        {
            /*int potencia = Convert.ToInt32(Math.Pow(n1, n2));*/
            double potencia = Math.Pow(n1, n2);
            Console.WriteLine($"{n1} ^ {n2} = {potencia}");
        }


    }
}