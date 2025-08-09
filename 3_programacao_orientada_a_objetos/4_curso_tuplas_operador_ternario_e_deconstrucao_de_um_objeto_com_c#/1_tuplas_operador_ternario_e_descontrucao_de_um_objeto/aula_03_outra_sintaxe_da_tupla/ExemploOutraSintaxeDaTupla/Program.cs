/*
OBS: A MELHOR FORMA DE SE CRIAR UMA TUPLA E DA FORMA 01.
 */
void ExemploTuplaForma01()
{
    (int, string, string, decimal) tupla = (1, "Lucas", "Ferreira", 1.78M);
    Console.WriteLine(tupla);

    Console.WriteLine();

    Console.WriteLine(tupla.Item1);
    Console.WriteLine(tupla.Item2);
    Console.WriteLine(tupla.Item3);
    Console.WriteLine(tupla.Item4);
}

void ExemploTuplaForma02()
{
    ValueTuple<int, string, string, decimal> tupla = (1, "Lucas", "Ferreira", 1.78M);
    Console.WriteLine(tupla);

    Console.WriteLine();

    Console.WriteLine(tupla.Item1);
    Console.WriteLine(tupla.Item2);
    Console.WriteLine(tupla.Item3);
    Console.WriteLine(tupla.Item4);
}

// A principal vantagem em relação a forma 03 com as demais e que nessa não há necessidade de 
// declarar o tipo, pois o mesmo e reconhecido automaticamente.

void ExemploTuplaForma03()
{
    var tupla = Tuple.Create(1, "Lucas", "Ferreira", 1.78M);
    Console.WriteLine();

    Console.WriteLine(tupla.Item1);
    Console.WriteLine(tupla.Item2);
    Console.WriteLine(tupla.Item3);
    Console.WriteLine(tupla.Item4);

}