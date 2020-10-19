<h1>Gerenciador de Patrimônios</h1> 

<p align="center">
  <img src="http://img.shields.io/static/v1?label=.NET&message=3.1&color=blue&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=Docker&message=2.4.0&color=blue&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=SQL%20Server&message=18.6&color=blue&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

>Status do Projeto: Concluido

## Descrição do projeto 

<p align="justify">
  O projeto "Gerenciamento de Patrimônios" foi desenvolvido para auxiliar no gerenciamento dos patrimônios da sua empresa. Sendo assim, permitindo que usuários autenticados possam criar, atualizar ou remover os dados que ficam armazenados em banco de dados.
</p>

## Funcionalidades

##### Endpoint Nova conta : Registra nova conta.

##### Endpoint Entrar : Loga na conta existente.

##### Endpoint Marca : Consulta, Grava, Atualiza e Deleta Marcas.

##### Endpoint Patrimônio : Consulta, Grava, Atualiza e Deleta Patrimônios.

##### Endpoint Usuário : Consulta, Grava, Atualiza e Deleta Usuários.

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
docker run --name SQL -e ACCEPT_EULA=Y -e SA_PASSWORD=COLOQUE_AQUI_SUA_SENHA -e MSSQL_PID=Express -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
```

**Esse comando faz com que uma imagem do SQL no docker seja configurada, permitindo nosso uso da base de dados.**

Confira se o SQL está ativo no docker (constando como "UP") com o comando:
```
docker ps -a 
```

No projeto, ajuste o arquivo "appSettings.json" com seu login, senha e nome da base de dados do seu banco SSMS.

Faça um build do projeto e veja se está faltando alguma referência, se sim, adicione e execute o projeto.

**COLOQUE AQUI A PAGINA INICIAL DO SWAGGER

Para utilizar a API, você precisa de um Token que é gerado através da criação de uma conta no endpoint "Nova Conta" com seu email e uma senha, e será retornado para você esse Token de acesso para que consiga consultar, editar e remover registros feitos.

**COLOQUE AQUI UMA FOTO DO TOKEN SENDO GERADO NO ENDPOINT E EM SEGUIDA UMA FOTO DELE SENDO INSERIDO PARA AUTORIZAR O USUARIO A USAR A API.

... 


Copyright :copyright: 2020 - Gerenciador de patrimonios.
