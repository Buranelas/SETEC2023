using AutoMapper;
using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Repositories.Interfaces;

namespace Mensagens.Modules.V1.Mensagens.Repositories;

public class MensagemRepository : IMensagem
{
    private readonly DataContext _dataContext;

    public MensagemRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Mensagem> SalvarMensagemAsync(Mensagem mensagem)
    {
        _dataContext.Mensagem.Add(mensagem);
        await _dataContext.SaveChangesAsync();
        return mensagem;
    }
}