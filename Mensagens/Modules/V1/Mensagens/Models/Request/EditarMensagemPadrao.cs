using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class EditarMensagemPadrao
    {
        [Required(ErrorMessage = "O campo ID é obrigatório.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Texto é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O campo Texto deve ter no máximo 255 caracteres.")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "O campo IndiceArvore é obrigatório.")]
        public int IndiceArvore { get; set; }



    }
}