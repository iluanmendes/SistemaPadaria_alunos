using MySqlConnector;
using prjPadaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Data
{
    internal class ClienteData
    {

        private Banco banco = new Banco();

        public int Inserir(Cliente cliente)
        {
         
             string sql = "INSERT INTO `tb_clientes` (Nome, Telefone, Email) VALUES (@Nome, @Telefone, @Email); SELECT LAST_INSERT_ID();";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);

                return banco.executarComando(cmd);
            }


            

        }

    }
}
