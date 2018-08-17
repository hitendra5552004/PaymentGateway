
## Descrição

Gateway especializado em e-commerce que poderá processar pagamentos de vários lojistas, cada lojista poderá ter contrato com mais de um adquirente e ainda poderá ter ou não contrato com sistemas antifraudes. 
A aplicação foi desenvolvida utilizando as seguintes tecnologias: C#, .NET CORE 2, MySql.

#### Build e Deploy

Para buildar e executar a aplicação é necessário a IDE do ViualStudio e o .NET CORE instalados bem como o banco de dados open source MySql.
A aplicação WebApi quando inicializada através do VisualStudio irá criar automaticamente uma instância do banco MySql com alguns dados já semeados para permitir testes.
![alt text](/Instructions/MySqlEvidence.png "MySqlEvidence")


## Testes

#### Testes Postman
Utilizando o programa Postman é possível realizar testes Http enquanto a WebApi estiver sendo executada.
![alt text](/Instructions/PostmanTestEvidence.png "PostmanTestEvidence")


#### Testes de Unidade
A aplicação contém projetos de testes unitários que podem ser executados diretamente da IDE do VisualStudio.
![alt text](/Instructions/UnitTestEvidence.png "UnitTestEvidence")
