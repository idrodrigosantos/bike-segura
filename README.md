# Bike Segura
Sistema de registro de bicicletas.

## Primeiros Passos
Essas instruções farão com que você tenha uma cópia do projeto em execução na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos
Softwares necessários:
* Visual Studio
* MySQL

### Instalando
No Visual Studio, abra o arquivo `BikeSegura.sln` do projeto:
```
File -> Open -> Project/Solution -> bike-segura -> mvc -> BikeSegura.sln
```
Acesse o arquivo `Web.config` na raiz do projeto, e altere `database=bikesegura` para o nome do banco de dados que será criado ou mantenha o padrão `bikesegura`, altere a senha do banco de dados em `pwd='root'` para a senha do seu banco de dados, por padrão está a senha `root`:
```
<connectionStrings>
	<add name="StringConexao" providerName="MySql.Data.MySqlClient" connectionString="server=localhost;database=bikesegura;uid=root;pwd='root'" />
</connectionStrings>
```
Execute o projeto:
```
Debug -> Start Debugging
```
Após executar o projeto e o banco de dados for criado, pare a execução do projeto:
```
Debug -> Stop Debugging
```
Acesse o MySQL e execute o arquivo `inserts.sql`, este arquivo irá popular o banco:
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
Na página inicial, clique no botão `Cadastre-se`, na barra de navegação, no canto superior direito e preenchar os campos obrigatórios.

Após o cadastro será redirecionado para a página de `Login`, digite o e-mail e senha cadastrados anteriormente.

## Desenvolvido com
* [ASP.NET MVC](https://github.com/aspnet/Mvc)
* [Bootstrap](https://github.com/twbs/bootstrap)
* [jQuery](https://github.com/jquery/jquery)
* [Font-Awesome](https://github.com/FortAwesome/Font-Awesome)
* [Chart.js](https://github.com/chartjs/Chart.js)
* [Toastr](https://github.com/CodeSeven/toastr)
* [Holder](https://github.com/imsky/holder)
