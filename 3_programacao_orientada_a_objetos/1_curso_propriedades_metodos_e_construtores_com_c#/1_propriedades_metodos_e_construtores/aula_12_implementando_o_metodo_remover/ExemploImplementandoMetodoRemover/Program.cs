using ExemploImplementandoMetodoRemover.Models;

Pessoa p1 = new Pessoa();
p1.Nome = "LUCAS";
p1.Idade = 30;


Curso c1 = new Curso();
c1.Nome = "ADS";
c1.AdicionarAluno(p1);
int quantidadeDeAlunos = c1.ObterQuantidadeDeAlunosMatriculados();
Console.WriteLine($"Quantidade de alunos matriculados: {quantidadeDeAlunos}");
