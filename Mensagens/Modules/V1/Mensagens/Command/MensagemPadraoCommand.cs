using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class MensagemPadraoCommand
    {
        private readonly DataContext _dataContext;

        public MensagemPadraoCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Response> RetornarTodas()
        {
            List<MensagemPadrao> mensagemPadrao = await _dataContext.MensagemPadrao.ToListAsync();

            if(mensagemPadrao.Count == 0)
            {
                return new Response(false, ("Nenhuma Mensagem Definida"));
            }

            return new Response(true, mensagemPadrao, "Aqui est�o as Mensagens Padr�es:");

        }

        public async Task<Response> FiltrarPorID(long id)
        {
            MensagemPadrao mensagemPadrao = await _dataContext.MensagemPadrao.FindAsync(id);

            if (mensagemPadrao == null)
            {
                return new Response(false, "Mensagem n�o encontrada");
            }

            return new Response(true, mensagemPadrao, "Mensagem Encontrada");
        }

        public async Task<Response> DeletarPadrao(long id)
        {
            MensagemPadrao msgPadrao = await _dataContext
                .MensagemPadrao.FindAsync(id);
            if (msgPadrao == null)
            {
                return new Response(false, ("ID do usu�rio n�o encontrado."));
            }

            _dataContext.MensagemPadrao.Remove(msgPadrao);
            await _dataContext.SaveChangesAsync();

            return new Response(true, msgPadrao, "Usu�rio excluido com sucesso!");
        }

        // (???)
        public async Task<MensagemPadrao> BuscarPorIndiceArvore(int indiceArvore)
        {
            MensagemPadrao mensagemPadrao = await _dataContext.MensagemPadrao
                .FirstOrDefaultAsync(x => x.IndiceArvore == indiceArvore);

            return mensagemPadrao;
        }
    }
}