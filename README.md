# Projeto TodoList

Este projeto implementa um sistema de tarefas utilizando ASP.NET Core e MongoDB. O projeto é dividido em camadas de Controller, Service e Repository.

## Funcionalidades

- **Controllers**: Responsáveis por receber requisições HTTP e chamar os métodos adequados nos serviços.
- **Services**: Implementam a lógica de negócio da aplicação, processando requisições e manipulando dados.
- **Repository**: Camada de acesso aos dados, interage diretamente com o banco de dados MongoDB.

## Métodos de DTO

Existem métodos DTO para operações de criação (POST) e atualização (PUT) de tarefas no sistema. Essas estruturas foram aplicadas para garantir melhor uso das services por parte dos usuários e ajudar a manter a integridade dos dados.

## Documentação Swagger

O projeto está documentado com Swagger para facilitar o entendimento e teste das APIs. Para acessar a documentação, execute o projeto e navegue para `/swagger/index.html`.

## Testes

O projeto inclui testes unitários na service TodolistTaskService. Para executar os testes, utilize o comando:

```bash
dotnet test
```

## Rodando o Projeto

Para rodar o projeto em um ambiente de desenvolvimento, utilize o comando:

```bash
dotnet run
```

A configuração da porta localhost é:

```bash
http://localhost:5012
```

## Banco de Dados MongoDB

O projeto utiliza um banco de dados MongoDB hospedado no MongoDB Atlas. Já existem as configurações de uma conexão temporário em `appsettings.json`, mas é possível configurar manualmente alterando as settings em

```JSON
"MongoDB": {
    "ConnectionURI": "...",
    "DatabaseName": "...",
    "CollectionName": "..."
  }
```

## Autor

    - Igor Corbari Brasil (igorbrasilc@hotmail.com)
