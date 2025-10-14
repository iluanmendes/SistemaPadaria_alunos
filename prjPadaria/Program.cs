using prjPadaria.Data;
using prjPadaria.Models;

namespace prjPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cliente
            Cliente cliente = new Cliente(1, "Apollo David", "11912145856", "apollo.vagalume@gmail.com");


            // Produtos 
            Produto produto1 = new Produto(1, "Pão",    10.00,  "Padaria", 1);
            Produto produto2 = new Produto(2, "Sonho",  2.00,   "Padaria", 1);
            Produto produto3 = new Produto(3, "Fubá",   5.00,   "Padaria", 1);
            Produto produto4 = new Produto(3, "Pedra",  500.00, "Pedreira", 1);

            // Itens
            ItemPedido item = new ItemPedido(1, 1, produto1.Id, 1, produto1.Preco);
            ItemPedido item2 = new ItemPedido(2, 1, produto2.Id, 2, produto2.Preco);
            ItemPedido item3 = new ItemPedido(3, 1, produto3.Id, 3, produto3.Preco);
            ItemPedido item4 = new ItemPedido(4, 1, produto4.Id, 50, produto4.Preco);


            DateTime dataHoje = DateTime.Now;

            List<ItemPedido> listaDeItens = new List<ItemPedido>() { 
                item,
                item2,
                item3,
                item4,
            }; 

            

            Pedido pedido = new Pedido(1, cliente.Id, dataHoje, listaDeItens);

            Console.WriteLine("--------");
            Console.WriteLine($"Quem comprou: {cliente.Nome}");
            Console.WriteLine("Produtos comprados");

            
            foreach(var p in pedido.Itens)
            {
                
                Console.WriteLine($"ID {p.ProdutoId} - Quantidade:{p.Quantidade} - Subtotal {p.Subtotal()}  ");
               
            }

            Console.WriteLine(pedido.Itens.Count);
            Console.WriteLine($"Valor Pedido{ pedido.CalcularTotal():F2}");

           
           ClienteData clienteData = new ClienteData();

            clienteData.Inserir(cliente);

        }
    }
}

