using Mensagens.Modules.V1.Mensagens.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class EnviarMensagem
    {
      
        public long IdSessaoChat { get; set; }

        public int IdUsuarioAbertura { get; set; }
        public int IdUsuarioRecebido { get; set; }
        public int IndiceArvore { get; set; }
        public string Texto { get; set; }
    }
}