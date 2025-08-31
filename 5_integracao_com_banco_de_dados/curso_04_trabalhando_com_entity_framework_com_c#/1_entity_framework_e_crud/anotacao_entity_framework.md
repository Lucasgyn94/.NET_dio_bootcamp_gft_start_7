
## AULA 01 - Introdução
* O EF é um framework ORM (Object-Relational Mapping) criado para facilitar a integração com o banco de dados, mapeando tabelas e gerando comando SQL de forma automática.

## AULA 02 - ENTENDENDO O CRUD
C - CREATE  (Insert)
R - READE   (Select)
U - UPDATE  (Update)
D - DELETE  (Delete)

* Vamos criar um CRUD para armazenamento de contatos. A nossa classe se chamará __Contatos__ e os atributos da mesma são:
```
-----------------
class Contatos
-----------------
+ Id: int
+ Nome: string
+ Telefone: string
+ Ativo: bool

```

## AULA 03 - INSTALANDO PACOTES
* Vamos instalar o Entity Framework globalmente em nosso sistema, caso já tenhamos instalado antes, não é necessário fazer novamente:
```
dotnet tool install --global dotnet-ef
```

* Após instalação do EF, podemos instalar alguns pacotes necessários para o nosso projeto. São eles:
1. Microsoft.EntityFrameworkCore.Design
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

2. Microsoft.EntityFrameworkCore.SqlServer
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

