using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class AcaoCommand
    {
        private readonly DataContext _dataContext;

        public AcaoCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Response> RetornarTodas()
        {
            List<Acao> acoes = await _dataContext.Acao.ToListAsync();

            if (acoes.Count == 0)
            {
                return new Response(false, ("Nenhuma Mensagem Recebida"));
            }

            return new Response(true, acoes, "Usu�rios Buscado com sucesso");
        }

        public async Task<Response> FiltrarPorID(long id)
        {
            Acao acao = await _dataContext.Acao.FindAsync(id);

            if (acao == null)
            {
                return new Response(false, "Sess�o n�o encontrada");
            }

            return new Response(true, acao, "Sess�o Encontrada");
        }

        public async Task<Response> DeletarAcao(long id)
        {
            Acao deletacao= await _dataContext
                .Acao.FindAsync(id);
            if (deletacao == null)
            {
                return new Response(false, ("ID da a��o n�o encontrado."));
            }

            _dataContext.Acao.Remove(deletacao);
            await _dataContext.SaveChangesAsync();

            return new Response(true, deletacao, "A��o excluido com sucesso!");
        }
    }
}