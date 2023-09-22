using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarMensagemPadrao
    {
        [Required(ErrorMessage = "O campo Texto é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O campo Texto deve ter no máximo 255 caracteres.")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "O campo IndiceArvore é obrigatório.")]
        public int IndiceArvore { get; set; }

        [Required(ErrorMessage = "O campo ProximoIndice é obrigatório.")]
        public int ProximoIndice { get; set; }

        [Required(ErrorMessage = "O campo IndiceAnterior é obrigatório.")]
        public int IndiceAnterior { get; set; }
    }
}