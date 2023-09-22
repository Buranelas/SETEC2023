using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class DeletarUsuario
    {
        public DeletarUsuario(long id)
        {
            id = id;
        }

        public long id { get; set; }


    }
}