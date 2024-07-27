# API de Gerenciamento de Tarefas

Esta API de Gerenciamento de Tarefas permite aos usuários criar, ler, atualizar e excluir tarefas. A API é projetada para ser consumida por um aplicativo [ASP.NET](http://asp.net/) MVC. Desenvolvida em .NET 8.0, a API utiliza AutoMapper para mapeamento de objetos, Entity Framework Core para interação com o banco de dados e Swashbuckle para documentação com Swagger.

## Tecnologias Usadas no Backend

- [ASP.NET](http://asp.net/) Core Web API: Framework leve para construir APIs da web.
- .NET 8.0: Versão mais recente do .NET framework usado para desenvolvimento.
- AutoMapper (v13.0.1): Biblioteca de mapeamento para simplificar a transferência de dados entre modelos.
- Microsoft.EntityFrameworkCore (v8.0.7): Mapeador objeto-relacional (ORM) para interagir com um banco de dados.
- Microsoft.EntityFrameworkCore.SqlServer (v8.0.7): Provedor para conectar a um banco de dados SQL Server.
- Swashbuckle.AspNetCore (v6.6.2): Pacote para gerar documentação OpenAPI (Swagger) para a API.

## Tecnologias Usadas no Frontend

- HTML
- CSS
- JavaScript
- jQuery
- Bootstrap

## Endpoints

### 1. Criar Tarefa

- **Método HTTP**: `POST`
- **Rota**: `/api/Tasks/PostTask`
- **Corpo da Requisição**:
    ```json
    {
      "name": "string",
      "description": "string",
      "status": 0,
      "isCompleted": false
    }
    ```
- **Resposta de Sucesso**: `201 Created`
    ```json
    {
      "id": "Guid",
      "name": "string",
      "description": "string",
      "status": enum,
      "isCompleted": bool,
      "createdAt": "datetime",
      "completedAt": null
    }
    ```

### 2. Obter Tarefas

- **Método HTTP**: `GET`
- **Rota**: `/api/Tasks/GetTasks`
- **Resposta de Sucesso**: `200 OK`
    ```json
    [
        {
          "id": "Guid",
          "name": "string",
          "description": "string",
          "status": enum,
          "isCompleted": bool,
          "createdAt": "datetime",
          "completedAt": null
        }
    ]
    ```

### 3. Obter Tarefa por ID

- **Método HTTP**: `GET`
- **Rota**: `/api/Tasks/GetTaskById/{id}`
- **Parâmetros de Rota**:
    - `id`: ID da tarefa
- **Resposta de Sucesso**: `200 OK`
    ```json
    {
      "id": "Guid",
      "name": "string",
      "description": "string",
      "status": enum,
      "isCompleted": bool,
      "createdAt": "datetime",
      "completedAt": null
    }
    ```

### 4. Atualizar Tarefa

- **Método HTTP**: `PUT`
- **Rota**: `/api/Tasks/PutTask/{id}`
- **Parâmetros de Rota**:
    - `id`: ID da tarefa
- **Corpo da Requisição**:
    ```json
    {
      "name": "string",
      "description": "string",
      "status": 0,
      "isCompleted": false
    }
    ```
- **Resposta de Sucesso**: `200 OK`
    ```json
    {
      "id": "Guid",
      "name": "string",
      "description": "string",
      "status": enum,
      "isCompleted": bool,
      "createdAt": "datetime",
      "completedAt": null
    }
    ```

### 5. Excluir Tarefa

- **Método HTTP**: `DELETE`
- **Rota**: `/api/Tasks/DeleteTask/{id}`
- **Parâmetros de Rota**:
    - `id`: ID da tarefa

## Configuração do Projeto

Depois de clonar o projeto, a ConnectionString do banco de dados deve ser alterada. Ela se encontra no `appsettings.Development.json` na camada da API.

Após essa configuração, execute a migração para criar o banco de dados localmente:

```bash
dotnet ef migrations add NomeMigration
dotnet ef database update
```
Para rodar os projetos de uma vez, você pode acessar as propriedades da solução. Em Startup Project, selecione Multiple startup projects e selecione start em ambos os projetos.

Para rodar os projetos separadamente, execute um dotnet watch run em cada pasta separadamente.

## Considerações Finais
Esta API foi desenvolvida para fornecer um exemplo simples de uma aplicação ASP.NET Core com funcionalidades de CRUD. Ela pode ser expandida e personalizada conforme necessário para atender às necessidades específicas de seu projeto.
