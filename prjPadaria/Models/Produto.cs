using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class Produto
    {
        public Produto(int id, string nome, double preco, string categoria, int marcaId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
            MarcaId = marcaId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Categoria { get; set; }
        public int MarcaId { get; set; }


        public void AtualizarPreco(double novoPreco)
        {

        }
        public void AlterarCategoria(string categ)
        {

        }
        public void ExibirInfo() {
        
        }


        public static List<Produto> Listar()
        {
            string sql = "SELECT * FROM `Produto` ORDER BY `id`;";

            using (var command = new MySqlCommand(sql))
            {
                MySqlDataReader reader = Banco.ExecuteReader(command);

                List<Produto> produtos = new List<Produto>();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string nome = reader.GetString("nome");
                    double preco = reader.GetDouble("preco");
                    string categoria = reader.GetString("categoria");
                    int marcaId = reader.GetInt32("marcaId");


                    var produto = new Produto(id, nome, preco, categoria, marcaId);

                    produtos.Add(produto);
                }

                return produtos;
            }
        }




    }
}
