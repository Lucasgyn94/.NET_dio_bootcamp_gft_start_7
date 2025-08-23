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
* Agora iremos aprender a criar testes de request, que são testes que vai levantar a nossa API, e testes end-to-end, enviando os dados via POST, GET, etc.
* Para isso, o primeiro passo e refatorar o nosso código da API, vamos criar um arquivo em branco e copiar todo o código de __Program.cs__, deixando o nosso __Program.cs__ da seguinte forma:

-> __Program.cs antes:__
```
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;

Env.Load(); // carregando arquivo .env com as credenciais do banco de dados

#region Builder
var builder = WebApplication.CreateBuilder(args);

//var key = builder.Configuration.GetSection("Jwt").ToString();
var key = builder.Configuration["Jwt"];

if (string.IsNullOrEmpty(key)) key = "123456";

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

// injetando serviço AdministradorServico
builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();
// injetando serviço de veículos
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();

// configuração do swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Insira o seu token aqui: "
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

// acrescentando serviço do mysql
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var stringConexaoDB = $"Server={dbServer};Database={dbDatabase};Uid={dbUser};Pwd={dbPassword};";

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        stringConexaoDB,
        ServerVersion.AutoDetect(stringConexaoDB)
    );
});

/* 
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});
*/

var app = builder.Build();
#endregion

#region Home
app.MapGet("/", () => Results.Json(new Home())).AllowAnonymous().WithTags("Home");
#endregion

#region Administradores
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
            Token = token
        });
    }
    /* 
    if (administradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login com sucesso!");
    }
    */
    else
    {
        return Results.Unauthorized();
    }
    // if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    // {
    //     return Results.Ok("Login com sucesso!");
    // }
    // else
    // {
    //     return Results.Unauthorized();
    // }
}).AllowAnonymous().WithTags("Administradores");


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
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm" })
.WithTags("Administradores");

app.MapGet("/administradores/{id}", ([FromRoute] int id, IAdministradorServico administradorServico) =>
{
    var administrador = administradorServico.BuscarPorId(id);

    if (administrador == null) return Results.NotFound();

    return Results.Ok(new AdministradorModelView
    {
        Id = administrador.Id,
        Email = administrador.Email,
        Perfil = administrador.Perfil

    });
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm" })
.WithTags("Administradores");


app.MapPost("/administradores", ([FromBody] AdministradorDTO administradorDTO, IAdministradorServico administradorServico) =>
{
    var validacao = new ErrosDeValidacao
    {
        Mensagens = new List<string>()
    };

    if (string.IsNullOrEmpty(administradorDTO.Email))
        validacao.Mensagens.Add("Email não pode ser vazio!");
    if (string.IsNullOrEmpty(administradorDTO.Senha))
        validacao.Mensagens.Add("Senha não pode ser vazia!");
    if (administradorDTO.Perfil == null)
        validacao.Mensagens.Add("Perfil não pode ser vazio!");

    if (validacao.Mensagens.Count > 0)
        return Results.BadRequest(validacao);

    var administrador = new Administrador
    {
        Email = administradorDTO.Email,
        Senha = administradorDTO.Senha,
        Perfil = administradorDTO.Perfil.ToString() ?? Perfil.Editor.ToString()
    };

    administradorServico.Incluir(administrador);

    return Results.Created($"administrador/{administrador.Id}", new AdministradorModelView
    {
        Id = administrador.Id,
        Email = administrador.Email,
        Perfil = administrador.Perfil
    });

})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm" })
.WithTags("Administradores");

#endregion

#region Veiculos
// Método de validar dto veículos 
ErrosDeValidacao ValidaDTO(VeiculoDTO veiculoDTO)
{
    ErrosDeValidacao validacao = new ErrosDeValidacao
    {
        Mensagens = new List<string>()
    };

    if (string.IsNullOrEmpty(veiculoDTO.Nome))
        validacao.Mensagens.Add("Nome de veículo não pode ser em branco!");
    if (string.IsNullOrEmpty(veiculoDTO.Marca))
        validacao.Mensagens.Add("Marca de veículo não pode ser em branco!");
    if (veiculoDTO.Ano < 1950)
    {
        validacao.Mensagens.Add("Ano inválido! Informe um ano de veículo igual ou superior a 1950.");
    }
    ;

    return validacao;
}

app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) =>
{
    var validacao = ValidaDTO(veiculoDTO);

    if (validacao.Mensagens.Count > 0)
    {
        return Results.BadRequest(validacao);
    }

    var veiculo = new Veiculo
    {
        Nome = veiculoDTO.Nome,
        Marca = veiculoDTO.Marca,
        Ano = veiculoDTO.Ano
    };

    veiculoServico.Incluir(veiculo);

    return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm,Editor", })
.WithTags("Veiculos");

app.MapGet("/veiculos", ([FromQuery] int? pagina, IVeiculoServico veiculoServico) =>
{
    var veiculos = veiculoServico.Todos(pagina);
    return Results.Ok(veiculos);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm,Editor", })
.WithTags("Veiculos");

app.MapGet("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) =>
{
    var veiculo = veiculoServico.BuscarPorId(id);

    if (veiculo == null) return Results.NotFound();
    return Results.Ok(veiculo);

})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm,Editor", })
.WithTags("Veiculos");

app.MapPut("veiculos/{id}", ([FromRoute] int id, VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) =>
{
    var veiculo = veiculoServico.BuscarPorId(id);
    if (veiculo == null) return Results.NotFound();

    var validacao = ValidaDTO(veiculoDTO);
    if (validacao.Mensagens.Count > 0)
    {
        Results.BadRequest(validacao);
    }


    veiculo.Nome = veiculoDTO.Nome;
    veiculo.Marca = veiculoDTO.Marca;
    veiculo.Ano = veiculoDTO.Ano;

    veiculoServico.Atualizar(veiculo);

    return Results.Ok(veiculo);
}).RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm", })
.WithTags("Veiculos");

app.MapDelete("veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) =>
{
    var veiculo = veiculoServico.BuscarPorId(id);

    if (veiculo == null) return Results.NotFound();

    veiculoServico.Apagar(veiculo);

    return Results.NoContent();
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Adm", })
.WithTags("Veiculos");

#endregion

#region App
// instanciando o swagger
app.UseSwagger();
app.UseSwaggerUI(); // instanciando a interface do swagger ui

// Configurando para usar autenticação e autorização jwt
app.UseAuthentication();
app.UseAuthorization();

app.Run();
#endregion

/*PAREI NA AULA: Configurando JWT no projeto: 22 min*/

```

-> __Program.cs depois:__
```
using MinimalApi;

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}

CreateHostBuilder(args).Build();
```

após isso, na raiz do projeto, criaremos um arquivo __Startup.cs__, aonde iremos fazer as nossas configurações. O Mesmo fica configurado da seguinte forma:

-> __Startup.cs configurado:__
```
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace MinimalApi;

public class Startup
{

    private string _key;
    public Startup(IConfiguration configuration)
    {
        Env.Load(); // carregando arquivo .env com as credenciais do banco de dados
        Configuration = configuration;
        this._key = Configuration["Jwt"]?? "";

        if (string.IsNullOrEmpty(this._key))
            throw new InvalidOperationException("A chave JWT não foi encontrada nas configurações.");
    
    }

    public IConfiguration Configuration { get; set; } = default!;

    // Metodo para configuração dos Services (Serviços), tudo que tivermos de configuraçãode Services, iremos colocar aqui
    public void ConfigureServices(IServiceCollection services)
    {
        // Adicionando configuração do token jwt ao projeto
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._key)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        services.AddAuthorization();

        // injetando serviço AdministradorServico
        services.AddScoped<IAdministradorServico, AdministradorServico>();
        // injetando serviço de veículos
        services.AddScoped<IVeiculoServico, VeiculoServico>();

        // configuração do swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "Insira o seu token aqui: "
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

        // acrescentando serviço do mysql
        var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
        var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var stringConexaoDB = $"Server={dbServer};Database={dbDatabase};Uid={dbUser};Pwd={dbPassword};";

        Console.WriteLine($"--> String de conexão usada: {stringConexaoDB}");

        services.AddDbContext<DbContexto>(options =>
        {
            options.UseMySql(
                stringConexaoDB,
                ServerVersion.AutoDetect(stringConexaoDB)
            );

        });


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // instanciando o swagger
        app.UseSwagger();
        app.UseSwaggerUI(); // instanciando a interface do swagger ui

        app.UseRouting();

        // Configurando para usar autenticação e autorização jwt
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            #region Home
            endpoints.MapGet("/", () => Results.Json(new Home())).AllowAnonymous().WithTags("Home");
            #endregion

            #region Administradores
            string GerarToken(Administrador administrador)
            {
                if (string.IsNullOrEmpty(this._key)) return string.Empty;

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._key));
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

            endpoints.MapPost("/administradores/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
            {
                var adm = administradorServico.Login(loginDTO);

                if (adm != null)
                {
                    string token = GerarToken(adm);

                    return Results.Ok(new AdministradorLogado
                    {
                        Email = adm.Email,
                        Perfil = adm.Perfil,
                        Token = token
                    });
                }
                /* 
                if (administradorServico.Login(loginDTO) != null)
                {
                    return Results.Ok("Login com sucesso!");
                }
                */
                else
                {
                    return Results.Unauthorized();
                }
                // if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
                // {
                //     return Results.Ok("Login com sucesso!");
                // }
                // else
                // {
                //     return Results.Unauthorized();
                // }
            }).AllowAnonymous().WithTags("Administradores");


            endpoints.MapGet("/administradores", ([FromQuery] int? pagina, IAdministradorServico administradorServico) =>
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
            })
            .RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm" })
            .WithTags("Administradores");

            endpoints.MapGet("/administradores/{id}", ([FromRoute] int id, IAdministradorServico administradorServico) =>
            {
                var administrador = administradorServico.BuscarPorId(id);

                if (administrador == null) return Results.NotFound();

                return Results.Ok(new AdministradorModelView
                {
                    Id = administrador.Id,
                    Email = administrador.Email,
                    Perfil = administrador.Perfil

                });
            })
            .RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm" })
            .WithTags("Administradores");


            endpoints.MapPost("/administradores", ([FromBody] AdministradorDTO administradorDTO, IAdministradorServico administradorServico) =>
            {
                var validacao = new ErrosDeValidacao
                {
                    Mensagens = new List<string>()
                };

                if (string.IsNullOrEmpty(administradorDTO.Email))
                    validacao.Mensagens.Add("Email não pode ser vazio!");
                if (string.IsNullOrEmpty(administradorDTO.Senha))
                    validacao.Mensagens.Add("Senha não pode ser vazia!");
                if (administradorDTO.Perfil == null)
                    validacao.Mensagens.Add("Perfil não pode ser vazio!");

                if (validacao.Mensagens.Count > 0)
                    return Results.BadRequest(validacao);

                var administrador = new Administrador
                {
                    Email = administradorDTO.Email,
                    Senha = administradorDTO.Senha,
                    Perfil = administradorDTO.Perfil.ToString() ?? Perfil.Editor.ToString()
                };

                administradorServico.Incluir(administrador);

                return Results.Created($"administrador/{administrador.Id}", new AdministradorModelView
                {
                    Id = administrador.Id,
                    Email = administrador.Email,
                    Perfil = administrador.Perfil
                });

            })
            .RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm" })
            .WithTags("Administradores");

            #endregion

            #region Veiculos
            // Método de validar dto veículos 
            ErrosDeValidacao ValidaDTO(VeiculoDTO veiculoDTO)
            {
                ErrosDeValidacao validacao = new ErrosDeValidacao
                {
                    Mensagens = new List<string>()
                };

                if (string.IsNullOrEmpty(veiculoDTO.Nome))
                    validacao.Mensagens.Add("Nome de veículo não pode ser em branco!");
                if (string.IsNullOrEmpty(veiculoDTO.Marca))
                    validacao.Mensagens.Add("Marca de veículo não pode ser em branco!");
                if (veiculoDTO.Ano < 1950)
                {
                    validacao.Mensagens.Add("Ano inválido! Informe um ano de veículo igual ou superior a 1950.");
                }
                ;

                return validacao;
            }

            endpoints.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) =>
            {
                var validacao = ValidaDTO(veiculoDTO);

                if (validacao.Mensagens.Count > 0)
                {
                    return Results.BadRequest(validacao);
                }

                var veiculo = new Veiculo
                {
                    Nome = veiculoDTO.Nome,
                    Marca = veiculoDTO.Marca,
                    Ano = veiculoDTO.Ano
                };

                veiculoServico.Incluir(veiculo);

                return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
            })
            .RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm,Editor", })
            .WithTags("Veiculos");

            endpoints.MapGet("/veiculos", ([FromQuery] int? pagina, IVeiculoServico veiculoServico) =>
            {
                var veiculos = veiculoServico.Todos(pagina);
                return Results.Ok(veiculos);
            })
            .RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm,Editor", })
            .WithTags("Veiculos");

            endpoints.MapGet("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) =>
            {
                var veiculo = veiculoServico.BuscarPorId(id);

                if (veiculo == null) return Results.NotFound();
                return Results.Ok(veiculo);

            })
            .RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm,Editor", })
            .WithTags("Veiculos");

            endpoints.MapPut("veiculos/{id}", ([FromRoute] int id, VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) =>
            {
                var veiculo = veiculoServico.BuscarPorId(id);
                if (veiculo == null) return Results.NotFound();

                var validacao = ValidaDTO(veiculoDTO);
                if (validacao.Mensagens.Count > 0)
                {
                    Results.BadRequest(validacao);
                }


                veiculo.Nome = veiculoDTO.Nome;
                veiculo.Marca = veiculoDTO.Marca;
                veiculo.Ano = veiculoDTO.Ano;

                veiculoServico.Atualizar(veiculo);

                return Results.Ok(veiculo);
            }).RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm", })
            .WithTags("Veiculos");

            endpoints.MapDelete("veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) =>
            {
                var veiculo = veiculoServico.BuscarPorId(id);

                if (veiculo == null) return Results.NotFound();

                veiculoServico.Apagar(veiculo);

                return Results.NoContent();
            })
            .RequireAuthorization()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm", })
            .WithTags("Veiculos");

            #endregion

        });
    }

}

```

* Apos isso, iremos até a raiz de Test, e criaremos uma pasta Helpers, com a classe __Setup.cs__ (toda vez que for precisar configurar o serviço irá rodar nessa classe de Setup), e a pasta Request, com a classe __AdministradorRequestTest__. Segue abaixo conteúdo das mesmas:

-> __Helpers/Setup.cs:__

```
using DotNetEnv;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi;

namespace Test;

public class Setup
{
    public const String PORT = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();

        Setup.http = Setup.http.WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
                services.AddScoped<IVeiculoServico, VeiculoServicoMock>();
            });
        });
        Setup.client = Setup.http.CreateClient();
    }

    public static void ClassCleanup()
    {
        Setup.http.Dispose();
    }
}

```

-> __Requests/AdministradorRequestTest.cs:__

```

using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using MinimalApi;

namespace Test;

[TestClass]
public class AdministradorRequestTest
{
    private static HttpClient _client = default!;
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
        _client = Setup.client;
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }

    #region Metodo Auxiliar
    // Método auxiliar para realizar login e retornar token JWT
    private async Task<string> LoginAssincronoEPegarToken(string email, string senha)
    {
        var loginDto = new LoginDTO
        {
            Email = email,
            Senha = senha
        };
        var content = JsonContent.Create(loginDto);

        var response = await _client.PostAsync("administradores/login", content);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var adminLogado = JsonSerializer.Deserialize<AdministradorLogado>(responseBody, _jsonOptions);

        Assert.IsNotNull(adminLogado?.Token, "O token não deveria ser nulo!");
        return adminLogado.Token;
    }
    #endregion

    #region Testes de Login (Post /administradores/login)
    [TestMethod]
    public async Task LoginComCredenciaisValidasRetornaOkComToken()
    {
        // Arrange
        var loginDto = new LoginDTO
        {
            Email = "adm@teste.com",
            Senha = "123456"
        };
        //var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
        var content = JsonContent.Create(loginDto);
        // Act
        var response = await _client.PostAsync("/administradores/login", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(responseBody, _jsonOptions);

        Assert.IsNotNull(admLogado);
        Assert.IsFalse(string.IsNullOrEmpty(admLogado.Token));
        Assert.AreEqual("adm@teste.com", admLogado.Email);
    }


    [TestMethod]
    public async Task LoginComCredenciaisInvalidasDeveRetornarUnauthorized()
    {
        // Arrange
        var loginDto = new LoginDTO
        {
            Email = "adm@teste_invalido.com",
            Senha = "123456"
        };
        //var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
        var content = JsonContent.Create(loginDto);

        // Act
        var response = await _client.PostAsync("/administradores/login", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    #endregion

    #region Testes de criar Adminitradores (POST /administradores)
    [TestMethod]
    public async Task CriarAdministradorComDadosValidosEAutorizacaoDeveRetornarCreated()
    {
        //Arrange
        var token = await LoginAssincronoEPegarToken("adm@teste.com", "123456");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var novoAdmDto = new AdministradorDTO
        {
            Email = "novo_adm@teste.com",
            Senha = "123456",
            Perfil = 0

        };

        //var content = new StringContent(JsonSerializer.Serialize(novoAdmDto), Encoding.UTF8, "application/json");
        var content = JsonContent.Create(novoAdmDto);

        //Act
        var response = await _client.PostAsync("/administradores", content);

        //Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.IsNotNull(response.Headers.Location, "O cabeçalho não foi retornado");

    }

    [TestMethod]
    public async Task CriarAdministradorSemAutorizacaoDeveRetornarUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;
        var novoAdmDto = new AdministradorDTO
        {
            Email = "adm@teste.com.br",
            Senha = "123456",
        };

        //var content = new StringContent(JsonSerializer.Serialize(novoAdmDto), Encoding.UTF8, "application/json");
        var content = JsonContent.Create(novoAdmDto);

        // Act
        var response = await _client.PostAsync("/administradores", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [TestMethod]
    public async Task CriarAdministradorComAutorizacaoDeEditorDeveRetornarForbidden()
    {
        // arrange
        var token = await LoginAssincronoEPegarToken("editor@teste.com", "123456");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var novoAdmDto = new AdministradorDTO
        {
            Email = "adm@teste.com",
            Senha = "123456",
            Perfil = 0
        };

        //var content = new StringContent(JsonSerializer.Serialize(novoAdmDto), Encoding.UTF8, "application/json");
        var content = JsonContent.Create(novoAdmDto);

        // act
        var response = await _client.PostAsync("/administradores", content);

        // assert
        Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
    }

    #endregion

    #region Testes de Listar Administradores (GET /administradores)
    [TestMethod]
    public async Task ObterTodosOsAdministradoresComAutorizacaoDeveRetornarOkComLista()
    {
        // Arrange
        var token = await LoginAssincronoEPegarToken("adm@teste.com", "123456");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Act
        var response = await _client.GetAsync("/administradores");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        var administradores = JsonSerializer.Deserialize<List<AdministradorModelView>>(responseBody, _jsonOptions);

        Assert.IsNotNull(administradores);
        Assert.IsTrue(administradores.Count > 0, "Lista de administradores vazia!");
    }
    #endregion

    #region Testes de buscar por ID (GET /administradores/{id})
    [TestMethod]
    public async Task ObterAdministradorPorIdComIdValidoEAutorizacaoDeveRetornaOk()
    {
        // Arrange
        var token = await LoginAssincronoEPegarToken("adm@teste.com", "123456");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        const int idParaBuscar = 1;

        // Act
        var response = await _client.GetAsync($"administradores/{idParaBuscar}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        var adminitrador = JsonSerializer.Deserialize<AdministradorModelView>(responseBody, _jsonOptions);

        Assert.IsNotNull(adminitrador);
        Assert.AreEqual(idParaBuscar, adminitrador.Id);
    }

    [TestMethod]
    public async Task ObterAdministradorPorIdComIdInvalidoDeveRetornarNotFound()
    {
        // arrange
        var token = await LoginAssincronoEPegarToken("adm@teste.com", "123456");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        const int idParaBuscar = 999;

        // act
        var response = await _client.GetAsync($"/administradores/{idParaBuscar}");

        // assert
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    #endregion


}


```

* Após isso, criaremos uma pasta chamada __Mock__ e dentro criaremos a nossa classe __AdministradorServicoMock.cs__
```
using MinimalApi;

namespace Test;

public class AdministradorServicoMock : IAdministradorServico
{
    private static List<Administrador> _administradores = new List<Administrador>()
    {
        new Administrador{
            Id = 1,
            Email = "adm@teste.com",
            Senha = "123456",
            Perfil = "Adm"
        },
        new Administrador{
            Id = 2,
            Email = "editor@teste.com",
            Senha = "123456",
            Perfil = "Editor"
        }
    };

    public Administrador? BuscarPorId(int id)
    {
        return _administradores.Find(a => a.Id == id);
    }

    public Administrador Incluir(Administrador administrador)
    {
        administrador.Id = _administradores.Count() + 1;
        _administradores.Add(administrador);
        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return _administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }

    public List<Administrador> Todos(int? pagina)
    {
        return _administradores;
    }
}

```
## Utilizando "User Secrets"
* Podemos lidar com segredos(senhas, chaves de API, string de conexão) no ambiente APS.NET usando "User Secrets" (Segredos do usuário).
* __User Secrets__ É um arquivo secrets.json que fica armazenado fora da nossa pasta de projeto, em um local segudo do nosso hd.
* Para utilizar é muito simples, na raiz do projeto, no nosso caso em __Api__, rodaremos o comando:
```
dotnet user-secrets init

```
* Agora é so adicionar nossas string de conexão e chave jwt aos segredos:

```
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=minimal_api;Uid=root;Pwd=Carros14"
dotnet user-secrets set "Jwt": "minimal-api-alunos-vamos-la_turma"
```

## Testando Classes Específicas
* Podemos testar classes específicas com .NET, utilizando o comando no terminal:
```
```
dotnet test --filter ClassName=NomePasta.NomeClasse

```
```
-> __exemplo__
```
dotnet test --filter ClassName=Test.AdministradorRequestTest

```
