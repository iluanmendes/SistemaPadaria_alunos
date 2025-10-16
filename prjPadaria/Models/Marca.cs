using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class Marca
    {
        public Marca(string nome)
        {
            Nome = nome;
        }

        public Marca(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }


        public void ListarProdutos()
        {
            // Trazer todos os produtos
        }

        public int Inserir()
        {
            string sql = "INSERT INTO `Marca`(`Nome`) VALUES (@Nome); SELECT LAST_INSERT_ID();";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", Nome);

                return Banco.executarComando(cmd);
            }
        }

        public int Atualizar()
        {

            string sql = "UPDATE `Marca` SET `Nome`=@Nome WHERE id=@Id;";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Id", Id);

                return Banco.executarComando(cmd);
            }

        }

        public static List<Marca> ListarTodas()
        {
            string sql = "SELECT * FROM `Marca` ORDER BY `id`;";

            using (var command = new MySqlCommand(sql))
            {
                MySqlDataReader reader = Banco.ExecuteReader(command);

                List<Marca> marcas = new List<Marca>();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string nome = reader.GetString("nome");


                    var marca = new Marca(id, nome);

                    marcas.Add(marca);
                }

                return marcas;
            }
        }

        public static Marca ListarPorId(int id)
        {
            string sql = "SELECT * FROM `Marca` WHERE `Id` = @Id";

            using (var command = new MySqlCommand(sql))
            {
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = Banco.ExecuteReader(command);

                Marca marca = null;

                while (reader.Read())
                {

                    int Id = reader.GetInt32("id");
                    string nome = reader.GetString("Nome");

                    marca = new Marca(id, nome);

                    
                }

                return marca;
            }

        }
    }
}
