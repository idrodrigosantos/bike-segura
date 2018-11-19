# Bike Segura
Sistema de registro de bicicletas.

## Primeiros passos
Essas instruções farão com que você tenha uma cópia do projeto para executar na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos
Softwares necessários:
* Visual Studio
* MySQL Community Server

### Instalando
No MySQL, execute o arquivo `create-database.sql` que está na pasta `banco-de-dados` do projeto:
```
bike-segura -> banco-de-dados -> create-database.sql
```
Este arquivo irá criar o banco de dados chamado `bikesegura`.

Após criar o banco de dados, execute o arquivo `inserts.sql` no MySQL, este arquivo irá popular o banco de dados:
```
bike-segura -> banco-de-dados -> inserts.sql
```
No Visual Studio, abra o arquivo `BikeSegura.sln` que está na pasta `mvc` do projeto:
```
File -> Open -> Project/Solution -> bike-segura -> mvc -> BikeSegura.sln
```
Após abrir o projeto, execute-o:
```
Debug -> Start Debugging
```

## Executando os testes
### Acessar o sistema
Para acessar o sistema, pode ser por um administrador ou usuário comum. Na página inicial, clique no botão `Entrar`, na barra de navegação, no canto superior direito, preencha os campos `E-mail` e `Senha`.

Administrador:
```
E-mail: adm@email.com
Senha: bike2018
```
Usuário comum:
```
E-mail: usuario@email.com
Senha: bike2018
```
Ou acesse por algum usuário do banco de dados, por padrão todos estão com a senha `bike2018`.

### Criar novo usuário
Caso queira criar um novo usuário, na página inicial, clique no botão `Cadastre-se`, na barra de navegação, no canto superior direito, preencha os campos obrigatórios.

Após o cadastro ser efetuado com sucesso, a página será redirecionada para a página de login. Na página de login, digite o e-mail e senha cadastrados anteriormente, acesse o sistema e faça os testes e alterações desejados.

## Desenvolvido com
* ASP.NET MVC
* MySQL
* Entity Framework
* Bootstrap
