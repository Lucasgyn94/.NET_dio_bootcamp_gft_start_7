using ExemploDesconstrutor;

Pessoa p1 = new Pessoa("Lucas", "Ferreira");
//Console.WriteLine($"Nome pessoa: {p1.NomeCompleto}");

// deconstrução
(string nome, string sobrenome) = p1;
Console.WriteLine($"Nome: {nome}\nSobrenome: {sobrenome}");