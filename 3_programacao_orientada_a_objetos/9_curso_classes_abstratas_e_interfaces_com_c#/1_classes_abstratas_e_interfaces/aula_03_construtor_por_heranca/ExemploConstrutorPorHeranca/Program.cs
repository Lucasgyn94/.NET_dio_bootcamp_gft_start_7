using ExemploConstrutorPorHeranca;

Pessoa p1 = new Pessoa();
p1.Nome = "Lucas Ferreira";
p1.Idade = 30;
p1.Apresentar();

Console.WriteLine();

Aluno a1 = new Aluno();
a1.Nome = "Lucas Ferreira";
a1.Idade = 30;
a1.Nota = 10;
a1.Apresentar();

Console.WriteLine();

Professor prof1 = new Professor();
prof1.Nome = "Lucas Ferreira";
prof1.Idade = 30;
prof1.Salario = 2000;
prof1.Apresentar();