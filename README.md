# 🎬 **MyBremerBoxDB - Backend**

Este repositório contém o backend para o projeto **MyBremerBoxDB**, uma aplicação onde os usuários podem se cadastrar, fazer login e interagir com o sistema de filmes. Com esse backend, os usuários podem montar seu perfil com filmes, diretores e atores favoritos, além de escrever resenhas sobre os filmes que assistiram.

---

## 📝 **Funcionalidades**

- **Cadastro e Autenticação de Usuário**
  - Criação de conta de usuário com dados básicos.
  - Login seguro utilizando autenticação baseada em tokens.

- **Gerenciamento de Perfil**
  - Adicionar e listar filmes favoritos.
  - Escolher diretores e atores favoritos.
  - Personalizar o perfil com informações de gosto cinematográfico.

- **Interação com Filmes**
  - Adicionar filmes a uma lista de assistidos.
  - Escrever resenhas para os filmes vistos, incluindo notas e comentários.

---

## 🚀 **Rodando o Projeto**

### **Passo 1: Rodar o Banco de Dados com Docker**

Primeiro, vamos rodar o banco de dados PostgreSQL usando Docker. Se você ainda não tem o Docker instalado, siga [este guia](https://docs.docker.com/get-docker/) para instalá-lo.

1. **Puxar a imagem do PostgreSQL**:
   ```bash
   docker pull postgres
   ```

2. **Rodar o container do PostgreSQL**:
   ```bash
   docker run -p 5432:5432 -v /tmp/database:/var/lib/postgresql/data -e POSTGRES_PASSWORD=1234 postgres
   ```

   **Explicação do comando**:
   - `-p 5432:5432`: Mapeia a porta 5432 do container para a máquina local.
   - `-v /tmp/database:/var/lib/postgresql/data`: Cria um volume persistente para o banco de dados.
   - `-e POSTGRES_PASSWORD=1234`: Define a senha do superusuário do PostgreSQL (mude a senha conforme necessário).

### **Passo 2: Rodar as Migrations**

1. Abra o **Visual Studio 2022** e carregue o projeto **MyBremerBoxDB**.

2. Defina como projeto de inicialização a pasta **API**.

3. Acesse o **Console do Gerenciador de Pacotes** em **Ferramentas > Gerenciador de Pacotes do Nuget > Console do Gerenciador de Pacotes**.

4. Mude o projeto padrão para o projeto **Persistence**. 

5. Execute a migration com o seguinte comando:
   ```bash
   Update-Database
   ```

   Esse comando irá aplicar todas as migrations pendentes no banco de dados configurado.
   

### **Passo 3: Rodar a API**

Agora que o banco está configurado e as migrations foram aplicadas, podemos rodar a API:

1. Defina como projeto de inicialização novamente a pasta **API**.

2. Clique no botão **Run** ou pressione **Ctrl + F5** para iniciar a API.

A API estará rodando e você pode começar a testar os endpoints da aplicação.

---

## 📚 **Tecnologias Usadas**

- **.NET 8** (ou superior)
- **PostgreSQL**
- **Docker**
- **Entity Framework Core**
- **JWT (JSON Web Token)** para autenticação de usuários

---

## 📝 **Contribuindo**

Sinta-se à vontade para contribuir com melhorias no projeto! Se encontrar algum problema ou tiver sugestões, abra uma issue ou envie um pull request.

---

Agora é só aproveitar a API e explorar todas as funcionalidades do **MyBremerBoxDB**! 🍿
