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
        [Required(ErrorMessage = "O campo 'nome' é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo 'email' não está em um formato válido.")]
        public string Email { get; set; }


    }
}