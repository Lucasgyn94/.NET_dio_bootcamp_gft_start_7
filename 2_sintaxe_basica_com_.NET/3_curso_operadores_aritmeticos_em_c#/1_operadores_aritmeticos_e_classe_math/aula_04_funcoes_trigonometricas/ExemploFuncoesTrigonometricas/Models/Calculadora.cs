using System;

namespace ExemploFuncoesTrigonometricas.Models
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

        /*FUNÇÕES TRIGONOMÉTRICAS: SENO, COSSENO, TANGENTE */

        public double ConverteAnguloEmGrausEmRadiano(double anguloEmGraus)
        {
            double anguloEmGrausConvertidoEmRadianos = anguloEmGraus * Math.PI / 180;
            return anguloEmGrausConvertidoEmRadianos;
            
        }
        public void Seno(double anguloEmGraus)
        {
            double anguloConvertidoEmRadianos = ConverteAnguloEmGrausEmRadiano(anguloEmGraus);
            
            double seno = Math.Sin(anguloConvertidoEmRadianos);
            Console.WriteLine($"Seno de {anguloEmGraus}º = {Math.Round(seno, 4)}");
        }

        public void Cosseno(double anguloEmGraus)
        {
            double anguloConvertidoEmRadianos = ConverteAnguloEmGrausEmRadiano(anguloEmGraus);

            double cosseno = Math.Cos(anguloConvertidoEmRadianos);
            Math.Round(cosseno);
            Console.WriteLine($"Cosseno de {anguloEmGraus}º = {Math.Round(cosseno, 4)}");
        }

        public void Tangente(double anguloEmGraus)
        {
            double anguloConvertidoEmRadianos = ConverteAnguloEmGrausEmRadiano(anguloEmGraus);
            double tangente = Math.Tan(anguloConvertidoEmRadianos);

            Console.WriteLine($"Tangente de {anguloEmGraus}º = {Math.Round(tangente, 4)}");
        }

    }
}