# CRUD de Clientes - ASP.NET Core 8 + SQLite

Este projeto é uma API RESTful simples para gerenciamento de clientes, desenvolvida com **.NET 8.0.411** e **SQLite** como banco de dados.

## Funcionalidades

- Criar cliente
- Listar clientes
- Buscar cliente por ID
- Atualizar cliente
- Remover cliente

## Tecnologias

- [.NET 8.0.411](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQLite
- Entity Framework Core
- ASP.NET Core Web API

## Estrutura do Projeto

- `Controllers/`: Contém os endpoints da API.
- `Models/`: Define as entidades.
- `Data/`: Configuração do contexto do banco de dados (DbContext).
- `DTOS/`: Define os objetos de transferência de dados.
- `Repositories/`: Define os repositórios.
- `Services/`: Define os serviços.
- `Program.cs`: Ponto de entrada da aplicação.

## Como executar o projeto

### 1. Instale o SDK do .NET 8.0.411

Você pode baixar e instalar o SDK apropriado para seu sistema operacional aqui:  
[https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

Para verificar a instalação:

```bash
dotnet --version
```

### 2. Restaurar as dependências do projeto

```bash
dotnet restore
```

### 3. Rodar a aplicação

```bash
dotnet run
```

A aplicação estará disponível por padrão em:

- `http://localhost:5148`

### 4. Acessar o Swagger para testar a API

Abra no navegador:

```
https://localhost:5148/swagger
```
