# MyFinance Web .NET

Sistema de controle financeiro pessoal com funcionalidades para gerenciamento de planos de contas e transações financeiras. Este projeto foi desenvolvido com o framework ASP.NET Core MVC, utilizando arquitetura MVC e padrões de serviço para abstração da lógica de negócios.

---

## 📝 Descrição do Projeto

O sistema permite:

- Cadastro, listagem e exclusão de **Planos de Conta** (Receita/Despesa)
- Registro de **Transações Financeiras** associadas a um Plano de Conta
- Visualização das transações realizadas

---

## 🏗️ Arquitetura

O projeto segue a arquitetura **MVC (Model-View-Controller)** e inclui:

- **Models:** representam as entidades do domínio (e.g. `PlanoContaModel`, `TransacaoModel`)
- **Controllers:** recebem as requisições HTTP e acionam os serviços de negócio (e.g. `PlanoContaController`, `TransacaoController`)
- **Services:** abstraem e centralizam a lógica de negócio (`iPlanoContaService`, `iTransacaoService`, etc.)
- **Views:** páginas Razor responsáveis pela exibição dos dados ao usuário
- **DbContext:** camada de infraestrutura para interação com banco de dados via Entity Framework (`MyFinanceDbContext`)

---

## ⚙️ Tecnologias Necessárias

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **C#**
- **Razor Pages**
- **SQL Server (ou outro banco relacional compatível)**
- **Bootstrap (para estilo das views, opcional)**

---

## 🛠️ Como configurar e rodar o projeto

### Pré-requisitos

- [.NET SDK 7.0+](https://dotnet.microsoft.com/download)
- Editor de código (ex: Visual Studio, VS Code)
- SQL Server (ou outro banco relacional)
- Ferramenta de migração de banco de dados (opcional: `dotnet ef`)

### Passos

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/gabdelemos/myfinance-web-dotnet-of8.git
   cd myfinance-web-dotnet
   ```

2. **Configure a string de conexão:**

   No arquivo `appsettings.json`, atualize a conexão com o banco:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=MyFinanceDb;Trusted_Connection=True;"
   }
   ```

3. **Crie o banco de dados e aplique as migrações:**

   Caso esteja usando EF Core:

   ```bash
   dotnet ef database update
   ```

4. **Rode a aplicação:**

   ```bash
   dotnet run
   ```

5. **Acesse no navegador:**

   ```
   http://localhost:5039
   ```

---

## 🔍 Estrutura de Diretórios (Simplificada)

```
myfinance-web-dotnet/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── PlanoContaController.cs
│   └── TransacaoController.cs
│
├── Domain/
│   ├── PlanoContaModel.cs
│   └── TransacaoModel.cs
│
├── Models/
│   ├── ErrorViewModel.cs
│   ├── PlanoContaModel.cs
│   └── TransacaoModel.cs
│
├── Infrastructure/
│   └── MyFinanceDbContext.cs
│
├── Services/
│   ├── iPlanoContaService.cs
│   ├── iRepository.cs
│   ├── iTransacaoService.cs
│   ├── PlanoContaService.cs
│   ├── RepositoryService.cs
│   └── TransacaoService.cs
│
├── Views/
│   └── (Arquivos Razor .cshtml)
│
├── appsettings.json
└── Program.cs
```