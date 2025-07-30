

using ExemploModificadoresDeAcesso.Models;

Pessoa p1 = new Pessoa();
p1.Nome = "Lucas";
p1.Idade = 30;
p1._nome = "Tampinha"; /*Tentando acessar propriedade privada */
p1.Apresentar();