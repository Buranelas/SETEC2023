using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Enums;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Controllers
{

    [Route("api/sessaochat")]
    [ApiController]
    public class SessaoChatController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly SessaoChatCommand _sessaoCommand;
        private readonly MensagemPadraoCommand _padraoCommand;

        public SessaoChatController(DataContext dataContext, SessaoChatCommand sessaoCommand, MensagemPadraoCommand padraoCommand)
        {
            _dataContext = dataContext;
            _sessaoCommand = sessaoCommand;
            _padraoCommand = padraoCommand;
        }

        //Buscar todas as Sessoes da Tabela
        [HttpGet("BuscarTodas")]
        public async Task<ActionResult> Get()
        {
            Response response = await _sessaoCommand.RetornarTodas();

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }
        }

        //Buscar as Sessoes da Tabela com um ID específico (????)
        [HttpGet("BuscarPorID/{id}")]
        public async Task<ActionResult> GetPorID(long id)
        {
            if (id <= 0)
            {
                return BadRequest("O parâmetro deve ser maior que 0");
            }

            Response response = await _sessaoCommand.FiltrarPorID(id);

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }

        }

        //Adicionar uma Sessão a Tabela
        [HttpPost("SalvarSessao")]
        public async Task<ActionResult> SalvarSessao(SalvarSessao SalvarSessao)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return BadRequest(new { Errors = errors });
                }

                SessaoChat novaSessao = new SessaoChat
                {
                    IdUsuarioAbertura = SalvarSessao.IdUsuarioAbertura,
                    IdUsuarioRecebido = SalvarSessao.IdUsuarioRecebido,
                    Abertura = DateTime.Now,
                    UltimaAtividade = DateTime.Now,
                    StatusSessao = StatusSessaoChat.AguardandoRespostaRecebendo
                };

                _dataContext.SessaoChat.Add(novaSessao);
                await _dataContext.SaveChangesAsync();

                return Ok(novaSessao);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado!");
            }
        }

        //Editar uma Sessão da Tabela
        [HttpPut("EditarSessão")]
        public async Task<ActionResult> EditarSessao(long id, EditarSessao EditarSessao)
        {
            SessaoChat? sessao = await _dataContext.SessaoChat.FindAsync(id);

            if(sessao == null)
            {
                return BadRequest("ID de sessão não encontrado");
            }

            sessao.Abertura = EditarSessao.Abertura;
            sessao.UltimaAtividade = EditarSessao.UltimaAtividade;
            sessao.StatusSessao = (Enums.StatusSessaoChat)EditarSessao.Status;
            sessao.IdUsuarioAbertura = EditarSessao.UsuarioAbertura;
            sessao.IdUsuarioRecebido = EditarSessao.UsuarioRemetente;

            await _dataContext.SaveChangesAsync();
            return Ok(sessao);
        }

        //Deletando uma Sessão de chat
        [HttpDelete("DeletarSessao/{id}")]
        public async Task<ActionResult> DeletarSessao(long id)
        {
            Response response = await _sessaoCommand.DeletarSessao(id);

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }
        }

        [HttpPost("IniciarSessao")]
        public async Task<ActionResult> IniciarSessao(IniciarSessao IniciarSessao)
        {
            try
            {
                var indiceArvore = IniciarSessao.IndiceArvore;
                var mensagemPadrao = await _padraoCommand.BuscarPorIndiceArvore(indiceArvore);



                SessaoChat novaSessao = new SessaoChat
                {
                    IdUsuarioAbertura = IniciarSessao.IdUsuarioAbertura,
                    IdUsuarioRecebido = IniciarSessao.IdUsuarioRecebido,
                    Abertura = DateTime.Now,
                    UltimaAtividade = DateTime.Now,
                    StatusSessao = StatusSessaoChat.AguardandoRespostaRecebendo,

                };
                _dataContext.SessaoChat.Add(novaSessao);    
                await _dataContext.SaveChangesAsync();

                return Ok(novaSessao);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado!");
            }
        }

        //Iniciando uma nova Sessão de Chat (???)
        //[HttpPost("IniciarSessao")]
        //public async Task<ActionResult> IniciarSessao(IniciarSessao iniciarSessao)
        //{
        //    try
        //    {

        //        var indiceArvore = iniciarSessao.IndiceArvore;

        //        var mensagemPadraoIndice = await _padraoCommand.BuscarPorIndiceArvore(indiceArvore);

        //        if (mensagemPadraoIndice.Result is OkObjectResult okResult)
        //        {
        //            var mensagemPadrao = okResult.Value as MensagemPadrao;

        //            SessaoChat novaSessao = new SessaoChat
        //            {
        //                IdUsuarioAbertura = iniciarSessao.IdUsuarioAbertura,
        //                IdUsuarioRecebido = iniciarSessao.IdUsuarioRecebido,
        //                Abertura = DateTime.Now,
        //                UltimaAtividade = DateTime.Now,
        //                StatusSessao = StatusSessaoChat.AguardandoRespostaRecebendo,
        //                MensagemPadrao = mensagemPadrao 
        //            };

        //            _dataContext.SessaoChat.Add(novaSessao);
        //            await _dataContext.SaveChangesAsync();

        //            return Ok(novaSessao);
        //        }
        //        else
        //        {
        //            return BadRequest("Mensagem Padrão não encontrada");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Erro Inesperado!");
        //    }
        //}
    }
}