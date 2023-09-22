using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class IniciarSessao
    {
        [Required(ErrorMessage = "O campo IdUsuarioAbertura é obrigatório.")]
        public int IdUsuarioAbertura { get; set; }

        [Required(ErrorMessage = "O campo IdUsuarioRecebido é obrigatório.")]
        public int IdUsuarioRecebido { get; set; }

        [Required(ErrorMessage = "O campo IndiceArvore é obrigatório.")]
        public int IndiceArvore { get; set; }
    }
}
