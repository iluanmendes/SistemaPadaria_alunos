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





    }
}
