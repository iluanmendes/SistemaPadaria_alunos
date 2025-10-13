using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class Cliente
    {
        public Cliente(int id, string nome, string telefone, string email)
        {

            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public void AtualizarDados() { }
        public void ListarPedidos(int id, string nome, string telefone, string email) { }


    }
}
