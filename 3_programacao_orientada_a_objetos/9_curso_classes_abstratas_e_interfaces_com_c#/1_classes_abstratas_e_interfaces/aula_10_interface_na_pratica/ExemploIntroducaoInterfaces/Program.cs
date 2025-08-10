using ExemploIntroducaoInterfaces;

ICalculadora calculadoraComum = new CalculadoraComum();
calculadoraComum.Somar(2, 5);

Console.WriteLine();

ICalculadora calculadoraCientifica = new CalculadoraCientifica();
calculadoraCientifica.Multiplicar(5, 5);