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

