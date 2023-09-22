using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarSessao
    { 
            public DateTime Abertura { get; set; }
            public DateTime UltimaAtividade { get; set; }
            public int Status { get; set; }
            [Required(ErrorMessage = "O campo IdUsuarioAbertura é obrigatório.")]
            public int IdUsuarioAbertura { get; set; }

            [Required(ErrorMessage = "O campo IdUsuarioRecebido é obrigatório.")]
            public int IdUsuarioRecebido { get; set; }

    }
}

    
    
        