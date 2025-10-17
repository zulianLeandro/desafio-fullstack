# Desafio FullStack (.NET + Angular)

## Descrição
Aplicação Full Stack para cadastro de produtos, permitindo **listar, criar, editar e excluir** produtos.  
Desenvolvido como desafio técnico para demonstrar boas práticas em **.NET 6+, Entity Framework, Angular 12+**, incluindo **arquitetura limpa (Clean Architecture), testes automatizados e componentes standalone**.

---

## Tecnologias utilizadas

**Backend (.NET 6+)**
- C# / .NET 6
- Entity Framework Core (InMemory)
- xUnit para testes automatizados
- Clean Architecture (Domain, Application, Infrastructure, Presentation)
- Swagger para documentação da API

**Frontend (Angular 12+)**
- Angular 12+ com componentes standalone
- Angular Material
- Formulários reativos (Reactive Forms)
- RxJS para requisições assíncronas
- Rotas e navegação com `routerLink`
- BrowserAnimationsModule para animações

---

## Estrutura do projeto

```
desafio-fullstack/
├── backend/      # API .NET
│   ├── Backend/
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Presentation/
│   └── Backend.Tests/  # Testes xUnit
└── frontend/     # Angular 12+
    ├── src/
    │   ├── app/
    │   │   ├── pages/
    │   │   │   ├── produto-list/
    │   │   │   └── produto-form/
    │   │   └── app.routes.ts
    │   └── main.ts
```

---

## Como rodar o projeto

### Backend
```bash
cd backend/Backend
dotnet restore
dotnet run
```
- A API estará disponível em `http://localhost:5009`  
- Documentação Swagger: `http://localhost:5009/swagger`

### Frontend
```bash
cd frontend
npm install
ng serve
```
- O frontend estará disponível em `http://localhost:4200/`  

---

## Testes
Para rodar os testes do backend:

```bash
cd backend/Backend.Tests
dotnet test
```

---

## Observações
- Arquitetura limpa aplicada (Domain, Application, Infrastructure, Presentation)  
- Testes unitários básicos com xUnit  
- Componentes Angular standalone, integrados com rotas  
- Formulários reativos validados  

---

## Autor
**Leandro Zulian** – Desenvolvedor Fullstack

