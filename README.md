# Projeto TodoList

Este projeto implementa um sistema de tarefas utilizando ASP.NET Core e MongoDB. O projeto é dividido em camadas de Controller, Service e Repository.

## Funcionalidades

- **Controllers**: Responsáveis por receber requisições HTTP e chamar os métodos adequados nos serviços.
- **Services**: Implementam a lógica de negócio da aplicação, processando requisições e manipulando dados.
- **Repository**: Camada de acesso aos dados, interage diretamente com o banco de dados MongoDB.

## Métodos de DTO

Existem métodos DTO para operações de criação (POST) e atualização (PUT) de tarefas no sistema. Essas estruturas foram aplicadas para garantir melhor uso das services por parte dos usuários e ajudar a manter a integridade dos dados.

## Testes

O projeto inclui testes unitários na service TodolistTaskService. Para executar os testes, utilize o comando:

```bash
dotnet test
```

## Rodando o Projeto

Para rodar o projeto em um ambiente de desenvolvimento, um Dockerfile e um docker-compose.yml foram criados para permitir uma rápida execução independente do ambiente. Para utilizar, você precisa do docker funcionando na sua máquina.

Para rodar o projeto, utilize o comando abaixo e espere pelo build:

```bash
docker-compose up --build
```

Assim que finalizar, a aplicação deve estar rodando na endereço abaixo, acesse pelo seu navegador de preferência:

```bash
http://localhost:8080
```

## Documentação Swagger

O projeto está documentado com Swagger para facilitar o entendimento e teste das APIs. Para acessar a documentação, execute o projeto e navegue para `http://localhost:8080/swagger`.

## Banco de Dados MongoDB

O projeto utiliza um banco de dados MongoDB hospedado no MongoDB Atlas. Já existem as configurações de uma conexão temporária em `appsettings.json` para fins de validação da API, mas é possível configurar manualmente alterando as settings no arquivo:

```JSON
"MongoDB": {
    "ConnectionURI": "...",
    "DatabaseName": "...",
    "CollectionName": "..."
  }
```

## Autor

    - Igor Corbari Brasil (igorbrasilc@hotmail.com)
