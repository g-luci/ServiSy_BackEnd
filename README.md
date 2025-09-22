# ServiSy API

## Visão Geral

ServiSy API é o backend para uma plataforma de conexão entre prestadores de serviço e clientes. A API permite que usuários se cadastrem como clientes ou prestadores, gerenciem serviços e forneçam feedback. O sistema utiliza autenticação baseada em JWT para proteger as rotas.

## Funcionalidades Principais

* **Autenticação de Usuários**: Sistema seguro de login e cadastro com senhas criptografadas.
* **Gerenciamento de Usuários**: Cadastro de novos usuários e atualização de informações existentes.
* **Gerenciamento de Serviços**: Prestadores de serviço podem criar, editar, visualizar e remover seus serviços.
* **Sistema de Feedback**: Clientes podem avaliar os serviços com uma nota e um comentário.

## Tecnologias Utilizadas

* **.NET 7**: Framework principal para a construção da API.
* **ASP.NET Core**: Para a criação de endpoints RESTful.
* **Entity Framework Core**: ORM para interação com o banco de dados.
* **MySQL**: Banco de dados relacional para armazenamento dos dados.
* **AutoMapper**: Para mapeamento de objetos (DTOs para Models).
* **BCrypt.Net-Next**: Para hashing e verificação de senhas.
* **JWT (JSON Web Tokens)**: Para autenticação e autorização de endpoints.

## Estrutura do Projeto

O projeto é organizado em três camadas principais:

* `ServiSy_v1_API`: Camada de apresentação, responsável pelos Controllers e pela configuração da API.
* `ServiSy_v1_Business`: Camada de negócios, contendo a lógica da aplicação, serviços, DTOs e interfaces.
* `ServiSy_v1_Data`: Camada de acesso a dados, responsável pelos repositórios, contexto do banco de dados e migrações do Entity Framework.

## Como Começar

Siga os passos abaixo para configurar e executar o projeto localmente.

### Pré-requisitos

* [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
* Um servidor de banco de dados MySQL.

### Instalação e Configuração

1.  **Clone o repositório:**
    ```bash
    git clone <url-do-seu-repositorio>
    cd ServiSy_BackEnd
    ```

2.  **Configure o `appsettings.json`:**
    Abra o arquivo `ServiSy_v1/appsettings.json` e configure a sua string de conexão com o MySQL e as configurações do JWT:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "server=localhost;userid=seu_usuario;password=sua_senha;database=servisydb"
      },
      "JwtSettings": {
        "SecretKey": "SuaChaveSecretaSuperSeguraDeveSerLonga",
        "Issuer": "ServiSy.Auth",
        "Audience": "ServiSy.Api",
        "TokenExpirationHours": 2
      }
    }
    ```

3.  **Instale as dependências:**
    Execute o comando na raiz da solução para restaurar os pacotes NuGet.
    ```bash
    dotnet restore
    ```

4.  **Aplique as Migrations:**
    Para criar o banco de dados e as tabelas, execute os comandos do Entity Framework a partir da pasta do projeto `ServiSy_v1_API`.
    ```bash
    dotnet ef database update --project ../ServiSy_v1_Data/
    ```

5.  **Execute a aplicação:**
    ```bash
    dotnet run --project ServiSy_v1/ServiSy_v1_API.csproj
    ```
    A API estará disponível em `http://localhost:5250` (ou na porta configurada em `launchSettings.json`).

## Endpoints da API

A API expõe os seguintes endpoints principais:

### Autenticação e Usuários (`/v1/Usuario`)

* `POST /login`: Autentica um usuário e retorna um token JWT.
* `POST /`: Cadastra um novo usuário.
* `GET /{id}`: Busca um usuário por ID.
* `PATCH /{id}`: Atualiza as informações de um usuário (rota protegida).

### Serviços (`/v1/Servico`)

* `POST /`: Adiciona um novo serviço (requer perfil de prestador).
* `GET /`: Lista todos os serviços com paginação (pode ser filtrado por `prestadorId`).
* `GET /{id}`: Busca um serviço por ID.
* `PATCH /{id}`: Atualiza um serviço (somente o prestador do serviço pode atualizar).
* `DELETE /{id}`: Remove um serviço (somente o prestador do serviço pode remover).

### Feedbacks (`/v1/feedbacks`)

* `POST /`: Adiciona um novo feedback a um serviço (requer autenticação).
* `GET /`: Lista todos os feedbacks de um determinado `servicoId`.
* `GET /{id}`: Busca um feedback por ID.
* `PATCH /{id}`: Atualiza um feedback (somente o autor do feedback pode atualizar).
* `DELETE /{id}`: Remove um feedback (somente o autor do feedback pode remover).
