using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarAcao
    {
        [Required(ErrorMessage = "O campo Conteudo é obrigatório.")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "O campo TipoAcao é obrigatório.")]
        public int TipoAcao { get; set; }
    }
}