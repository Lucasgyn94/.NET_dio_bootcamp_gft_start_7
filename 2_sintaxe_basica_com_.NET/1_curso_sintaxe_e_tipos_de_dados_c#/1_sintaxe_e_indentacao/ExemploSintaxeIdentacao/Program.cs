using System;
using ExemploSintaxeIdentacao.Models;

namespace ExemploSintaxeIdentacao
{
    class Program
    {
        public static void Main(string[] args)
        {

            Pessoa p1 = new Pessoa();
            p1.Nome = "Lucas";
            p1.Idade = 30;
            p1.Apresentar();    
        
        }
    }
}