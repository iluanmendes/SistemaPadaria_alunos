using prjPadaria.Data;
using prjPadaria.Models;

namespace prjPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // // Cliente
            // Cliente cliente = new Cliente(1, "Apollo David", "11912145856", "apollo.vagalume@gmail.com");


            // // Produtos 
            // Produto produto1 = new Produto(1, "Pão",    10.00,  "Padaria", 1);
            // Produto produto2 = new Produto(2, "Sonho",  2.00,   "Padaria", 1);
            // Produto produto3 = new Produto(3, "Fubá",   5.00,   "Padaria", 1);
            // Produto produto4 = new Produto(3, "Pedra",  500.00, "Pedreira", 1);

            // // Itens
            // ItemPedido item = new ItemPedido(1, 1, produto1.Id, 1, produto1.Preco);
            // ItemPedido item2 = new ItemPedido(2, 1, produto2.Id, 2, produto2.Preco);
            // ItemPedido item3 = new ItemPedido(3, 1, produto3.Id, 3, produto3.Preco);
            // ItemPedido item4 = new ItemPedido(4, 1, produto4.Id, 50, produto4.Preco);


            // DateTime dataHoje = DateTime.Now;

            // List<ItemPedido> listaDeItens = new List<ItemPedido>() { 
            //     item,
            //     item2,
            //     item3,
            //     item4,
            // }; 



            // Pedido pedido = new Pedido(1, cliente.Id, dataHoje, listaDeItens);

            // Console.WriteLine("--------");
            // Console.WriteLine($"Quem comprou: {cliente.Nome}");
            // Console.WriteLine("Produtos comprados");


            // foreach(var p in pedido.Itens)
            // {

            //     Console.WriteLine($"ID {p.ProdutoId} - Quantidade:{p.Quantidade} - Subtotal {p.Subtotal()}  ");

            // }

            // Console.WriteLine(pedido.Itens.Count);
            // Console.WriteLine($"Valor Pedido{ pedido.CalcularTotal():F2}");


            //ClienteData clienteData = new ClienteData();

            // clienteData.Inserir(cliente);


            //int idNovoMarca = new Marca("Panco").Inserir();

            //new Marca(4, "Bimbo").Atualizar();

            //Console.WriteLine("Listar Todas ------ ");
            //List<Marca> TodasMarcas = Marca.ListarTodas();

            //foreach (Marca marca in TodasMarcas) {

            //    Console.WriteLine($"ID: {marca.Id}     Nome: {marca.Nome}");

            //}

            //Console.WriteLine("Listar Por ID ------ ");


            //Marca retornoMarca = Marca.ListarPorId(5);

            //if(retornoMarca != null)
            //{
            //    Console.WriteLine($"{retornoMarca.Id} -- {retornoMarca.Nome}");
            //}
            //else
            //{
            //    Console.WriteLine("Não foi possível localizar a marca por este ID");
            //}

            Usuario user = new Usuario("Luan", "email@email.com.br", "12345", 1);


            try
            {

                Console.WriteLine("Digite seu e-mail");
                string email = Console.ReadLine();


                Console.WriteLine("Digite seu e-mail");
                string senha = Console.ReadLine();


                Usuario login = Usuario.Autenticar(email, senha);

                if (login != null)
                {

                    Console.WriteLine($"Seja bem vindo, {login.Nome}");
                    Console.WriteLine($"Seu perfil de acesso é: {login.PerfilAcesso}");
                }


                List<Produto> produtos = Produto.Listar();
                List<ItemPedido> produtosCompra = new List<ItemPedido>();
                
                Console.WriteLine($"{"Id", -4} | {"Produto", -30}  |  {"Preço", -7} | ");
                Console.WriteLine("");

                foreach (var item in produtos)
                {
                    Console.WriteLine($"{item.Id, -4} | {item.Nome, -30}  | R$ {item.Preco,-5:F2} | ");
                }

                int opc = 0;

                Console.WriteLine("");

                do
                {
                    Console.WriteLine("Digite o ID de um produto da lista. A qualquer momento pressione 0 para encerrar a lista de produtos");

                     bool bOpc = int.TryParse(Console.ReadLine(), out opc);                     
                     bool validaOpc = produtos.Any(prod => prod.Id == opc);

                    if (bOpc && validaOpc)
                    {
                        var produtoEncontrado = produtos.FirstOrDefault(prod => prod.Id == opc);
                        int qtdDesejada = 1;

                        Console.WriteLine($"Digite a quantidade itens que deseja para {produtoEncontrado?.Nome}");

                        if(!int.TryParse(Console.ReadLine(), out qtdDesejada))
                        {
                            qtdDesejada = 1;
                        }

                        ItemPedido novoProduto = new ItemPedido(0, produtoEncontrado.Id, qtdDesejada, produtoEncontrado.Preco);

                        produtosCompra.Add(novoProduto);


                    } else if(opc == 0)
                    {
                        Console.WriteLine("Saindo!!");
                    }
                    else {
                        Console.WriteLine("Opção Inválida - Digite somente  números e IDs da lista de produtos");
                    }


                    


                }while (opc!=0);


                Pedido pedido = new Pedido(1, login.Id, DateTime.Now, produtosCompra);

                Pedido.FecharPedido(pedido);

                // ---

                Console.WriteLine("TESTE---------");

                foreach (var item in produtosCompra)
                {
                    Console.WriteLine($"{item.ProdutoId} -  Qtd {item.Quantidade} - Preco {item.PrecoUnitario} { item.Subtotal()}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }


           



        }
    }
}

