using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarUsuario
    {
        public SalvarUsuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        [Required(ErrorMessage = "O campo 'nome' � obrigat�rio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'email' � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "O campo 'email' n�o est� em um formato v�lido.")]
        public string Email { get; set; }


    }
}