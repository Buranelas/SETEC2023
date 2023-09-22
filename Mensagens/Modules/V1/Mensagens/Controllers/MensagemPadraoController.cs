using System.Runtime.Intrinsics.X86;
using Azure.Core;
using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Enums;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Ocsp;

namespace Mensagens.Modules.V1.Mensagens.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MensagemPadraoController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly MensagemPadraoCommand _padraoCommand;

        public MensagemPadraoController(DataContext dataContext, MensagemPadraoCommand padraoCommand)
        {
            _dataContext = dataContext;
            _padraoCommand = padraoCommand;
        }

        //Buscar todos as Mensagens Padrões da Tabela
        [HttpGet("BuscarTodasMensagensPadroes")]
        public async Task<ActionResult> Get()
        {
            Response response = await _padraoCommand.RetornarTodas();

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }
        }

        //Buscar as Mensagens Padrões da Tabela com um ID específico (????)
        [HttpGet("BuscarMensagemPadraoPorID/{id}")]
        public async Task<ActionResult> GetPorID(long id)
        {
            if (id <= 0)
            {
                return BadRequest("O parâmetro deve ser maior que 0");
            }

            Response response = await _padraoCommand.FiltrarPorID(id);

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }

        }

        //Buscar Mensagem Padrão para definir no Indice (???)
        [HttpGet("BuscarMensagemPadrao")]
        public async Task<ActionResult> BuscarMensagemPadrao(int indiceArvore)
        {
            try
            { 
                var mensagemPadrao = await _padraoCommand.BuscarPorIndiceArvore(indiceArvore);

                if (mensagemPadrao == null)
                {
                    return NotFound("Mensagem padrão não encontrada.");
                }

                return Ok(mensagemPadrao);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar a mensagem padrão: ");
            }
        }

        //Adicionar nova Mensagem Padrão a Tabela
        [HttpPost("SalvarMensagemPadrao")]
        public async Task<ActionResult> SalvarMensagemPadrao(SalvarMensagemPadrao SalvarMensagemPadrao)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MensagemPadrao novaMensagemPadrao = new MensagemPadrao
                (
                     0,
                     SalvarMensagemPadrao.Texto,
                     SalvarMensagemPadrao.IndiceArvore,
                     SalvarMensagemPadrao.ProximoIndice,
                     SalvarMensagemPadrao.IndiceAnterior
                );

                _dataContext.MensagemPadrao.Add(novaMensagemPadrao);

                await _dataContext.SaveChangesAsync();

                return Ok(novaMensagemPadrao);
            }
            catch (Exception ex)
            {

                return BadRequest("Erro Inesperado!");
            }
        }
    
        //Editar uma Mensagem Padrão da Tabela(???)
        [HttpPut("EditarPadrao")]
        public async Task<ActionResult> EditarPadrao(long id, EditarMensagemPadrao editarPadraoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Erro Inesperado");
            }

            MensagemPadrao? mensagemPadrao = await _dataContext
                .MensagemPadrao.FindAsync(id);
            if (mensagemPadrao == null)
            {
                return BadRequest("Mensagem Padrão não Encontrada");
            }

            mensagemPadrao.Texto = editarPadraoRequest.Texto;
            mensagemPadrao.IndiceArvore = editarPadraoRequest.IndiceArvore;

            await _dataContext.SaveChangesAsync();

            return Ok(mensagemPadrao);
        }

        //Deletando uma Mensagem Padrão da Tabela
        [HttpDelete("DeletarPadrao/{id}")]
        public async Task<ActionResult> DeletarPadrao(long id)
        {
            Response response = await _padraoCommand.DeletarPadrao(id);

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }
        }
    }
}

