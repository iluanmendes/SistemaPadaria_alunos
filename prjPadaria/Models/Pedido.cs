using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace prjPadaria.Models
{
    public  class Pedido
    {
        public Pedido(int id, int clienteId, int usuarioId, DateTime dataPedido, List<ItemPedido> itens)
        {
            Id = id;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            DataPedido = dataPedido;
            Itens = itens;
            
        }

        public Pedido(int clienteId, int usuarioId, DateTime dataPedido, List<ItemPedido> itens)
        {
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            DataPedido = dataPedido;
            Itens = itens;
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public List<ItemPedido> Itens {  get; set; }  = new List<ItemPedido>();

        public string Status { get; set; } = "";



        public void AdicionarItem(Produto produto, int qtd)
        {

        }
        public void RemoverItem(int itemId)
        {

        }

        public double CalcularTotal()
        {
            double vTotal = 0;
            foreach(var item in Itens)
            {
                vTotal += item.Subtotal();
            }

            return vTotal;
        }

        public static bool FecharPedido(Pedido pedido)
        {
            int qtdItens = pedido.Itens.Count;

            if (qtdItens > 0)
            {

                // Inserir Pedido e retorar o id do mesmo
                int pedidoId = Inserir(pedido.ClienteId, pedido.ClienteId, DateTime.Now, "Concluido");


                // Inserindo itens na tabela de itens pedido
                foreach(var item in pedido.Itens)
                {                                     

                    item.PedidoId = pedidoId;


                    ItemPedido.Inserir(item);
                }

                return true;
            }
            else
            {
                return false;
            }
            



        }


        private static int Inserir(int clienteId, int usuarioId, DateTime dataPedido, string status)
        {
            string sql = "INSERT INTO `Pedido`(`ClienteId`, `UsuarioId`, `DataPedido`, `Status`) VALUES (@ClienteId, @UsuarioId, @DataPedido, @Status); SELECT LAST_INSERT_ID(); ";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@DataPedido", dataPedido);
                cmd.Parameters.AddWithValue("@Status", status);

                return Banco.executarComandoComRetornoId(cmd);
            }
        }





    }
}
