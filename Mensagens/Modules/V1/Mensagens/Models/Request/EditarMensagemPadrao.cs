using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class EditarMensagemPadrao
    {
        [Required(ErrorMessage = "O campo ID � obrigat�rio.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Texto � obrigat�rio.")]
        [MaxLength(255, ErrorMessage = "O campo Texto deve ter no m�ximo 255 caracteres.")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "O campo IndiceArvore � obrigat�rio.")]
        public int IndiceArvore { get; set; }



    }
}