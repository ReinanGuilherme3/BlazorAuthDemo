# Autenticação e Autorização no Blazor Server

![Capa](docs/images/capa.png)

Autenticação e autorização são essenciais em qualquer aplicação.  
No **Blazor Server**, conseguimos proteger **rotas** e **componentes** de forma simples e poderosa.

Este projeto **BlazorAuthDemo** foi criado como uma demonstração para mostrar como configurar:

- Login e Logout com Cookies  
- Policies baseadas em Claims (`VIEW`, `ADD`, `EDIT`, `CREATE`)  
- Proteção de páginas com `[Authorize]`  
- Controle de UI com `<AuthorizeView>`  
- Tela de **Access Denied** personalizada  

---

## Estrutura do Projeto

Uma parte importante desse demo foi **organizar a solução de forma clara**, separando responsabilidades.  

Isso ajuda a manter o código **limpo** e fácil de evoluir.


## Resumo da Arquitetura

- **Policies** → definem regras de acesso (VIEW, ADD, EDIT, CREATE) baseadas em *claims*.  
- **Config** → concentra configuração de autenticação/autorização (cookies, paths e policies).  
- **Controllers** → expõem os *endpoints* de login/logout.  
- **Imports** → centralizam os namespaces mais usados.  
- **Routes** → controlam comportamento global para usuários não autenticados/não autorizados.  
- **Program** → enxuto e expressivo, apenas registrando serviços e delegando responsabilidades.  

Cada camada tem uma **responsabilidade clara**, deixando o projeto **modular, limpo e escalável**.

---

## ⚙️ Configuração Inicial

### Policies (`AuthPolicy.cs`)
![AuthPolicy](docs/images/AuthPolicy.png)

Definem os tipos de permissões que o sistema vai usar.  
Dessa forma, fica fácil manter e expandir regras de autorização.

---

### Controllers (`AuthController.cs`)
![AuthController](docs/images/AuthController.png)

Aqui controlamos **Login e Logout**, gerando as *claims* que serão usadas pelas policies.

---

### Config (`AuthConfig.cs`)
![AuthConfig](docs/images/AuthConfig.png)

Centraliza a configuração de autenticação/autorização:  
- Cookies  
- Tempo de sessão  
- Redirecionamento para `/login` ou `/access-denied`  

---

### Imports (`_Imports.razor`)
![Imports](docs/images/imports.png)

No arquivo `_Imports.razor`, além dos namespaces padrões, adicionamos os relacionados à autenticação, autorização e policies.  

👉 Isso garante que em qualquer página possamos usar `[Authorize]`, `<AuthorizeView>` e validar policies sem precisar importar manualmente.

---

### Routes (`Routes.razor`)
![Routes](docs/images/routes.png)

Personalizamos o roteamento para lidar com casos de **usuário não autorizado**.  

👉 Aqui, qualquer rota protegida por `[Authorize]` que não for acessível redireciona automaticamente para a página **AccessDenied**, sem precisar repetir lógica em todas as páginas.

---

### Program (`Program.cs`)
![Program](docs/images/program.png)

No Program.cs ficou bem limpo, porque concentrei a configuração no AuthConfig e os endpoints no AuthController:

Dessa forma, o Program.cs fica responsável apenas por registrar serviços e iniciar a aplicação, mantendo a separação de preocupações.

---

## 🎨 Páginas (UI)

### Login
![Login](docs/images/login.png)

Tela inicial de autenticação.

---

### Access Denied
![AccessDenied](docs/images/accessDenied.png)

Mostra mensagens diferentes para **usuário logado sem permissão** e **usuário não logado**.

---

### Usuário sem acesso para Create
![NoCreate1](docs/images/noCreate1.png)  
![NoCreate2](docs/images/noCreate2.png)

---

### Usuário com acesso para Create
![WithCreate1](docs/images/withCreate1.png)  
![WithCreate2](docs/images/withCreate2.png)

---

## Conclusão

Com o **BlazorAuthDemo**, vimos como estruturar autenticação e autorização no Blazor Server:

- Proteger rotas com `[Authorize]`  
- Controlar componentes com `<AuthorizeView>`  
- Criar policies baseadas em claims  
- Separar responsabilidades em **Policies, Config, Controllers, Imports, Routes e Program**  

Essa abordagem deixa o projeto **organizado, escalável e fácil de evoluir**. 🚀  
