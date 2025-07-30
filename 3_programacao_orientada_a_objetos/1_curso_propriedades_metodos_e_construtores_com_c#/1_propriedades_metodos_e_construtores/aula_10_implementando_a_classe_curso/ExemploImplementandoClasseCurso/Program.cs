using ExemploImplementandoClasseCurso.Models;

Pessoa p1 = new Pessoa();
p1.Nome = "Lucas";
p1.Idade = 30;

Curso c1 = new Curso();
c1.Nome = "ADS";
c1.AdicionarAluno(p1);
