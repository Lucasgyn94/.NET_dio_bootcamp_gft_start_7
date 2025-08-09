Console.WriteLine("Dados pessoais: ");
(int, string, string, decimal) tupla = (1, "LUCAS", "FERREIRA DA SILVA", Convert.ToDecimal(1.78));
Console.WriteLine(tupla);

Console.WriteLine();
Console.WriteLine("Dados pessoais por item:");
Console.WriteLine(tupla.Item1);
Console.WriteLine(tupla.Item2);
Console.WriteLine(tupla.Item3);
Console.WriteLine(tupla.Item4);
