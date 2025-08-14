# LISTA DE FRAMEWORKS UTILIZADOS NO PROJETO
## Lista de frameworks
- EntityFrameworkCore
- EntityFrameworkCore.Design
- EntityFrameworkCore.Tools
- Pomelo.EntityFrameworkCore.MySql

* Todos podem ser encontrado o link para baixar no site oficial: nuget.org

## Arquitetura utilizada
* União da Clean Archicture
* Union Archicture 

## Site para gerar ignore git
* Digitamos no google.com.br: "git ignore io" e então acessamos o site: 
```
https://www.toptal.com/developers/gitignore
```

* Selecionamos as opções:
  - Windows
  - Linux
  - macOS
  - DotnetCore
  - VisualStudioCode
  
## Criando uma Migration
* Após a configuração do banco de dados e instanciamento do serviço no Program.cs estamos pronto para criar a migration, podemos fazer isso com o comando:
```
dotnet ef migrations add AdministradorMigration
```
* Após a criação da migration contendo os dados para criação do banco de dados devemos rodar o comando a seguir para consumação:
```
dotnet ef database update
```

* Após criar um seed de administrador (função para criar nosso administrador no bando de dados), devemos rodar a migration novamente com o comando:
```
dotnet ef migrations add SeedAdministrador
```

* E então devemos da o comando de update, para que as alterações reflitam no banco de dados:
```
dotnet ef database update
```

* Após criar a entidade de veículo e fazer o mapeamento no DbContexto, devemos rodar a migration novamente com o comando:
```
dotnet ef migrations add VeiculosMigration
```

* É após para aplicar essa nova tabela no banco de dados devemos rodar:
```
dotnet ef database update
```

## Adicionando Swashbuckle.AspNetCore 8.1.4

* Foi adicionado ao projeto a biblioteca "Swashbuckle.AspNetCore 8.1.4
" do swagger também encontrada no nuger.org
