using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class Cliente
    {
        public Cliente(int id, string nome, string telefone, string email)
        {

            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;

        }

        public Cliente(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public void AtualizarDados() { }
        public void ListarPedidos(int id, string nome, string telefone, string email) { }


        /// <summary>
        /// Realiza a inserção de um cliente no banco de dados
        /// </summary>
        /// <param name="Cliente">Recebe um objeto cliente por parâmtro </param>
        /// <returns></returns>
        public static int Adicionar(Cliente cliente) {

            string sql = "INSERT INTO `Cliente` (`Nome`, `Telefone`, `Email`) VALUES (@Nome, @Telefone, @Email)";

            using (var cmd = new MySqlCommand(sql))
            {

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);

                return Banco.executarComando(cmd);

            }

        }


    }
}
