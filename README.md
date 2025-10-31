
---
# 📚 RestBiblioteca — Middleware para Simulação de Entregas

API REST desenvolvida em **C# / .NET 9**, estruturada em **camadas desacopladas** (`Controller`, `Service`, `Repository`) e atuando como **middleware entre o front-end React e o motor de rotas OSRM**.  
O sistema realiza o gerenciamento de **livros, autores, editoras, usuários e aluguéis**, além de validar endereços via **API do ViaCEP** e integrar-se ao **OSRM** para cálculo e simulação de rotas de entrega.

---

## ⚙️ Principais Funcionalidades

- CRUD completo de **Livros**, **Autores**, **Editoras** e **Usuários**  
- **Cadastro e aluguel** de livros com controle de disponibilidade  
- Validação de **endereço do usuário** via **CEP (API ViaCEP)**  
- Integração com **OSRM (Open Source Routing Machine)** para cálculo de rotas  
- Testes automatizados com **xUnit** e **FluentAssertions**

---

## 🧩 Arquitetura

```

RestBiblioteca/
├── controller/       # Controllers da API
├── service/          # Camada de regras de negócio
├── repository/       # Camada de persistência com EF Core
├── model/            # Entidades do domínio
├── AppDbContext.cs   # Contexto do Entity Framework
└── Program.cs        # Configuração principal da aplicação

````

- **Injeção de dependências nativa**  
- **Padrão Repository** aplicado  
- **Testes unitários** nas camadas de serviço  
- **Middleware de exceções** customizado  

---

## 🗺️ Integração com o OSRM (Rotas e Entregas)

A API consome o **motor de rotas OSRM (Open Source Routing Machine)**, executado localmente via Docker.  
O mapa utilizado é o da **região Nordeste do Brasil**, obtido em:  
👉 [Geofabrik South America Extracts](https://download.geofabrik.de/south-america.html)

### 🔧 Setup do OSRM via Docker

```bash
# 1️⃣ Extraia o mapa do Nordeste (arquivo nordeste-latest.osm.pbf)
#    e coloque-o na pasta atual

# 2️⃣ Gere o grafo de rotas
docker run -t -v "${PWD}:/data" ghcr.io/project-osrm/osrm-backend osrm-extract -p /opt/car.lua /data/nordeste-latest.osm.pbf

# 3️⃣ Particione e customize o mapa
docker run -t -v "${PWD}:/data" ghcr.io/project-osrm/osrm-backend osrm-partition /data/nordeste-latest.osrm
docker run -t -v "${PWD}:/data" ghcr.io/project-osrm/osrm-backend osrm-customize /data/nordeste-latest.osrm

# 4️⃣ Execute o servidor OSRM na porta 5000
docker run -t -i -p 5000:5000 -v "${PWD}:/data" ghcr.io/project-osrm/osrm-backend osrm-routed --algorithm mld /data/nordeste-latest.osrm
````

### 🌍 Teste o servidor

```bash
curl "http://127.0.0.1:5000/route/v1/driving/-38.512301,-12.986636;-38.5008,-12.9845?overview=full&geometries=polyline"
```

---

## 🌐 Integração com o Front-end

O **front-end React + Leaflet** consome esta API e o OSRM local para:

* Traçar rotas entre a biblioteca e o destino
* Simular deslocamento de entrega de livros
* Renderizar o trajeto em tempo real com OpenStreetMap

🔗 Repositório do front-end: [RestBibliotecaFront](https://github.com/yancarvalho13/RestBibliotecaFront)

---

## 🧪 Testes Automatizados

Implementados com **xUnit** e **FluentAssertions**, cobrindo:

* `AuthorService`
* `BookService`
* `PublisherService`
* `UserService`

---

## 🚀 Execução da API

```bash
dotnet run
```

Acesse a documentação da API:

* Swagger UI → [http://localhost:5165/swagger](http://localhost:5165/swagger)
* Endpoint base → [http://localhost:5165/index.html](http://localhost:5165/index.html)

---

## 🗃️ Banco de Dados (PostgreSQL via Docker)

Crie o container do PostgreSQL com o `docker-compose.yml`:

```yaml
version: '3.8'
services:
  postgres:
    image: postgres:16-alpine
    container_name: biblioteca-postgres
    environment:
      POSTGRES_DB: biblioteca
      POSTGRES_USER: admin
      POSTGRES_PASSWORD: 123456
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
dotnet ef database update
```

---

## 📄 Licença

Distribuído sob a licença **MIT**.

```
