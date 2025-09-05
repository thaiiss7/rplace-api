# rplace-api
Projeto Final C# avançado

Passos:
- Git:
  - Criar repositório no git;
  - No power shell:
      - cd desktop
      - git clone link
      - cd pastaClonada
      - code .
        
- Para comitar:
  - git add .
  - git config --global user.name "NomeDoUsuario"
  - git config --global user.email "email"
  - git commit -m "fiz algo"
  - git push

- VSCode:
  - No terminal inserir os seguintes comandos:
      - dotnet new web
      - dotnet new gitignore
      - dotnet add package Microsoft.EntityFrameworkCore
      - dotnet add package Microsoft.EntityFrameworkCore.Tools
      - dotnet add package Microsoft.EntityFrameworkCore.Design
      - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
     
     - Extras:
      - dotnet add package xunit
      - dotnet add package xunit.runner.visualstudio
      - dotnet add package Microsoft.NET.Test.Sdk
      - dotnet add package Moq
   
      - dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

      - dotnet add package Swashbuckle.AspNetCore

        
  - Criar Models (classes);
      - Observações:
          - Para cada FK deve fazer uma navigation no mesmo arquivo, consequentemente deve fazer um IColection com o nome do arquivo onde está a FK no arquivo que tem o nome da navigation.
            
  - Criar o DbContext dentro da pasta Models (serve para conectar com o BD);
      - conexões entre as tabelas = model.Entity<Aqui você coloca a tabela que esta com os id das outras tabelas> (tem que fazer isso para cada FK)
      - obs: relação N-N não precisa de .OnDelete nem de FK
        
  - Configurar DbContext e conexão com o SQL (variável de ambiente): $env:SQL_CONNECTION = "Data Source=localhost;Initial Catalog=Fofoquinha;Trust Server Certificate=true;Integrated Security=true"
    
  - Criar e rodar migrations, no terminal:
      - dotnet tool install --global dotnet-ef
      - dotnet ef migrations add InitialModel
      - dotnet ef database update
      - OBS: se mudar algo na pasta Models, deve fazer add InitialModel e update novamente
        
  - Definir UseCases (ações como: criar, editar, deletar)
    
  - Definir Payloads (dados enviados) e Responses (respostas) dos UseCases (processamento/operação)
    
  - Implementar Endpoints (ex: MapPost) usando UseCases (no mínimo 1 endpoint para cada UseCase):
      - OBS: A quantidade de páginas .cs na pasta Endpoints deve ter a mesma quantidade de classes da pasta Models
      - Exemplo para iniciar a implementação: "Plan: mapget (plan/{id}) -> GetPlan"
        
  - Definir serviços
      - JWT (É o token de autentificação)
          - NÃO COLOCAR SENHA
          - O que é Claim?
      - Password (É a criptografia da senha)
        
  - Implementar Payload e Response
    
  - Implementar UseCases

  - Implementar e Configurar Serviços (Configurar JWT)

  - Habilitar Swagger
