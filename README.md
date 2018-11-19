# Bike Segura
Sistema de registro de bicicletas.

## Primeiros Passos
Essas instruções farão com que você tenha uma cópia do projeto para executar na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos
Softwares necessários:
* Visual Studio
* MySQL

### Instalando
No MySQL, execute o arquivo `create-database.sql` que está na pasta `banco-de-dados` no projeto:
```
bike-segura -> banco-de-dados -> create-database.sql
```
Este arquivo irá criar um banco de dados no MySQL chamado `bikesegura`.

Após criar o banco de dados, execute o arquivo `inserts.sql` no MySQL, este arquivo irá popular o banco de dados:
```
bike-segura -> banco-de-dados -> inserts.sql
```
No Visual Studio, abra o arquivo `BikeSegura.sln`:
```
File -> Open -> Project/Solution -> bike-segura -> mvc -> BikeSegura.sln
```
Execute o projeto no Visual Studio:
```
Debug -> Start Debugging
```
Após executar o projeto e o banco de dados for criado, pare a execução do projeto:
```
Debug -> Stop Debugging
```
Execute o arquivo `inserts.sql` no MySQL, este arquivo irá popular o banco:
```
bike-segura -> banco-de-dados -> inserts.sql
```
Após o banco de dados estiver populado, execute o projeto novamente e realize os testes.

## Executando os testes
Para acessar o sistema, pode ser por um administrador ou usuário comum.

Administrador:
```
Usuário: adm@email.com
Senha: bike2018
```
Usuário Comum:
```
Usuário: usuario@email.com
Senha: bike2018
```
Ou acesse por algum usuário do banco de dados, por padrão todos estão com a senha `bike2018`:
```
Usuário: usuáriodesejado@email.com
Senha: bike2018
```

### Caso queira criar um novo usuário
Na página inicial, clique no botão `Cadastre-se`, na barra de navegação, no canto superior direito. Preencha os campos obrigatórios.

Após o cadastro ser efetuado a página será redirecionada, na página de `Login`, digite o e-mail e senha cadastrados anteriormente, acesse o sistema e faça os testes desejados.

## Desenvolvido com
* ASP.NET MVC
* MySQL
* Entity Framework
* Bootstrap
