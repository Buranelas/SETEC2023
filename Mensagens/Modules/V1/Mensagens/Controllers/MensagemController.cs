using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Enums;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MensagemController : ControllerBase
{
    private readonly MensagemCommand _mensagemCommand;

    private readonly DataContext _dataContext;
    private readonly AcaoCommand _acaoCommand;

    public MensagemController(MensagemCommand mensagemCommand, DataContext dataContext, AcaoCommand acaoCommand)
    {
        _mensagemCommand = mensagemCommand;
        _dataContext = dataContext;
        _acaoCommand = acaoCommand;
    }

    [HttpPost("primeiraMensagem")]
    public async Task<ActionResult<Mensagem>> EnviarPrimeiraMensagemAsync([FromBody] EnviarMensagemDTO enviarMensagem)
    {
        Response response = await _mensagemCommand.EnviarPrimeiraMensagemAsync(enviarMensagem);

        if (response.Falha)
        {
            return BadRequest(response.Status);
        }
        else
        {
            return Ok(response.Data ?? response.Status);
        }
    }

    [HttpGet]
    public async Task<ActionResult> BuscarMensagens()
    {
        return Ok(await _dataContext.Mensagem
            .Include(x => x.UsuarioAbertura)
            .Include(x => x.UsuarioRecebido)
            .ToArrayAsync());
    }

    //Finalizar Chat
    [HttpPost("FinalizarChat/{id}")]
    public async Task<ActionResult> FinalizarChat(int id)
    {
        try
        {
            var sessaoChat = await _dataContext.SessaoChat.FindAsync(id);
            
            if (sessaoChat == null)
            {
                return NotFound("Sessão de chat não encontrada.");
            }

            if (sessaoChat.StatusSessao == StatusSessaoChat.Finalizado)
            {
                return BadRequest("O chat já foi finalizado anteriormente.");
            }

            sessaoChat.StatusSessao = StatusSessaoChat.Finalizado;

            await _dataContext.SaveChangesAsync();

            var mensagemAvaliacao = new Mensagem
            (
                0,
                "Obrigado por usar nosso serviço. Por favor, avalie sua experiência de 1 a 5 (1 - Ruim, 5 - Excelente):",
                DateTime.Now
            );

            _dataContext.Mensagem.Add(mensagemAvaliacao);

            await _dataContext.SaveChangesAsync();

            return Ok("Chat finalizado com sucesso. Aguardando avaliação.");
        }
        catch (Exception ex)
        {
            return BadRequest("Erro Inesperado!");
        }
    }

    //Adicionar uma nova Mensagem
    [HttpPost("SalvarMensagem")]
    public async Task<ActionResult> SalvarMensagem(SalvarMensagem SalvarMensagem)
    {
        try
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mensagem novaMensagem = new Mensagem
                (
                    0,
                    SalvarMensagem.Texto,
                    DateTime.Now
                );
            

            _dataContext.Mensagem.Add(novaMensagem);

            await _dataContext.SaveChangesAsync();

            return Ok(novaMensagem);
        }
        catch (Exception ex)
        {

            return BadRequest("Erro Inesperado!");
        }
    }

}
