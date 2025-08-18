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
* O swagger serve para que possamos descrever e documentar nossas apis de forma padronizada e estruturada, facilitando a compreensão e utilização por nós desenvolvedores assim como para os utilizadores.
* Podemos instalar o swagger com o comando:
```
dotnet add package Swashbuckle.AspNetCore.Swagger --version 8.1.4
```
* Para configurar o swagger é muito simples, em nosso aplicativo Program.cs iremos até a parte de builder e adicionamos as seguintes linhas para configuração:
```
// configuração do swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

```
* Após isso, ainda no arquivo Program.cs, iremos até a região onde está instanciado nosso __app__, logo antes do comando __app.Run()__, e adicionamos as seguintes linhas para concretização da instanciação do swagger:

```

// instanciando o swagger
app.UseSwagger();
app.UseSwaggerUI(); // instanciando a interface do swagger ui

```

* Pronto, se tudo foi seguido corretamente, a nossa API já vai está no ar com swagger para que possamos testar os endpoints.
* Por padrão o swagger está presente no link
```
http://localhost:porta/swagger
```
* No meu caso em:
```
http://localhost:5062/swagger/
```

## Adicionando Token JWT
* Para configurarmos token jwt em nosso projeto, o primeiro passo é instalar o pacote __Microsoft.AspNetCore.Authentication.JwtBearer__
, presente no link:
```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.19
```

* Após, no nosso arquivo "appsetings.json", adicionaremos a chave Jwt, como exemplo, ficando da seguinte forma:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "mysql": ""
  },
  "Jwt": "minimal-api-alunos-vamos_la"
}

```

* Onde Jwt é a nossa chave, e após ela o valor/nome, por nós atribuído (Pode ser qualquer nome).

* Logo após, no nosso Program.cs, na região do __builder__, devemos adicionar a seguinte configuração:

```
// Adicionando configuração do token jwt ao projeto
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

```

* Logo após, vamos ao nosso arquivo Program.cs, e no nosso caso, na região de Administradores primeiramente, e criamos o método GerarToken, que gera um __Token de Acesso JWT__ para um usúario do tipo Administrador. Em resumo, ele cria uma __"credencial digital"__ segura e temporária que representa a identidade e as permissões de um administrador. Abaixo um exemplo do mesmo:
```
string GerarToken(Administrador administrador)
{
    if (string.IsNullOrEmpty(key)) return string.Empty;

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Email, administrador.Email),
        new Claim("Perfil", administrador.Perfil)
    };

    var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}
```

* Agora para utilizar, podemos ir na nossa rota MapPost "/administradores/login" que agora está da seguinte forma:

```
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
{
    if (administradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login com sucesso!");
    }
    else
    {
        return Results.Unauthorized();
    }
```

* E modificarmos para:
```

```

OBS: AdmistradorLogado e uma nova ModelView que deverá ser criada nesse exato momento.

### Site para verificarmos o nosso token
https://www.jwt.io/

## Configuração Swagger para passagem de token JWT
* Para que o nosso token seja passado para o swagger, devemos modificar o nosso método __AddSwaggerGen()__ que antes da modificação está dessa maneira:
```
builder.Services.AddSwaggerGen();

```
* Após a modificação o mesmo ficará:
```
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Insira o token JWT no formato: Bearer {seuToken}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});
```
* E para melhoria, podemos adicionar o método __.AllowAnonymous()__ antes do método __WithTags()__, para dizer que essa rota não tem restrição, ficando o nosso método MapPost "/administradores/login", da seguinte forma:
-> __Antes da modificação:__
```
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
{
    var adm = administradorServico.Login(loginDTO);

    if (adm != null)
    {
        string token = GerarToken(adm);

        return Results.Ok(new AdministradorLogado
        {
            Email = adm.Email,
            Perfil = adm.Perfil,
            Token = $"Bearer {token}"
        });
    }
    else
    {
        return Results.Unauthorized();
    }
})WithTags("Administradores");

```
-> __Após da modificação:__
```
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
{
    var adm = administradorServico.Login(loginDTO);

    if (adm != null)
    {
        string token = GerarToken(adm);

        return Results.Ok(new AdministradorLogado
        {
            Email = adm.Email,
            Perfil = adm.Perfil,
            Token = $"Bearer {token}"
        });
    }
    else
    {
        return Results.Unauthorized();
    }
}).AllowAnonymous().WithTags("Administradores");

```

* E a nossa rota Home<MapGet>"/" que antes estava da seguinte forma:
```
app.MapGet("/", () => Results.Json(new Home())).WithTags("Home");
```
* Após inclusão do método AllowAnonymous ficará assim:

```
app.MapGet("/", () => Results.Json(new Home())).AllowAnonymous().WithTags("Home");

```

## Criando autorização com perfil de Adm e Editor
* Podemos deixar algumas rotas restritas a depender do perfil do usuário.
* Primeiro, vamos no nosso método __GerarTokenJwt__, e na parte de criação de claims, adicionaremos, mais um claim.
-> __Método GerarTokenJwt__ antes:

```
string GerarToken(Administrador administrador)
{
    if (string.IsNullOrEmpty(key)) return string.Empty;

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>()
    {
        new Claim("Email", administrador.Email),
        new Claim("Perfil", administrador.Perfil)
    };

    var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}

```

-> __Método GerarTokenJwt__ após:
```
string GerarToken(Administrador administrador)
{
    if (string.IsNullOrEmpty(key)) return string.Empty;

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>()
    {
        new Claim("Email", administrador.Email),
        new Claim("Perfil", administrador.Perfil),
        new Claim(ClaimTypes.Role, administrador.Perfil)
    };

    var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}

```

* Agora, podemos ir a nossa rotas e validar qual perfil, pode acessar cada uma das mesmas, vamos alterar a rota MapGet "/administradores", para que apenas os administradores possam ver os dados cadastrados, para isso adicionaremos o código abaixo antes do método __WithTags__:
-> __Código a ser inserido para somente Adm:__
```
RequireAuthorization(new AuthorizeAttribute{Roles = "Adm"})
```

-> __Código a ser inserido para autorização de Adm e Editor:__
```
```
RequireAuthorization(new AuthorizeAttribute{Roles = "Adm,Editor"})
```
```
-> __Rota MapGet Administradores antes:__
```
app.MapGet("/administradores", ([FromQuery] int? pagina, IAdministradorServico administradorServico) =>
{
    var adms = new List<AdministradorModelView>();
    var administradores = administradorServico.Todos(pagina);

    foreach (var adm in administradores)
    {

        adms.Add(new AdministradorModelView
        {
            Id = adm.Id,
            Email = adm.Email,
            Perfil = adm.Perfil

        });
    }

    return Results.Ok(adms);
}).RequireAuthorization().WithTags("Administradores");

```

-> __Rota MapGet Administradores após:__
```
app.MapGet("/administradores", ([FromQuery] int? pagina, IAdministradorServico administradorServico) =>
{
    var adms = new List<AdministradorModelView>();
    var administradores = administradorServico.Todos(pagina);

    foreach (var adm in administradores)
    {

        adms.Add(new AdministradorModelView
        {
            Id = adm.Id,
            Email = adm.Email,
            Perfil = adm.Perfil

        });
    }

    return Results.Ok(adms);
}).RequireAuthorization().WithTags("Administradores");

```

* E assim fazemos para todas as demais rotas.

## Refatorando projeto criando sln e projeto de test
* Primeiro, criaremos uma nova pasta dentro de MinimalsApi, denominada API, e moveremos todos os arquivos, menos os ocultos, para essa pasta.

* Após, criaremos uma nova solution, para isso rodamos o comando:

```
dotnet new sln
```

* Após, vamos adicionar o nosso projeto API, dentro deswsa solução, para isso digitamos o comando:
```
dotnet sln add Api/MinimalApi.csproj 
```

* Após, podemos seguir para criação do nosso projeto de __Test__, para isso rodamos o comando:
```
dotnet new mstest -o Test
```

* Após a criação do projeto de __test__, devemos adicionar o arquivo .csproj do mesmo a nossa solution, para isso rodamos o comando:

```
dotnet sln add Test/Test.csproj
```

* Por fim, vamos entrar na nossa pasta de teste, e adicionar a referencia do nosso Projeto __Api__ para que essa pasta possa acessar o conteúdo da mesma, para isso rodamos o comando:

```
dotnet add reference ../Api/MinimalApi.csproj
```

* Após escrevermos a nossa classe de test, podemos rodar a nossa classe com o comando:

```
dotnet test
```

## Testes de Persistência
* Para criar nosso teste de persistência, primeiro iremos criar uma nova database, chamada __"minimal_apitest"__, e após, iremos até a nossa pasta Test, e fazer um dump da db __minimal_api__ com o comando:

```
mysqldump -u root -p'Carros14' minimal_api > minimal_api.dump.sql 

```
* Agora temos um dump/cópia, da base de dados principal __minimal_api__

* Com isso, vamos restaurar essa base de dados para o __minimal_apitest__ com o comando:

```
mysql -uroot -p'Carros14' minimal_apitest < minimal_api.dump.sql 

```

## Comando para testar uma classe específica
* Podemos testar uma classe específica no dotnet com o comando:
```
dotnet test --filter "FullyQualifiedName~NomeClasse
```
* Onde Nome classe representa o nome da classe de teste, exemplo:
```
dotnet test --filter "FullyQualifiedName~VeiculoServicoTest"

```


## Criando Testes Com Request



