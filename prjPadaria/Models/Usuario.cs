using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class Usuario
    {
        //0000
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }        
        public string SenhaHash { get; set; }

        public void Autenticar(string email, string senha)
        {

        }
       
        public void AlterarSenha(string nova)
        {


        }

    }
}
