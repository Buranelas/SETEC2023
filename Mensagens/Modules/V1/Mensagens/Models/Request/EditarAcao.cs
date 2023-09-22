using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class EditarAcao
    {
        [Required(ErrorMessage = "O campo ID é obrigatório.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Conteúdo é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O campo Conteúdo deve ter no máximo 255 caracteres.")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "O campo TipoAcao é obrigatório.")]
        public int TipoAcao { get; set; }

    }
}