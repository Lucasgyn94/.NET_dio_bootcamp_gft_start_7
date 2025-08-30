## Instalação do Docker
* Podemos verificar como instalar o docker acessando diretamente a documentação presente no site oficial: https://www.docker.com/. 
* Resumidamente, após verificar a documentação, verifiquei que o docker pode ser instalado via scripts executando os comandos abaixo no terminal:
```
$ curl -fsSL https://get.docker.com -o get-docker.sh
$ sudo sh ./get-docker.sh --dry-run
```

* Podemos verificar o status do serviço docker com o comando:
```
$ systemctl status docker
```
