namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class EditarSessao
    {

        public DateTime Abertura { get; set; }
        public DateTime UltimaAtividade { get; set; }
        public int Status { get; set; }
        public int UsuarioAbertura { get; set; }
        public int UsuarioRemetente { get; set; }


    }
}