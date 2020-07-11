# Bike Segura
Sistema de registro de bicicletas desenvolvido para o trabalho de graduação do curso de análise e desenvolvimento de sistemas.

## Primeiros passos
Essas instruções farão com que você tenha uma cópia do projeto para executar na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos
Softwares necessários:
* Visual Studio
* MySQL Community Server

### Instalando

No MySQL, execute o arquivo `create-database.sql` que está na pasta `database` do projeto.
```
database -> create-database.sql
```

Este arquivo irá criar o banco de dados chamado `bikesegura`.

Após criar o banco de dados, execute o arquivo `inserts.sql` no MySQL, este arquivo irá popular o banco de dados. O arquivo está na pasta `database` no projeto.
```
database -> inserts.sql
```

No Visual Studio, abra o arquivo `BikeSegura.sln` que está na pasta `bike-segura` do projeto:
```
File -> Open -> Project/Solution -> bike-segura -> BikeSegura.sln
```

Após abrir o projeto, execute-o:
```
Debug -> Start Debugging
```

### Configuração
Acesse o arquivo `Web.config` para configurar a conexão com o MySQL
```
<connectionStrings>
    <add name="StringConexao" providerName="MySql.Data.MySqlClient" connectionString="server=localhost;database=bikesegura;uid=root;pwd='root'" />
</connectionStrings>
```

Altere `uid=root` para o usuário e a senha `pwd='root'` do MySql.

Configuração do e-mail de envio de e-mails
```
<system.net>
    <mailSettings>
      <smtp>
        <network host="smtp.gmail.com" port="587" userName="email@email.com" enableSsl="true" password="senha" />
      </smtp>
    </mailSettings>
</system.net>
```

Por padrão está o envio com e-mail do Gmail, coloque o e-mail que será usado para enviar os e-mail `userName="email@email.com"` e a senha `password="senha"`.

No arquivo `Funcoes.cs` em:
```
bike-segura -> BikeSegura -> Models -> Funcoes.cs
```

Em `MailAddress de = new MailAddress("email@email.com");` adicione o e-mail de envio.

```cs
public static string EnviarEmail(string emailDestinatario, string assunto, string corpomsg)
{
    // Cria o endereço de email do remetente
    MailAddress de = new MailAddress("email@email.com");
}
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

## Desenvolvido com
* ASP.NET MVC
* MySQL
* Entity Framework
* Bootstrap
