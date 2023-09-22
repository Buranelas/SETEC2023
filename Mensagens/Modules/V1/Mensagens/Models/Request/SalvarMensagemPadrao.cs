using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarMensagemPadrao
    {
        [Required(ErrorMessage = "O campo Texto � obrigat�rio.")]
        [MaxLength(255, ErrorMessage = "O campo Texto deve ter no m�ximo 255 caracteres.")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "O campo IndiceArvore � obrigat�rio.")]
        public int IndiceArvore { get; set; }

        [Required(ErrorMessage = "O campo ProximoIndice � obrigat�rio.")]
        public int ProximoIndice { get; set; }

        [Required(ErrorMessage = "O campo IndiceAnterior � obrigat�rio.")]
        public int IndiceAnterior { get; set; }
    }
}