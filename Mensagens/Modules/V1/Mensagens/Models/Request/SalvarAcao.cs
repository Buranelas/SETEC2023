using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarAcao
    {
        [Required(ErrorMessage = "O campo Conteudo � obrigat�rio.")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "O campo TipoAcao � obrigat�rio.")]
        public int TipoAcao { get; set; }
    }
}