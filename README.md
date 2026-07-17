# 📚 Biblioteca API

API REST desenvolvida com ASP.NET Core e Entity Framework Core para gerenciamento de livros.

## 🚀 Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de possuir instalado:

- .NET SDK 10
- SQL Server
- Entity Framework Core CLI

Caso não possua a CLI do Entity Framework:

```bash
dotnet tool install --global dotnet-ef
```

## ⚙️ Configuração

Configure a string de conexão no arquivo:

```text
appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaStringDeConexao"
  }
}
```

## ▶️ Executando o projeto

Clone o repositório:

```bash
git clone <url-do-repositorio>
```

Entre na pasta do projeto:

```bash
cd SistemaBiblioteca.API
```

Restaure as dependências:

```bash
dotnet restore
```

Execute as migrations:

```bash
dotnet ef database update
```

Inicie a aplicação:

```bash
dotnet run
```

## 📖 Swagger

Após iniciar a aplicação, acesse:

```
https://localhost:<porta>/swagger
```

## 🗂️ Estrutura do projeto

```
Controllers/
Data/
Domain/
Migrations/
Repository/
Services/
```

## 📝 Licença

Este projeto foi desenvolvido para fins de estudo.