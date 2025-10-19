
# RestBiblioteca

API REST desenvolvida em **.NET 9** para gerenciamento de livros, autores e editoras de uma biblioteca.
O projeto utiliza **PostgreSQL** como banco de dados e **Entity Framework Core** para mapeamento objeto-relacional.

## Tecnologias

* .NET 9 / ASP.NET Core
* Entity Framework Core
* PostgreSQL
* Swagger / OpenAPI

## Pré-requisitos

* [.NET 9 SDK](https://dotnet.microsoft.com/download)
* [Docker](https://www.docker.com/get-started)

## Configuração do Banco com Docker

Crie um arquivo `docker-compose.yml` na raiz com o conteúdo abaixo:

```yaml
version: '3.8'
services:
  postgres:
    image: postgres:16-alpine
    container_name: biblioteca-postgres
    environment:
      POSTGRES_DB: biblioteca
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: postgres
    ports:
      - "5432:5432"
    volumes:
      - postgres_data:/var/lib/postgresql/data
volumes:
  postgres_data:
```

Execute:

```bash
docker-compose up -d
```

## Configuração do Projeto

Edite o arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Postgres": "Host=localhost;Port=5432;Database=biblioteca;Username=postgres;Password=postgres"
  }
}
```

Execute as migrations:

```bash
dotnet ef database update
```

## Execução

```bash
dotnet run
```

Acesse a documentação da API:

```
http://localhost:5165/swagger
```

## Estrutura

```
RestBiblioteca/
├── controller/       # Controllers da API
├── model/            # Entidades
├── repository/       # Repositórios
├── service/          # Serviços
├── AppDbContext.cs   # Contexto EF Core
└── Program.cs        # Configuração principal
```

## Endpoints

* `GET /api/books` – Lista livros
* `GET /api/authors` – Lista autores
* `GET /api/publishers` – Lista editoras

## Licença

Projeto sob a licença MIT.

---
