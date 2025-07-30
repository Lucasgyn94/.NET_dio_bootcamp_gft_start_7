using System.Runtime.Intrinsics.X86;

namespace ExemploOrganizandoEReferenciandoProjetos.Common.Models
{
    public class Calculadora
    {
        public int Somar(int n1, int n2)
        {
            return n1 + n2;
        }
        public int Subtrair(int n1, int n2)
        {
            return n1 - n2;
        }
        public int Multiplicar(int n1, int n2)
        {
            return n1 * n2;
        }
        public int Dividir(int n1, int n2)
        {
            return n1 / n2;
        }
    }
}