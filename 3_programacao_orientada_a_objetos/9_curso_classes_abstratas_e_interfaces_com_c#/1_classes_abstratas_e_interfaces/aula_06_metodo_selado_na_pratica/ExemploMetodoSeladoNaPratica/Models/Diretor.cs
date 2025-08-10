namespace ExemploMetodoSeladoNaPratica;

public class Diretor : Professor
{

    // erro: "Diretor.Apresentar()": não é possível substituir o membro herdado "Professor.Apresentar()" porque ele é sealed
    // public override void Apresentar()
    // {
            //Console.WriteLine("Diretor");

    // }
}
