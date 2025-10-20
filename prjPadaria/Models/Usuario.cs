using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPadaria.Models
{
    public class Usuario
    {
        public Usuario(int id, string nome, string email, string senhaHash)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
        }

        public Usuario(string nome, string email, string senha, int perfilAcessoId)
        {
            Nome = nome;
            Email = email;
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
            PerfilAcessoId = perfilAcessoId;

        }

        //0000
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public int PerfilAcessoId { get; set; }
        public string PerfilAcesso { get; set; } = "";

        public void AlterarSenha(string nova)
        {


        }

        public static int Inserir(Usuario usuario)
        {
            string sql = "INSERT INTO `Usuario`(`Nome`, `Email`, `SenhaHash`, `PerfilAcessoId`) VALUES (@Nome, @Email, @SenhaHash, @PerfilAcessoId);";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@SenhaHash", usuario.SenhaHash);
                cmd.Parameters.AddWithValue("@PerfilAcessoId", usuario.PerfilAcesso);

                return Banco.executarComando(cmd);
            }

        }

        public static Usuario? BuscaPorEmail(string login, string senha)
        {

            string procedure = "sp_obterUsuarioPorEmail";

            using (var command = new MySqlCommand(procedure))
            {

                // Trabalhando com procedures
                command.CommandType = CommandType.StoredProcedure;

                // Chamando a variavel da procedure e trocando pelo login digitado pelo usuário
                command.Parameters.AddWithValue("@p_email", login);
                MySqlDataReader reader = Banco.ExecuteReader(command);

                Usuario user = null;

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string nome = reader.GetString("Nome");
                    string senhaBanco = reader.GetString("SenhaHash");
                    int perfilAcessoId = reader.GetInt32("PerfilAcessoId");
                    string perfilAcesso = reader.GetString("perfil");

                    user = new Usuario(id, nome, login, senhaBanco);
                    user.PerfilAcesso = perfilAcesso;


                }

                return user;
            }
        }



        public static Usuario Autenticar(string login, string senha)
        {

            Usuario? user = BuscaPorEmail(login, senha);

            if (user == null)
            {
                throw new ApplicationException("Usuário não encontrado");

            }

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(senha, user.SenhaHash);

            if (!senhaCorreta)
            {

                throw new ApplicationException("Senha incorreta");

            }

            return user;
        }

    }

}
