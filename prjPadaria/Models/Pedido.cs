using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace prjPadaria.Models
{
    public  class Pedido
    {
        public Pedido(int id, int clienteId, DateTime dataPedido, List<ItemPedido> itens)
        {
            Id = id;
            ClienteId = clienteId;
            DataPedido = dataPedido;
            Itens = itens;
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public List<ItemPedido> Itens {  get; set; }  = new List<ItemPedido>();


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

        public void FecharPedido()
        {

        }





    }
}
