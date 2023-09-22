using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class IniciarSessao
    {
        [Required(ErrorMessage = "O campo IdUsuarioAbertura � obrigat�rio.")]
        public int IdUsuarioAbertura { get; set; }

        [Required(ErrorMessage = "O campo IdUsuarioRecebido � obrigat�rio.")]
        public int IdUsuarioRecebido { get; set; }

        [Required(ErrorMessage = "O campo IndiceArvore � obrigat�rio.")]
        public int IndiceArvore { get; set; }
    }
}
