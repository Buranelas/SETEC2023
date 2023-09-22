using Mensagens.Modules.V1.Mensagens.Models;

namespace Mensagens.Modules.V1.Mensagens.Repositories.Interfaces;

public interface IMensagem
{
    Task<Mensagem> SalvarMensagemAsync(Mensagem mensagem);
}

