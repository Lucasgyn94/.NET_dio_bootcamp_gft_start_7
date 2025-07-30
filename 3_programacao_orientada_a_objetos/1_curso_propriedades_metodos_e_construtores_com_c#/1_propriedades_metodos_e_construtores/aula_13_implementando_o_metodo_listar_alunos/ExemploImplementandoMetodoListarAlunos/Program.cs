

using ExemploImplementandoMetodoListarAlunos.Models;

Pessoa p1 = new Pessoa();
p1.Nome = "LUCAS";
p1.Sobrenome = "FERREIRA";

Pessoa p2 = new Pessoa();
p2.Nome = "TAMPIHA";
p2.Sobrenome = "FERREIRA";


Curso c1 = new Curso();
c1.Nome = "ADS";

//c1.Alunos = new List<Pessoa>(); /*Inicializando a lista de alunos */

c1.AdicionarAluno(p1);
c1.AdicionarAluno(p2);
int quantidadeDeAlunos = c1.ObterQuantidadeDeAlunosMatriculados();
Console.WriteLine($"Quantidade de alunos matriculados: {quantidadeDeAlunos}");
c1.ListarAlunos();