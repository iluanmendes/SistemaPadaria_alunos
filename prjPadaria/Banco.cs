using MySqlConnector;
using System.Data;

public class Banco
{
    // Tornamos a string de conexão privada e de leitura
    private readonly string _stringDeConexao = "Server=192.168.0.166;Port=3306;Database=db_playground;Uid=admin;Pwd=123456;";

    // Construtores... (seus construtores existentes estão OK)
    public Banco(string stringDeConexao)
    {
        _stringDeConexao = stringDeConexao;
    }

    public Banco() { }

    // Método central para comandos que não retornam resultados (INSERT, UPDATE, DELETE)
    public int executarComando(MySqlCommand command)
    {
        // Usa o 'using' para garantir que a conexão seja aberta, usada e fechada
        using (var conexao = new MySqlConnection(_stringDeConexao))
        {
            command.Connection = conexao;
            try
            {
                conexao.Open();
                // O método ExecuteNonQuery retorna o número de linhas afetadas
                return command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de Banco de Dados: {ex.Message}");
                return -1; // Retorna um valor indicando falha
            }
        }
    }

    // Método central para comandos que retornam resultados (SELECT)
    // Retorna o MySqlDataReader para que o chamador possa processar os dados
    public MySqlDataReader ExecuteReader(MySqlCommand command)
    {
        var conexao = new MySqlConnection(_stringDeConexao);
        command.Connection = conexao;

        try
        {
            conexao.Open();
            // CommandBehavior.CloseConnection garante que a conexão será fechada
            // quando o DataReader for fechado/descartado.
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (MySqlException)
        {
            // Se falhar, é crucial fechar a conexão, pois o DataReader não foi retornado
            conexao.Close();
            throw; // Relança a exceção para que o chamador saiba que falhou
        }
    }
}