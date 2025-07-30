using ExemploImplementandoConstrutor.Models;

Pessoa p1 = new Pessoa(nome: "LUCAS", sobrenome: "FERREIRA");
Pessoa p2 = new Pessoa(nome: "TAMPINHA", sobrenome: "FERREIRA");

Curso c1 = new Curso();

c1.AdicionarAluno(p1);
c1.AdicionarAluno(p2);
int quantidadeDeAlunos = c1.ObterQuantidadeDeAlunosMatriculados();
Console.WriteLine($"Quantidade de alunos matriculados: {quantidadeDeAlunos}");
Console.WriteLine();

c1.ListarAlunos();
Console.WriteLine();

c1.RemoverAluno(p1);
c1.ListarAlunos();