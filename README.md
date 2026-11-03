# RoomReservas (C# .NET Core)

⚠️ **Estado atual**: Este repositório contém o projeto original em C# .NET Core da aplicação de reserva de salas. A estrutura de Clean Architecture, CQRS e SOLID foi implementada, mas o projeto ainda está em fase inicial com evidências limitadas de testes automatizados e execução em produção.

O mesmo código foi posteriormente reimplementado em Java Spring Boot (ver repositório `RoomReservasJava`), que possui documentação mais completa e CI/CD configurado.

---

## 📋 Visão Geral

O **RoomReservas** é um sistema de reserva de salas de reunião desenvolvido com **.NET 8 / C#**, seguindo princípios de:

- **Clean Architecture** — Separação clara entre domínio, aplicação, infraestrutura e apresentação
- **CQRS** — Separação de comandos (escrita) e queries (leitura)
- **SOLID** — Princípios de design orientado a objeto
- **MediatR** — Padrão de mensageria para desacoplamento de handlers
- **FluentValidation** — Validação expressiva e legível

---

## 🏗️ Arquitetura do Projeto

A solução é dividida em **5 projetos** principais:

```
RoomReservas.sln
├── RoomReservas.Domain          # Entidades, enumerações, exceções do domínio
├── RoomReservas.Application     # Cases de uso (commands/queries), DTOs, validações
├── RoomReservas.Infrastructure  # Entity Framework Core, repositórios, persistência
├── RoomReservas.API             # API REST (Controllers), Swagger/OpenAPI
└── RoomReservas.Tests           # Testes unitários (xUnit)
```

### Dependências entre projetos

```
           → RoomReservas.Domain
RoomReservas.API ──────────► RoomReservas.Application
           ←───────────────────
                          → RoomReservas.Infrastructure
```

- **API** depende de Application e Domain
- **Application** depende de Domain
- **Infrastructure** depende de Domain (para interfaces/repositórios)

---

## 📦 Tecnologias Utilizadas

| Camada | Tecnologias |
|---|---|
| **.NET** | .NET 8, C# 12 |
| **Banco de Dados** | Entity Framework Core, PostgreSQL / SQL Server |
| **Arquitetura** | Clean Architecture, CQRS, SOLID, MediatR |
| **Validação** | FluentValidation |
| **Testes** | xUnit, Moq (testes unitários) |
| **API** | ASP.NET Core Web API |
| **Documentação** | Swagger/OpenAPI 3.0 |

---

## 🚀 Como Executar

### Pré-requisitos

- .NET 8 SDK ou superior
- PostgreSQL ou SQL Server (conexão via `appsettings.json`)

### Passos

1. **Clone o repositório**

   ```bash
   git clone https://github.com/gabrielflorencco/RoomReservas.git
   cd RoomReservas
   ```

2. **Restaure as dependências**

   ```bash
   dotnet restore
   ```

3. **Configure o banco de dados**

   Edite `appsettings.json` ou `appsettings.Development.json` com suas credenciais:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=RoomReservas;User=sa;Password=sua_senha;"
     }
   }
   ```

4. **Aplique as migrações**

   ```bash
   dotnet ef database update
   ```

   > *Nota: As migrações ainda estão em fase inicial. Verifique o arquivo `Banco.sql` na raiz do repositório para o esquema atual.*

5. **Execute a API**

   ```bash
   dotnet run --project RoomReservas.API
   ```

   A aplicação estará disponível em `http://localhost:5000` (ou a porta configurada).

6. **Acesse a documentação Swagger**

   ```
   http://localhost:5000/swagger
   ```

---

## 🧪 Testes

### Testes Unitários

```bash
dotnet test --project RoomReservas.Tests
```

> ⚠️ **Atenção**: O repositório possui testes unitários básicos, mas a cobertura de testes ainda é limitada. O foco principal da implementação de Clean Architecture e CQRS foi estabelecer a estrutura, não garantir testes abrangentes nesta fase inicial.

### Cobertura de Testes

Não há métricas de cobertura de código publicadas. Os testes existentes cobrem:

- Validação de entidades (nome, email)
- Operações básicas de criação de usuários, salas e reservas

---

## 📂 Estrutura de Dados (Entidades)

### `Usuario`

- `Id` (Guid) — Identificador único
- `Nome` (string) — Nome completo, mínimo 2 caracteres
- `Email` (string) — Deve ser um endereço de e-mail válido e único

### `Sala`

- `Id` (Guid) — Identificador único
- `Nome` (string) — Nome da sala
- `Capacidade` (int) — Número máximo de pessoas (≥ 1)
- `Ativa` (bool) — Indica se a sala está disponível para reservas

### `Reserva`

- `Id` (Guid) — Identificador único
- `UsuarioId` (Guid) — Referência ao usuário que fez a reserva
- `SalaId` (Guid) — Referência à sala reservada
- `Inicio` (DateTime) — Data e hora de início
- `Fim` (DateTime) — Data e hora de fim
- `ValorTotal` (double) — Cálculo: `(Fim - Inicio).TotalHours * 39.99`
- `Status` (enum) — `Pendente`, `Confirmada`, `Cancelada`, `Concluída`

---

## ✅ Regras de Negócio (Resumo)

| Regra | Descrição |
|---|---|
| **Conflito de horários** | É impossível reservar uma sala já ocupada no período solicitado |
| **Sala inativa** | Salas desativadas não aceitam novas reservas; reservas futuras ativas são canceladas automaticamente |
| **Limite de reservas** | Usuário pode ter no máximo **3 reservas ativas** (PENDENTE ou CONFIRMADA) simultâneas |
| **Cancelamento com prazo** | Cancelamento só é permitido com **pelo menos 24 horas de antecedência** |
| **Cálculo de valor** | `valorTotal = horas * 39.99` (valor hora da sala) |
| **Duração mínima** | Reserva deve ter **pelo menos 30 minutos** |

---

## 🛠️ Endpoints da API

### Usuários

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/api/usuarios` | Criar usuário |
| `GET` | `/api/usuarios` | Listar todos os usuários |
| `GET` | `/api/usuarios/{id}` | Buscar usuário por ID |
| `PUT` | `/api/usuarios/{id}` | Atualizar usuário |

### Salas

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/api/salas` | Criar sala |
| `GET` | `/api/salas` | Listar todas as salas |
| `GET` | `/api/salas/{id}` | Buscar sala por ID |
| `PUT` | `/api/salas/{id}` | Atualizar sala |
| `PATCH` | `/api/salas/{id}/status` | Ativar/desativar sala |

### Reservas

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/api/reservas` | Criar reserva |
| `GET` | `/api/reservas` | Listar todas as reservas |
| `GET` | `/api/reservas/{id}` | Buscar reserva por ID |
| `GET` | `/api/reservas/usuario/{usuarioId}` | Listar reservas por usuário |
| `GET` | `/api/reservas/sala/{salaId}` | Listar reservas por sala |
| `PATCH` | `/api/reservas/{id}/confirmar` | Confirmar reserva |
| `PATCH` | `/api/reservas/{id}/cancelar` | Cancelar reserva (regra 24h) |

### Swagger UI

```
http://localhost:5000/swagger
```

---

## ⚠️ Limitações Conhecidas

1. **Sem CI/CD configurado** — Não há pipeline de testes automáticos ou deployment
2. **Cobertura de testes limitada** — Testes unitários básicos, sem testes de integração ou E2E
3. **Migrações de banco ainda em desenvolvimento** — O esquema pode mudar; consulte `Banco.sql`
4. **Valor fixo por hora** — O `ValorTotal` usa preço fixo de R$ 39,99/hora (configurável via banco)
5. **Sem autenticação/autorização** — A API atual não implementa autenticação de usuários
6. **Projeto acadêmico/estudo** — Focado na aplicação de Clean Architecture, CQRS e SOLID

---

## 📅 Planejado para Futuras Fases

- Implementar autenticação JWT / Identity Framework
- Adicionar testes de integração e E2E
- Implementar cache distribuído para performance
- Adicionar rate limiting e middlewares de segurança
- Implementar Dockerização completa
- Adicionar GitHub Actions (CI/CD)
- Implementar política de limpeza de reservas expiradas

---

## 📄 Licença

Este projeto está licenciado sob os termos da licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👨‍💻 Autor

**Gabriel Florenço** — Desenvolvedor .NET / Java  
GitHub: [@gabrielflorencco](https://github.com/gabrielflorencco)  
Contexto: Projeto desenvolvido como prática de Clean Architecture, CQRS e SOLID em .NET 8

---

## 🔄 Relationship with RoomReservasJava

Este repositório (RoomReservas) é a **implementação original em C# .NET Core**. A reimplementação em Java Spring Boot está disponível em:

- **RoomReservasJava**: https://github.com/gabrielflorencco/RoomReservasJava

O projeto em Java possui:
- Documentação README mais completa
- CI/CD configurado (GitHub Actions)
- Testes automatizados (JUnit 5 + Mockito)
- Deploy e configurações de produção

Recomenda-se consultar o `RoomReservasJava` para o estado atual e mais maduro do projeto.

---

**Última atualização:** 2026-11-02  
**Status:** Em desenvolvimento inicial — estrutura arquitetural implementada, funcionalidades básicas operacionais.