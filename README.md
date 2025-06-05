# 📝 SolidBlogsApi

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![NuGet](https://img.shields.io/badge/NuGet-004880?style=for-the-badge&logo=nuget&logoColor=white)
![SOLID](https://img.shields.io/badge/SOLID%20Principles-FF6B6B?style=for-the-badge&logo=architecture&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Clean%20Architecture-00599C?style=for-the-badge&logo=architecture&logoColor=white)

Uma API robusta para gerenciamento de blogs desenvolvida em C# seguindo rigorosamente os princípios SOLID e Clean Architecture, com foco em escalabilidade, testabilidade e manutenibilidade.

## 📋 Índice

- [Características](#-características)
- [Princípios SOLID](#-princípios-solid)
- [Arquitetura](#-arquitetura)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Pré-requisitos](#-pré-requisitos)
- [Instalação](#-instalação)
- [Execução](#-execução)
- [API Endpoints](#-api-endpoints)
- [Testes](#-testes)
- [Contribuição](#-contribuição)
- [Licença](#-licença)

## ✨ Características

### 🏗️ Layered Architecture
- **Clean Architecture**: Separação clara de responsabilidades em camadas
- **Domain-Driven Design**: Foco nas regras de negócio do domínio de blogs
- **SOLID Principles**: Implementação rigorosa dos 5 princípios SOLID
- **Separation of Concerns**: Cada camada tem sua responsabilidade específica
- **Hexagonal Architecture**: Ports and Adapters para máxima flexibilidade

### 🚀 Robust API
- **RESTful API**: Endpoints bem estruturados seguindo padrões REST
- **OpenAPI 3.0**: Documentação automática com Swagger
- **Content Negotiation**: Suporte para múltiplos formatos (JSON, XML)
- **Validation**: Validação robusta de entrada de dados
- **Error Handling**: Tratamento consistente de erros com Problem Details
- **CORS Support**: Suporte para requisições cross-origin
- **Rate Limiting**: Controle de taxa de requisições
- **Caching**: Estratégias de cache para otimização de performance

### 🧪 Comprehensive Testing
- **Unit Tests**: Testes unitários para lógica de negócio
- **Integration Tests**: Testes de integração para APIs
- **Test Coverage**: Cobertura de código superior a 90%
- **Mocking**: Isolamento completo de dependências nos testes
- **Test Fixtures**: Reutilização de cenários de teste
- **BDD Testing**: Testes comportamentais com SpecFlow

### 👥 User Management
- **Authentication**: Sistema de autenticação JWT seguro
- **Authorization**: Controle de acesso baseado em roles e policies
- **Identity Management**: Gerenciamento completo de identidades
- **User Profiles**: Perfis de usuário com informações detalhadas
- **Password Security**: Hash seguro de senhas com bcrypt
- **Account Management**: Registro, login, recuperação de senha

### 💉 Dependency Injection
- **IoC Container**: Inversão de controle nativa do .NET
- **Service Registration**: Registro automático de serviços
- **Lifetime Management**: Gerenciamento do ciclo de vida dos objetos
- **Decorator Pattern**: Decoradores para funcionalidades transversais
- **Factory Pattern**: Factories para criação de objetos complexos

### 📦 Data Transfer Objects (DTOs)
- **API Contracts**: Contratos bem definidos para APIs
- **Data Mapping**: Mapeamento automático entre entidades e DTOs
- **Validation Attributes**: Validação declarativa nos DTOs
- **Versioning**: Versionamento de DTOs para compatibilidade
- **Serialization**: Serialização otimizada para JSON/XML

## 🔧 Princípios SOLID

### 🔸 Single Responsibility Principle (SRP)
Cada classe tem uma única responsabilidade bem definida:
- **Controllers**: Apenas controle de fluxo HTTP
- **Services**: Lógica de negócio específica
- **Repositories**: Acesso a dados exclusivamente
- **Validators**: Validação de regras de negócio

### 🔸 Open/Closed Principle (OCP)
Sistema aberto para extensão, fechado para modificação:
- **Interfaces**: Contratos estáveis para extensibilidade
- **Strategy Pattern**: Algoritmos intercambiáveis
- **Plugin Architecture**: Funcionalidades plugáveis
- **Decorator Pattern**: Comportamentos adicionais sem modificação

### 🔸 Liskov Substitution Principle (LSP)
Substituição de objetos por suas implementações:
- **Interface Segregation**: Interfaces específicas e coesas
- **Polymorphism**: Uso consistente de polimorfismo
- **Contract Compliance**: Cumprimento de contratos estabelecidos

### 🔸 Interface Segregation Principle (ISP)
Interfaces específicas e coesas:
- **Granular Interfaces**: Interfaces pequenas e focadas
- **Client-Specific**: Interfaces específicas para cada cliente
- **No Fat Interfaces**: Evita interfaces com muitos métodos

### 🔸 Dependency Inversion Principle (DIP)
Dependência de abstrações, não de concretizações:
- **Abstractions**: Dependência de interfaces
- **IoC Container**: Inversão de controle
- **Dependency Injection**: Injeção de dependências

## 🏛️ Arquitetura

O sistema segue os princípios da **Clean Architecture** com implementação rigorosa dos **Princípios SOLID**:

```
┌─────────────────────────────────────┐
│             API Layer               │ ← Controllers, Middleware, Filters
├─────────────────────────────────────┤
│         Application Layer           │ ← Use Cases, Services, DTOs, Interfaces
├─────────────────────────────────────┤
│          Domain Layer               │ ← Entities, Value Objects, Domain Rules
├─────────────────────────────────────┤
│       Infrastructure Layer          │ ← Repositories, External Services, Data
└─────────────────────────────────────┘
```

### Fluxo de Dependências (SOLID)

```
API → Application → Domain ← Infrastructure
 ↓         ↓           ↑            ↑
DI     Interfaces  Abstractions  Implementations
```

## 📁 Estrutura do Projeto

```
SolidBlogsApi/
├── 🎯 SolidBlogsApi.API/                   # API REST Layer
│   ├── Controllers/                        # HTTP Controllers
│   │   ├── BlogsController.cs             # Blog management endpoints
│   │   ├── PostsController.cs             # Post management endpoints
│   │   ├── CommentsController.cs          # Comment management endpoints
│   │   └── AuthController.cs              # Authentication endpoints
│   ├── Middleware/                         # Custom Middleware
│   │   ├── ErrorHandlingMiddleware.cs     # Global error handling
│   │   ├── LoggingMiddleware.cs           # Request/Response logging
│   │   └── RateLimitingMiddleware.cs      # Rate limiting
│   ├── Filters/                           # Action Filters
│   │   ├── ValidationFilter.cs           # Model validation
│   │   └── AuthorizationFilter.cs        # Custom authorization
│   ├── Extensions/                        # Service Extensions
│   │   ├── ServiceCollectionExtensions.cs # DI registration
│   │   └── SwaggerExtensions.cs          # Swagger configuration
│   └── Program.cs                         # Application entry point
│
├── 💼 SolidBlogsApi.Application/          # Business Logic Layer
│   ├── Services/                          # Application Services
│   │   ├── Interfaces/                    # Service abstractions
│   │   │   ├── IBlogService.cs           # Blog service contract
│   │   │   ├── IPostService.cs           # Post service contract
│   │   │   ├── ICommentService.cs        # Comment service contract
│   │   │   └── IAuthService.cs           # Auth service contract
│   │   └── Implementations/               # Service implementations
│   │       ├── BlogService.cs            # Blog business logic
│   │       ├── PostService.cs            # Post business logic
│   │       ├── CommentService.cs         # Comment business logic
│   │       └── AuthService.cs            # Authentication logic
│   ├── DTOs/                             # Data Transfer Objects
│   │   ├── Blog/                         # Blog-related DTOs
│   │   │   ├── BlogDto.cs               # Blog DTO
│   │   │   ├── CreateBlogDto.cs         # Create blog DTO
│   │   │   └── UpdateBlogDto.cs         # Update blog DTO
│   │   ├── Post/                         # Post-related DTOs
│   │   │   ├── PostDto.cs               # Post DTO
│   │   │   ├── CreatePostDto.cs         # Create post DTO
│   │   │   └── UpdatePostDto.cs         # Update post DTO
│   │   └── Comment/                      # Comment-related DTOs
│   │       ├── CommentDto.cs            # Comment DTO
│   │       └── CreateCommentDto.cs      # Create comment DTO
│   ├── Mappings/                         # AutoMapper Profiles
│   │   ├── BlogMappingProfile.cs        # Blog mapping configuration
│   │   ├── PostMappingProfile.cs        # Post mapping configuration
│   │   └── CommentMappingProfile.cs     # Comment mapping configuration
│   ├── Validators/                       # FluentValidation Rules
│   │   ├── BlogValidators.cs            # Blog validation rules
│   │   ├── PostValidators.cs            # Post validation rules
│   │   └── CommentValidators.cs         # Comment validation rules
│   └── Exceptions/                       # Custom Exceptions
│       ├── BlogNotFoundException.cs      # Blog not found exception
│       ├── PostNotFoundException.cs      # Post not found exception
│       └── UnauthorizedException.cs      # Unauthorized exception
│
├── 🏛️ SolidBlogsApi.Domain/               # Domain Layer
│   ├── Entities/                         # Domain Entities
│   │   ├── Blog.cs                      # Blog entity
│   │   ├── Post.cs                      # Post entity
│   │   ├── Comment.cs                   # Comment entity
│   │   └── User.cs                      # User entity
│   ├── ValueObjects/                     # Value Objects
│   │   ├── Email.cs                     # Email value object
│   │   ├── Slug.cs                      # URL slug value object
│   │   └── Content.cs                   # Content value object
│   ├── Enums/                           # Domain Enumerations
│   │   ├── PostStatus.cs               # Post status enumeration
│   │   ├── CommentStatus.cs            # Comment status enumeration
│   │   └── UserRole.cs                 # User role enumeration
│   ├── Interfaces/                      # Domain Interfaces
│   │   ├── Repositories/               # Repository abstractions
│   │   │   ├── IBlogRepository.cs      # Blog repository contract
│   │   │   ├── IPostRepository.cs      # Post repository contract
│   │   │   ├── ICommentRepository.cs   # Comment repository contract
│   │   │   └── IUserRepository.cs      # User repository contract
│   │   └── Services/                   # Domain service interfaces
│   │       ├── IEmailService.cs        # Email service contract
│   │       └── ISlugService.cs         # Slug generation contract
│   └── Specifications/                  # Business Rules
│       ├── BlogSpecifications.cs       # Blog business rules
│       ├── PostSpecifications.cs       # Post business rules
│       └── CommentSpecifications.cs    # Comment business rules
│
├── 🔧 SolidBlogsApi.Infrastructure/       # Infrastructure Layer
│   ├── Data/                            # Data Access Layer
│   │   ├── Context/                     # Database Context
│   │   │   └── BlogDbContext.cs        # Entity Framework context
│   │   ├── Repositories/               # Repository Implementations
│   │   │   ├── BlogRepository.cs       # Blog data access
│   │   │   ├── PostRepository.cs       # Post data access
│   │   │   ├── CommentRepository.cs    # Comment data access
│   │   │   └── UserRepository.cs       # User data access
│   │   ├── Configurations/             # Entity Configurations
│   │   │   ├── BlogConfiguration.cs    # Blog entity configuration
│   │   │   ├── PostConfiguration.cs    # Post entity configuration
│   │   │   ├── CommentConfiguration.cs # Comment entity configuration
│   │   │   └── UserConfiguration.cs    # User entity configuration
│   │   └── Migrations/                 # Database Migrations
│   ├── Services/                       # External Services
│   │   ├── EmailService.cs            # Email service implementation
│   │   ├── SlugService.cs             # Slug generation service
│   │   └── CacheService.cs            # Caching service
│   ├── Authentication/                 # Authentication Infrastructure
│   │   ├── JwtTokenService.cs         # JWT token management
│   │   └── PasswordService.cs         # Password hashing service
│   └── Extensions/                     # Infrastructure Extensions
│       ├── DatabaseExtensions.cs      # Database setup extensions
│       └── AuthenticationExtensions.cs # Auth setup extensions
│
└── 🧪 SolidBlogsApi.Tests/               # Testing Layer
    ├── Unit/                           # Unit Tests
    │   ├── Domain/                     # Domain entity tests
    │   │   ├── BlogTests.cs           # Blog entity tests
    │   │   ├── PostTests.cs           # Post entity tests
    │   │   └── CommentTests.cs        # Comment entity tests
    │   ├── Application/                # Application service tests
    │   │   ├── BlogServiceTests.cs    # Blog service tests
    │   │   ├── PostServiceTests.cs    # Post service tests
    │   │   └── CommentServiceTests.cs # Comment service tests
    │   └── API/                        # Controller tests
    │       ├── BlogsControllerTests.cs # Blog controller tests
    │       ├── PostsControllerTests.cs # Post controller tests
    │       └── CommentsControllerTests.cs # Comment controller tests
    ├── Integration/                    # Integration Tests
    │   ├── API/                       # API integration tests
    │   │   ├── BlogApiTests.cs       # Blog API integration tests
    │   │   ├── PostApiTests.cs       # Post API integration tests
    │   │   └── CommentApiTests.cs    # Comment API integration tests
    │   └── Infrastructure/            # Data access tests
    │       ├── BlogRepositoryTests.cs # Blog repository tests
    │       ├── PostRepositoryTests.cs # Post repository tests
    │       └── CommentRepositoryTests.cs # Comment repository tests
    └── Helpers/                       # Test Helpers
        ├── TestFixtures/              # Test fixtures
        │   ├── BlogFixtures.cs       # Blog test data
        │   ├── PostFixtures.cs       # Post test data
        │   └── CommentFixtures.cs    # Comment test data
        ├── MockData/                  # Mock data generators
        │   └── BlogMockData.cs       # Blog mock data
        └── TestBase.cs               # Base test class
```

## 🛠️ Tecnologias Utilizadas

### Core Technologies
- ![.NET 6](https://img.shields.io/badge/.NET%206-512BD4?style=flat-square&logo=dotnet&logoColor=white) **.NET 6** - Framework principal
- ![C#](https://img.shields.io/badge/C%23%2010-239120?style=flat-square&logo=c-sharp&logoColor=white) **C# 10** - Linguagem de programação
- ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white) **ASP.NET Core** - Web API framework

### Database & ORM
- ![Entity Framework](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=flat-square&logo=microsoft&logoColor=white) **Entity Framework Core** - ORM
- ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white) **SQL Server** - Banco de dados principal
- ![SQLite](https://img.shields.io/badge/SQLite-003B57?style=flat-square&logo=sqlite&logoColor=white) **SQLite** - Banco para testes

### Authentication & Security
- ![JWT](https://img.shields.io/badge/JWT-000000?style=flat-square&logo=json-web-tokens&logoColor=white) **JWT Bearer Tokens** - Autenticação
- ![Identity](https://img.shields.io/badge/ASP.NET%20Identity-512BD4?style=flat-square&logo=microsoft&logoColor=white) **ASP.NET Core Identity** - Gerenciamento de usuários
- ![bcrypt](https://img.shields.io/badge/bcrypt-FF6B6B?style=flat-square) **BCrypt** - Hash de senhas

### Documentation & Validation
- ![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black) **Swagger/OpenAPI** - Documentação da API
- ![FluentValidation](https://img.shields.io/badge/FluentValidation-FF6B6B?style=flat-square) **FluentValidation** - Validação de dados
- ![AutoMapper](https://img.shields.io/badge/AutoMapper-BE9A2F?style=flat-square) **AutoMapper** - Object mapping

### Testing & Quality
- ![xUnit](https://img.shields.io/badge/xUnit-512BD4?style=flat-square) **xUnit** - Framework de testes
- ![Moq](https://img.shields.io/badge/Moq-FF6B6B?style=flat-square) **Moq** - Mocking framework
- ![Bogus](https://img.shields.io/badge/Bogus-32CD32?style=flat-square) **Bogus** - Geração de dados fake
- ![FluentAssertions](https://img.shields.io/badge/FluentAssertions-1E90FF?style=flat-square) **FluentAssertions** - Assertions fluentes

### Caching & Performance
- ![Redis](https://img.shields.io/badge/Redis-DC382D?style=flat-square&logo=redis&logoColor=white) **Redis** - Cache distribuído
- ![MemoryCache](https://img.shields.io/badge/MemoryCache-512BD4?style=flat-square) **MemoryCache** - Cache em memória

### Logging & Monitoring
- ![Serilog](https://img.shields.io/badge/Serilog-0E83CD?style=flat-square) **Serilog** - Logging estruturado
- ![Application Insights](https://img.shields.io/badge/Application%20Insights-0078D4?style=flat-square&logo=microsoft-azure&logoColor=white) **Application Insights** - Monitoramento

### Package Management
- ![NuGet](https://img.shields.io/badge/NuGet-004880?style=flat-square&logo=nuget&logoColor=white) **NuGet** - Gerenciador de pacotes

## 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- ![.NET](https://img.shields.io/badge/.NET%206%20SDK-512BD4?style=flat-square&logo=dotnet&logoColor=white) [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white) [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) ou SQL Server LocalDB
- ![Redis](https://img.shields.io/badge/Redis-DC382D?style=flat-square&logo=redis&logoColor=white) [Redis](https://redis.io/download) (opcional para cache)
- ![Visual Studio](https://img.shields.io/badge/Visual%20Studio%202022-5C2D91?style=flat-square&logo=visual-studio&logoColor=white) [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

## 🚀 Instalação

### 1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/solid-blogs-api.git
cd solid-blogs-api
```

### 2. Restaure os pacotes NuGet
```bash
dotnet restore
```

### 3. Configure as variáveis de ambiente
Crie um arquivo `appsettings.Development.json` na camada API:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqlLocaldb;Database=SolidBlogsDb;Trusted_Connection=true;",
    "Redis": "localhost:6379"
  },
  "JwtSettings": {
    "SecretKey": "sua-chave-secreta-super-segura-aqui",
    "Issuer": "SolidBlogsApi",
    "Audience": "SolidBlogsApi",
    "ExpiryInMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### 4. Execute as migrations
```bash
dotnet ef database update --project SolidBlogsApi.Infrastructure --startup-project SolidBlogsApi.API
```

### 5. Compile o projeto
```bash
dotnet build
```

## ▶️ Execução

### Executar a API
```bash
cd SolidBlogsApi.API
dotnet run
```

A API estará disponível em:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`
- **Swagger UI**: `https://localhost:5001/swagger`

### Executar com Hot Reload (Desenvolvimento)
```bash
dotnet watch run --project SolidBlogsApi.API
```

### Executar com Docker
```bash
docker-compose up -d
```

## 🔌 API Endpoints

### 🔐 Authentication
```http
POST   /api/auth/register       # Registra novo usuário
POST   /api/auth/login          # Autentica usuário
POST   /api/auth/refresh        # Renova token JWT
POST   /api/auth/logout         # Logout do usuário
POST   /api/auth/forgot-password # Solicita recuperação de senha
POST   /api/auth/reset-password  # Redefine senha
```

### 📝 Blogs
```http
GET    /api/blogs               # Lista todos os blogs
GET    /api/blogs/{id}          # Busca blog por ID
GET    /api/blogs/slug/{slug}   # Busca blog por slug
POST   /api/blogs               # Cria novo blog
PUT    /api/blogs/{id}          # Atualiza blog
DELETE /api/blogs/{id}          # Remove blog
GET    /api/blogs/{id}/posts    # Lista posts do blog
```

### 📰 Posts
```http
GET    /api/posts               # Lista todos os posts
GET    /api/posts/{id}          # Busca post por ID
GET    /api/posts/slug/{slug}   # Busca post por slug
POST   /api/posts               # Cria novo post
PUT    /api/posts/{id}          # Atualiza post
DELETE /api/posts/{id}          # Remove post
POST   /api/posts/{id}/publish  # Publica post
POST   /api/posts/{id}/unpublish # Despublica post
GET    /api/posts/{id}/comments # Lista comentários do post
```

### 💬 Comments
```http
GET    /api/comments            # Lista comentários (admin)
GET    /api/comments/{id}       # Busca comentário por ID
POST   /api/comments            # Cria novo comentário
PUT    /api/comments/{id}       # Atualiza comentário
DELETE /api/comments/{id}       # Remove comentário
POST   /api/comments/{id}/approve # Aprova comentário
POST   /api/comments/{id}/reject  # Rejeita comentário
```

### 👤 Users
```http
GET    /api/users/profile       # Perfil do usuário atual
PUT    /api/users/profile       # Atualiza perfil
GET    /api/users/{id}/blogs    # Blogs do usuário
GET    /api/users/{id}/posts    # Posts do usuário
```

### 📊 Example Request/Response

**POST** `/api/blogs`
```json
{
  "title": "Meu Blog de Tecnologia",
  "description": "Um blog sobre as últimas tendências em tecnologia",
  "slug": "meu-blog-tecnologia"
}
```

**Response** `201 Created`
```json
{
  "id": 1,
  "title": "Meu Blog de Tecnologia",
  "description": "Um blog sobre as últimas tendências em tecnologia",
  "slug": "meu-blog-tecnologia",
  "authorId": 123,
  "authorName": "João Silva",
  "createdAt": "2024-06-05T14:30:00Z",
  "updatedAt": "2024-06-05T14:30:00Z",
  "postsCount": 0
}
```

**POST** `/api/posts`
```json
{
  "title": "Introdução ao Clean Architecture",
  "content": "Clean Architecture é um padrão arquitetural...",
  "slug": "introducao-clean-architecture",
  "blogId": 1,
  "tags": ["architecture", "clean-code", "software-design"],
  "status": "Draft"
}
```

**Response** `201 Created`
```json
{
  "id": 1,
  "title": "Introdução ao Clean Architecture",
  "content": "Clean Architecture é um padrão arquitetural...",
  "slug": "introducao-clean-architecture",
  "blogId": 1,
  "blogTitle": "Meu Blog de Tecnologia",
  "authorId": 123,
  "authorName": "João Silva",
  "tags": ["architecture", "clean-code", "software-design"],
  "status": "Draft",
  "createdAt": "2024-06-05T14:30:00Z",
  "updatedAt": "2024-06-05T14:30:00Z",
  "commentsCount": 0
}
```

## 🧪 Testes

### Executar todos os testes
```bash
dotnet test
```

### Executar testes com cobertura
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Executar testes específicos
```bash
# Testes unitários
dotnet test SolidBlogsApi.Tests/Unit/

# Testes de integração
dotnet test SolidBlogsApi.Tests/Integration/

# Testes de um projeto específico
dotnet test SolidBlogsApi.Tests/Unit/Application/BlogServiceTests.cs
```

### Gerar relatório de cobertura
```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

### Executar testes de performance
```bash
dotnet test --filter Category=Performance
```

## 📈 Métricas de Qualidade

### Cobertura de Testes
- **Cobertura Geral**: > 90%
- **Cobertura de Domínio**: > 95%
- **Cobertura de Aplicação**: > 90%
- **Cobertura de API**: > 85%

### Princípios SOLID - Verificação
- ✅ **SRP**: Cada classe tem uma única responsabilidade
- ✅ **OCP**: Sistema extensível sem modificação
- ✅ **LSP**: Substituição segura de implementações
- ✅ **ISP**: Interfaces específicas e coesas
- ✅ **DIP**: Dependência de abstrações

## 🔍 Análise de Código

### Ferramentas de Qualidade
```bash
# Análise estática com SonarQube
dotnet sonarscanner begin /k:"solid-blogs-api"
dotnet build
dotnet sonarscanner end

# Análise de segurança
dotnet list package --vulnerable

# Análise de performance
dotnet-trace collect --process-id <PID>
```

## 🐳 Docker

### Executar com Docker Compose
```bash
# Desenvolvimento
docker-compose -f docker-compose.yml -f docker-compose.override.yml up

# Produção
docker-compose -f docker-compose.yml -f docker-compose.prod.yml up
```

### Dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SolidBlogsApi.API/SolidBlogsApi.API.csproj", "SolidBlogsApi.API/"]
RUN dotnet restore "SolidBlogsApi.API/SolidBlogsApi.API.csproj"
COPY . .
WORKDIR "/src/SolidBlogsApi.API"
RUN dotnet build "SolidBlogsApi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SolidBlogsApi.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dot



https://roadmap.sh/projects/blogging-platform-api
