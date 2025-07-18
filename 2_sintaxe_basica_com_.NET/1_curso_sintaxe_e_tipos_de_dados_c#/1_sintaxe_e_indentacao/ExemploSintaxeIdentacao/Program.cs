using System;
using ExemploSintaxeIdentacao.Models;

namespace ExemploSintaxeIdentacao
{
    class Program
    {
        public static void Main(string[] args)
        {

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Lucas";
            pessoa.Idade = 30;
            pessoa.Apresentar();

        
        }
    }
}