using MySqlConnector;
using System;

public class Bancoconect
{
    private readonly string connectionString = "Server=localhost;Port=3306;Database=testdb;Uid=root;Pwd=minhasenha;";

    public void ConnectAndTest()
    {
        // Cria a conexão usando a declaração 'using'
        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                // Tenta abrir a conexão
                Console.WriteLine("Tentando conectar ao MariaDB...");
                connection.Open();

                // Se chegar aqui, a conexão foi bem-sucedida
                Console.WriteLine("Conexão bem-sucedida!");

                // Exemplo de execução de um comando simples (opcional)
                using (var command = new MySqlCommand("SELECT VERSION();", connection))
                {
                    string version = command.ExecuteScalar()?.ToString();
                    Console.WriteLine($"Versão do MariaDB: {version}");
                }
            }
            catch (MySqlException ex)
            {
                // Captura e exibe qualquer erro de conexão
                Console.WriteLine("Erro ao conectar ao MariaDB:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // A declaração 'using' garante que connection.Close() e connection.Dispose()
                // sejam chamados, mesmo em caso de exceção.
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Fechando conexão (automático pelo 'using').");
                }
            }
        }
    }
}