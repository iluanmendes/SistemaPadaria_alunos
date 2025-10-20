using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class ItemPedido
    {
        public ItemPedido(int pedidoId, int produtoId, int quantidade, double precoUnitario)
        {
            
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public ItemPedido(int id,int pedidoId,int produtoId, int quantidade, double precoUnitario)
        {
            Id = id;            
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public double Subtotal()
        {

            return PrecoUnitario * Quantidade;
        }

        public static int Inserir(ItemPedido item)
        {
            string sql = "INSERT INTO `ItemPedido`(`PedidoId`, `ProdutoId`, `Quantidade`, `PrecoUnit`) VALUES (@PedidoId, @ProdutoId, @Quantidade, @PrecoUnitario); ";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@PedidoId", item.PedidoId);
                cmd.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
                cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                cmd.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);

                return Banco.executarComandoComRetornoId(cmd);
            }
        }
    }
}
