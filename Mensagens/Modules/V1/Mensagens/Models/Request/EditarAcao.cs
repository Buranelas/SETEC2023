using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class EditarAcao
    {
        [Required(ErrorMessage = "O campo ID � obrigat�rio.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Conte�do � obrigat�rio.")]
        [MaxLength(255, ErrorMessage = "O campo Conte�do deve ter no m�ximo 255 caracteres.")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "O campo TipoAcao � obrigat�rio.")]
        public int TipoAcao { get; set; }

    }
}