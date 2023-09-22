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
                return new Response(false, ("Nenhuma Sess�o Iniciada"));
            }

            return new Response(true, sessoes, "Sess�es buscadas com sucesso");
        }

        public async Task<Response> FiltrarPorID(long id)
        {
            SessaoChat sessao = await _dataContext.SessaoChat.FindAsync(id);

            if (sessao == null)
            {
                return new Response(false, "Sess�o n�o encontrada");
            }

            return new Response(true, sessao, "Sess�o Encontrada");
        }

        public async Task<Response> DeletarSessao(long id)
        {
            SessaoChat sessao= await _dataContext
                .SessaoChat.FindAsync(id);
            if (sessao == null)
            {
                return new Response(false, ("ID da Sess�o n�o encontrado."));
            }

            _dataContext.SessaoChat.Remove(sessao);
            await _dataContext.SaveChangesAsync();

            return new Response(true, sessao, "Sess�o excluida com sucesso!");
        }

    }
}