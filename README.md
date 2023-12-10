# FinUnsize - Documenta��o

![FinUnsize](https://i.imgur.com/XlAENqn.png)

## Introdu��o

Este documento fornece informa��es detalhadas sobre o projeto Blazor Server desenvolvido com .NET 7. 
O Blazor Server � uma estrutura de aplicativo da Web baseada em .NET que permite a cria��o de aplicativos 
da web interativos e ricos em recursos usando C# e HTML. Este projeto espec�fico demonstra a constru��o de uma aplica��o simples com Blazor Server.

## Pr�-Requisitos

Antes de come�ar, certifique-se de ter os seguintes itens instalados em sua m�quina:

- [.NET 7 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/) ou [Visual Studio Code](https://code.visualstudio.com) (opcional)

## Parte 1 Clonando o reposit�rio

1. Abra o terminal ou prompt de comando.
2. Execute o seguinte comando para clonar o reposit�rio:

```SHELL
git clone https://github.com/TriSeat/FinUnsize_System
```


## Parte 2: Navegando para o Diret�rio do Projeto

1. Navegue at� o diret�rio do projeto com o seguinte comando:

```SHELL
cd FinUnsize_System
```

## Parte 3: Executando o Projeto

#### Usando Visual Studio

1. Abra o arquivo de solu��o (nome-do-projeto.sln) no Visual Studio.
2. Certifique-se de que o projeto Blazor Server � definido como projeto de inicializa��o.
3. Pressione F5 ou clique em "Iniciar" para executar o projeto.


#### Usando Visual Studio Code

1. Abra o diret�rio do projeto no Visual Studio Code.
2. Abra o terminal integrado.
3. Execute o seguinte comando para iniciar o aplicativo:

```BASH
dotnet run
```

**Observa��o:** Para que o sistema esteja conectado ao banco e as regras de neg�cio, � necess�rio
que a API esteja rodando em localhost. Para tal, siga os passos de como a subir no reposit�rio [FinUnsize_API](https://github.com/TriSeat/FinUnsize_API/bl).
P�s subir, adicione a url base no arquivo: **appsettings.json**. Exemplo:

```JSON
  "AllowedHosts": "*",
  "ApiSettings": {
    "BaseUrl": "URL DA API EM LOCALHOST"
  }
```

## Parte 4: Acessando a Aplica��o

Ap�s a execu��o bem-sucedida do projeto, acesse a aplica��o em seu navegador utilizando o seguinte URL:

http://localhost:5000

Para mais informa��es sobre Blazor e .NET 7, consulte a [documenta��o oficial do Blazor](https://learn.microsoft.com/pt-br/aspnet/core/blazor/?view=aspnetcore-8.0) e a [documenta��o do .NET](https://learn.microsoft.com/pt-br/dotnet/).

## Descri��o - RoadMap

Este sistema tem como foco realizar a gest�o de estabelecimentos, sendo na parte logistica e financeira.
Com isso, cont�m telas especializadas, cujo qual, cumprem tais fun��es, sendo respectivamente:

- Home (Proposta da empresa);
- Login;
- Cadastro (Dados Empresariais, Dados Pessoais, Pagamento e Finaliza��o);
- Home (Dashboard)
- Produtos (Especifica��es: Vizualiza��o, cadastro e atualiza��o (CRUD));
- Usu�rios (Podendo ser acessada somente pelo usu�rio Plano);
- Usu�rio (Credenciais do usu�rio da sess�o);
- Caixas;
- Funcion�rios;

Para ver mais acerca das telas e seu RoadMap, assista o [V�deo da Apresenta��o do Sistema](https://drive.google.com/file/d/1QT3Wwr4PlWZdhVAUEbdWzNc7cxShJ9nc/view?usp=drive_link).