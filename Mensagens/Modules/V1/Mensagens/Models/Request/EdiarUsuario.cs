namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class EditarUsuario
    {
        public EditarUsuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; set; }

        public string Email { get; set; }


    }
}