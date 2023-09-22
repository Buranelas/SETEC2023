using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class SessaoChatCommand
    {
        private readonly DataContext _dataContext;

        public SessaoChatCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Response> RetornarTodas()
        {
            List<SessaoChat> sessoes = await _dataContext.SessaoChat.ToListAsync();

            if (sessoes.Count == 0)
            {
                return new Response(false, ("Nenhuma Sessão Iniciada"));
            }

            return new Response(true, sessoes, "Sessões buscadas com sucesso");
        }

        public async Task<Response> FiltrarPorID(long id)
        {
            SessaoChat sessao = await _dataContext.SessaoChat.FindAsync(id);

            if (sessao == null)
            {
                return new Response(false, "Sessão não encontrada");
            }

            return new Response(true, sessao, "Sessão Encontrada");
        }

        public async Task<Response> DeletarSessao(long id)
        {
            SessaoChat sessao= await _dataContext
                .SessaoChat.FindAsync(id);
            if (sessao == null)
            {
                return new Response(false, ("ID da Sessão não encontrado."));
            }

            _dataContext.SessaoChat.Remove(sessao);
            await _dataContext.SaveChangesAsync();

            return new Response(true, sessao, "Sessão excluida com sucesso!");
        }

    }
}