# Teste de Admiss�o da Soitic
Sistema simples de cadastro de livros.

1. Baixar o pacote

2. Configurar a connectionStrings em web.config
O campo source deve ser alterado para o nome da m�quina que est� sendo rodado.

<connectionStrings>
    <add name="TesteAdmissaoDb" connectionString="data source=(LocalDb)\v11.0;Integrated Security=SSPI; Initial Catalog=TesteAdmissaoDb" providerName="System.Data.SqlClient" />
</connectionStrings>

3. Rodar a migration BDInicial

4. A migration deve ser rodada no projeto "Contexto" 

5. Como rodar a migration:

	TOOLS -> NuGet Package Manager -> Package Manager Console

	Enable-Migrations

	Update-Database -Script

