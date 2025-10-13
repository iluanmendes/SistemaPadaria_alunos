using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class ItemPedido
    {
        public ItemPedido(int id, int pedidoId, int produtoId, int quantidade, double precoUnitario)
        {
            Id = id;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public double Subtotal()   {

            return PrecoUnitario * Quantidade;
        }
    }
}
