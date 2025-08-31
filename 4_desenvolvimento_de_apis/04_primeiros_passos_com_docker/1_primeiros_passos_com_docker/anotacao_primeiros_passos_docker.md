## Aula 01 - Realizando o Download de Imagens
* Para criação de nosso primeiro container, precisamos de uma imagem, podemos achar imagens para baixar no site 
```
https://hub.docker.com
```

* Após achar a imagem, podemos fazer o download com o comando:
```
docker pull "nome-imagem"
```
-> Exemplo:
```
docker pull hello-world
```

* Após baixar a imagem, podemos executar a mesma, fazemos isso com o comando:
```
docker run hello-world
```

* Agora vamos verificar se a imagem está em execução, podemos fazer isso com o comando abaixo que lista todos os containers em execução:

```
docker ps
```

* Como nosso container já foi executado e sua vida útil foi terminada, ao executar esse comando, nada aparece, porém podemos ver as execução dos últimos containers com o comando:
```
docker ps -a
```

## Aula 02 - Executando um Container
* Primeiro, vamos instalar a imagem do ubuntu
```
docker pull ubuntu
```

* Se listarmos agora, teremos a imagem do Ubuntu e do hello-world
```
docker images
```

* Agora para executar um container específico podemos utilizar o comando:
```
docker run ubuntu
```
  - O comando acima executa o container do ubuntu.
  
* Se exercutarmos o comando:
```
docker ps
```
* Não haverá nenhum container em execução, porém se eu executar:
```
docker ps -a
```
* O comando acima mostará que o container foi executado e encerrado juntamente com a ultima data de execução.


### Executando um container por determinado tempo
* Podemos fazer isso utilizando o comando:
```
docker run ubuntu sleep 10
```
- O comando acima faz o container ficar ativo por 10 segundos.

### Executando o container por um tempo maior
```
docker run ubuntu sleep 1500
```

* Para para o container antes de expirar o tempo, podemos abrir um novo terminal e digitar o comando abaixo para pegar o id do container ou o nome:
```
docker ps
```

* Após digitamos para parar o comando:
```
docker stop containerId
```
-> exemplo
```
docker stop jolly_wescoff
```
- O comando acima para a imagem do ubuntu de name "jolly_wescoff"

### Acessando o sistema operacional do container
* Podemos acessar o sistema operacional da nossa imagem ubuntu baixada com o comando a seguir, que ativa o modo interativo do container:
```
docker run -it ubuntu
```

## Aula 03 - Velha sintaxe e a Nova sintaxe
### Forma antiga
```
docker ps
```

```
docker ps -a
```

### Forma nova
```
docker container ls
```


```
docker container run
```

## Aula 04 - Executando aplicações no contêiner
* Vamos aprender a rodar o container em modo backgroud, e deixar o mesmo rodando até o momento em que quisermos.
* Podemos rodar o container em modo background com o comando:
```
docker run -dti nomeImagem
```
-> exemplo:
```
docker run -dti ubuntu
```

### Abrindo o container para instalação de app
* Podemos abrir o container com o comando:
```
docker exec -it idOuNomeContainer /bin/bash
```

```
docker exec -it 388 /bin/bash
```
- O comando acima executa o bash no container
- No caso de o container ser unico, podemos referenciar o mesmo pelos 3 primeiros numeros do id.

## Aula 05 - Excluindo e nomeando contêineres
* Quando paramos um container e não vamos utilizar, o ideal e que excluimos o mesmo. Podemos excluir um container, para isso utilizamos o comando:
```
docker rm primeiros3DigitosId
```

-> exemplo:
```
docker rm 388
```
### Excluindo Imagem
* A partir do momento que não vamos mais usar uma imagem, devemos exclui-lá também. Podemos consultar as imagems com o comando:
```
docker images
```
* E para excluir uma imagem e bem simples, basta digitar:
```
docker rmi nomeImagem
```

__OBS:__ Se tentarmos executar uma imagem que não esteja em nosso repositório, o docker faz o download da mesma automaticamente:
```
docker run -dti centos
```
- Com o comando acima podemos perceber que o docker não encontra o __centos__ em minha máquina e então faz o download da mesma automaticamente.

-> exemplo
```
docker rmi hello-world
```

### Nomeando containers
* Podemos nomear os nossos containers, para isso usamos o comando:
```
docker run -dti --name novoNomeImagem nomeAtualImagem
```

-> exemplo
```
docker run -dti --name Ubuntu-A ubuntu
```

## Aula 06 - Copiando arquivos para o contêiner
* Primeiro rodaremos o comando:
```
docker ps
```

* O mesmo listará os containers que estão em execução, no momento temos 3 (Ubuntu-B, CentOS-A, Ubuntu-A)

* Criaremos agora 5 arquivos (arquivo.txt, arquivo1.txt,arquivo2.txt,arquivo3.txt,arquivo4.txt), onde os mesmos serão copiados do meu local para o container em execução.

* Após a criação dos arquivos, criaremos uma nova pasta no container "Ubuntu-A", utilizando o seguinte comando:
```
docker exec Ubuntu-A mkdir /destino
```

* Podemos checar a criação da pasta com o comando:
```
docker exec Ubuntu-A ls /
```

* Agora podemos copiar os arquivos para o container Ubuntu-A utilizando o comando
```
docker cp nomeArquivo.txt nomeImagem:/pastaDestino
```
->  Exemplo:
```
docker cp arquivo1.txt Ubuntu-A:/destino
```

* Se tudo ocorreu bem, podemos listar o arquivo enviado ao container com o comando:
```
docker exec Ubuntu-A ls /destino

```

### Copiando vários arquivos
* Para copiar vários arquivos, primeiro precisamos zipar nossos arquivos e então depois envia-los em formato zip.

* Primeiros, vamos compactar nossos arquivos, podemos fazer isso com o comando:
```
zip arquivosZip.zip *.txt
```

* Após isso, teremos o arquivo __arquivosZip.zip__, e podemos copiar para o container com o comando:
```
docker cp arquivosZip.zip Ubuntu-A:/destino
```

* Após, podemos conferir com o comando:
```
docker exec Ubuntu-A ls / destino

```

## Aula 07 - Copiando Arquivos do Container
* Podemos copiar o arquivo __arquivosZip.zip__ do nosso container Ubuntu-A paranossa máquina local com o comando:
```
docker cp nomeImagem:/pastaDestino/nomeArquivo.zip arquivosZipCopia.txt
```
-> __exemplo__:
```
docker cp Ubuntu-A:/destino/arquivosZip.zip arquivosZipCopia.txt
```

## Aula 08 - Tags
* Tags se referem as versões de imagens que podemos baixar.

* Podemos baixar uma versão específica de uma imagem com o comando:
```
docker pull nomeImagem:tag
```

-> __exemplo__:
```
docker pull debian:9
```
- No exemplo acima fazemos o download do debian especificando a tag 9 para baixar a versão 9 do mesmo.

* Após baixar, podemos executar uma imagem específica com a tag com o comando:
```
docker run -dti nomeImagem:tag
```
-> __exemplo__
```
docker run -dti debian:9
```
- NO exemplo acima estamos executando a image __debian__ na versão 9.


## Aula 09 - Criando um container do MYSQL
* Vamos agora criar um container com MySQL, onde precimos ter um banco de dados, e utilizaremos o MySql, porém poderia ser com qualquer outro banco de dados como MariaDB, PostgreSQL etc, Oracle entre outros sistemas de gerenciamento de banco de dados.

* Poderiamos baixa a imagem do ubuntu e depois instalar o MySQL, porém na plataforma do __hub.docker.com__ temos a opção de baixar já o container com MySQL. E assim fazeremos para ficar algo mais compacto.

* Vamos então abrir o site __hub.docker.com/__ e procurar pela imagem mysql, será retornado o container com mysql.

* Verificado o link para baixar o __mysql__, podemos baixar a última versão com o comando:
```
docker pull mysql
```

* Podemos verificar com o comando:
```
docker images
```

### Executando o container a partir da imagem mysql baixada
* Como vimos na documentação da imagem __mysql__, é necessário especificar a variável de ambiente **MYSQL_ROOT_PASSWORD** para execução do conteiner. Podemos setar uma variável com o parâmetro -e.

```
docker run -e MYSQL_ROOT_PASSWORD=Senha123 --name mysql-A -d -p 3306:3306 mysql
```

__OBS__: Como minha porta 3306 já estava sendo usada pelo mysql, tivemos que muda-lá, ficando assim:
```
docker run -e MYSQL_ROOT_PASSWORD=Senha123 --name mysql-A -d -p 3307:3306 mysql
```

__OBS-2__: 
- mysql-A = nome que estamos definindo para o banco
-d para ser executado em modo background
-p para especificar a porta
mysql = nome da imagem
-p [Porta da Máquina]:[Porta do Contêiner] = -p 3307:3306

* Podemos listar se ocorreu tudo certo com o comando:
```
docker ps
```
* Agora vamos acessar o __mysql__ para criar nosso banco de dados lá:
* Para isso, podemos chamar um __bash__ em nosso container __mysql__:
```
docker exec -it mysql-A bash
```
* Podemos listar agora os arquivos necessários para execução do banco de dados:
```
ls
```

* Agora vamos chamar o comando mysql para gerencimanto do banco de dados, vamos fazer isso logando como root:
```
mysql -u root -p --protocol=tcp
```

* Agora logado no banco de dados mysql, podemos criar um database:
```
CREATE DATABASE aula;
```

* Podemos ver o banco de dados criado com:
```
SHOW DATABASES;
```

* Podemos inspecionar as configurações do nosso container com o comando:
```
docker inspect mysql-A
```

## Aula 10 - Acessando um container externamente
* Podemos acessar nosso container externamente, precisamos apenas de um sistema gerenciador de banco de dados. Iremos utilizar o workbanch, e para acessar externamente basta seguir os passos a seguir:

1. Abra o MySQL Workbench.

2. Na tela inicial, clique no ícone de + ao lado de "MySQL Connections" para criar uma nova conexão.

3. Uma janela chamada "Setup New Connection" ou "Configure Server Management" irá aparecer.

4. Agora será necessário preencher algumas informações:

__Ponnection Name__: Docker MySQL Local (ou qualquer nome que você preferir)

__Connection Method__: Standard (TCP/IP)

__Hostname__: 127.0.0.1 (ou localhost)

__Port__: 3307 (Este é o detalhe mais importante!)

__Username__: root

__Password:__ Clique em Store in Vault... e digite Senha123


## Aula 11 - Parando e reiniciando um container
* Podemos parar um container com o comando:
```
docker stop mysql-A
```

* Podemos voltar a execução do comando com o comando
```
docker start mysql-A
```

## Resumo
###Executando um contêiner
```
docker pull ubuntu
docker run ubuntu
docker run ubuntu sleep 10
docker run ubuntu sleep 1500
docker stop [id]
docker run --help
docker run -it ubuntu
```

### Executando aplicações no contêiner
```
docker run -dti  ubuntu 
docker exec -it [id ou nome]  /bin/bash
```

### Excluindo e nomeando contêineres
```
docker stop [id]
docker rm [id]
docker rmi [imagem]

docker run -dti --name Ubuntu-A ubuntu
```

### Copiando arquivos para o contêiner
```
docker exec -ti Ubuntu-A /bin/bash
docker exec Ubuntu-A mkdir /destino/
docker exec Ubuntu-A mkdir ls -l /
nano Arquivo.txt
docker cp arquivo.txt Ubuntu-A:/aula/
```

### Copiando arquivos do container
```
docker cp Ubuntu-A:/destino/Meuzip.zip  Zipcopia.zip
```

### Criando um contêiner do MySQL
```
docker cp Ubuntu-A:/destino/Meuzip.zip  Zipcopia.zip
```

### Acessando um container externamente
```
# docker pull mysql
 
# docker run -e MYSQL_ROOT_PASSWORD=Senha123 --name mysql-A -d -p 3306:3306 mysql

# docker exec -it mysql-A bash

# mysql -u root -p --protocol=tcp


CREATE DATABASE aula;
show databases;

# docker inspect mysql-A

# mysql -u root -p --protocol=tcp
```

## PASSO A PASSO CONFIGURAÇÃO DOCKER EM UMA API REAL

### Passo 1: Instalar o Docker
1. __Baixar o Docker__: Acesse o site oficial do Docker docker.com e baixe a versão adequada para seu sistema operacional (Windows, macOS ou Linux).

2. __Instalar__: Siga as instruções na tela para instalar o Docker em sua máquina.

3. __Verificar a instalação__: Abra o terminal e rode o comando:
```
docker --version
```

* De modo geral, podemos fazer a instalação no Ubuntu 22 seguindo os passos:

1. __Atualizar o sistema__: Abra um terminal e execute:
```
sudo apt update
sudo apt upgrade -y
```

2. __Instalar dependências__:
```
sudo apt install apt-transport-https ca-certificates curl software-properties-common -y
```

3. __Adicionar a chave GPG do repositório do Docker__:
```
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -
```

4. __Adicionar o repositório do Docker__:
```
sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable"
```

5. Instalar o Docker:
```
sudo apt update
sudo apt install docker-ce -y
```

6. Verificar a instalação:
```
docker --version
```

7. Adicionar nosso usuário ao grupo Docker (opcional): Isso permite que agente execute o Docker sem sudo.
```
sudo usermod -aG docker $USER
```
Depois, faça logout e login novamente para que as alterações tenham efeito.



### Passo 2: Criar uma API .NET
1. __Criar um novo projeto__: Abra um terminal e execute o seguinte comando para criar um novo projeto de API:
```
dotnet new webapi -n NomeDaSuaApi
```

* Substitua "NomeDaSuaApi" pelo nome que deseja dar à sua API.

2. Navegar até o diretório do projeto:
```
cd NomeDaSuaApi
```

### Passo 3: Criar o arquivo Dockerfile
1. __Adicionar um Dockerfile__: Na raiz do seu projeto, crie um arquivo chamado Dockerfile (sem extensão) e adicione o seguinte conteúdo:
```
# Etapa 1: Construir a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NomeDaSuaApi/NomeDaSuaApi.csproj", "NomeDaSuaApi/"]
RUN dotnet restore "NomeDaSuaApi/NomeDaSuaApi.csproj"
COPY . .
WORKDIR "/src/NomeDaSuaApi"
RUN dotnet build "NomeDaSuaApi.csproj" -c Release -o /app/build

# Etapa 2: Publicar a aplicação
FROM build AS publish
RUN dotnet publish "NomeDaSuaApi.csproj" -c Release -o /app/publish

# Etapa 3: Criar a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NomeDaSuaApi.dll"]
```

* Certifique-se de substituir "NomeDaSuaApi" pelo nome real do seu projeto.

### Passo 4: Criar um arquivo .dockerignore
1. __Adicionar .dockerignore__: Crie um arquivo chamado .dockerignore na raiz do seu projeto e adicione o seguinte conteúdo:
```
bin/
obj/
```

* Isso ajuda a evitar que arquivos desnecessários sejam copiados para a imagem Docker.

### Passo 5: Construir a imagem Docker

1. __Construir a imagem__: No terminal, execute o seguinte comando na raiz do seu projeto para construir a imagem Docker:
```
docker build -t nomedasuapi:latest .
```
* Substitua "nomedasuapi" pelo nome que deseja dar à sua imagem.

### Passo 6: Executar o container

1.__Executar o container__: Após a construção da imagem, você pode executar o container com o seguinte comando:
```
docker run -d -p 8080:80 --name nome_do_container nomedasuapi:latest
```

* Isso irá mapear a porta 80 do container para a porta 8080 do seu host. Você pode acessar a API em http://localhost:8080.

### Passo 7: Testar a API

1. __Testar a API__: Podemos usar ferramentas como Postman ou simplesmente acessar o navegador em http://localhost:8080/weatherforecast (ou o endpoint padrão da API .NET) para ver se sua API está funcionando.

### Passo 8: Parar e remover o container

1. __Parar o container__: Para parar o container que criamos, executar:
```
docker stop nome_do_container
```

2. __Remover o container__: Para remover o container, usamos:
```
docker rm nome_do_container
```

