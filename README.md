<h1>Gerenciador de Patrimônios</h1> 

<p align="center">
  <img src="http://img.shields.io/static/v1?label=.NET&message=3.1&color=blue&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=Docker&message=2.4.0&color=blue&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=SQL%20Server&message=18.6&color=blue&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

> Status do Projeto: Concluido

## Descrição do projeto 

<p align="justify">
  O projeto "Gerenciamento de Patrimônios" foi desenvolvido para auxiliar no gerenciamento dos patrimônios da sua empresa. Sendo assim, permitindo que usuários autenticados possam criar, atualizar ou remover os dados que ficam armazenados em banco de dados.
</p>

## Funcionalidades

#### Endpoint Nova conta : Registra nova conta.

#### Endpoint Nova conta : Loga na conta existente.

#### Endpoint Marca : Consulta, Grava, Atualiza e Deleta Marcas.

#### Endpoint Patrimônio : Consulta, Grava, Atualiza e Deleta Patrimônios.

#### Endpoint Usuário : Consulta, Grava, Atualiza e Deleta Usuários.

## Pré-requisitos

[SQL Server](https://aka.ms/ssmsfullsetup)
[Docker](https://hub.docker.com/editions/community/docker-ce-desktop-windows/)
[Visual Studio](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)

...

## Como rodar a aplicação

No terminal, clone o projeto: 

```
git clone https://github.com/leandroscj/GerenciarPatrimonios.git
```

Para iniciar o SQL Server vamos rodar um comando docker. Abra o cmd e cole esse comando:

```
docker run --name SQL -e ACCEPT_EULA=Y -e SA_PASSWORD=Pa$$w0rd -e MSSQL_PID=Express -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
```

**Esse comando roda uma imagem do SQL no docker, permitindo nosso uso da base de dados.**

Confira se o SQL está ativo no docker (UP) com o comando:
```
docker ps -a 
```
... 


Copyright :copyright: 2020 - Gerenciador de pratimonios.
