using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarSessao
    { 
            public DateTime Abertura { get; set; }
            public DateTime UltimaAtividade { get; set; }
            public int Status { get; set; }
            [Required(ErrorMessage = "O campo IdUsuarioAbertura � obrigat�rio.")]
            public int IdUsuarioAbertura { get; set; }

            [Required(ErrorMessage = "O campo IdUsuarioRecebido � obrigat�rio.")]
            public int IdUsuarioRecebido { get; set; }

    }
}

    
    
        