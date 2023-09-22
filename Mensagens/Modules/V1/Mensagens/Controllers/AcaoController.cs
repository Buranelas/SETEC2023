using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Enums;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace Mensagens.Modules.V1.Mensagens.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AcaoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly AcaoCommand _acaoCommand;

        public int TipoAcao { get; private set; }

        public AcaoController(DataContext dataContext, AcaoCommand acaoCommand)
        {
            _dataContext = dataContext;
            _acaoCommand = acaoCommand;
        }

        //Buscar todas as Ações da Tabela
        [HttpGet("BuscarTodas")]
        public async Task<ActionResult> Get()
        {
            Response response = await _acaoCommand.RetornarTodas();

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }
        }

        //Buscar as Ações da Tabela com um ID específico
        [HttpGet("BuscarPorID/{id}")]
        public async Task<ActionResult> GetPorID(long id)
        {
            if (id <= 0)
            {
                return BadRequest("O parâmetro deve ser maior que 0");
            }

            Response response = await _acaoCommand.FiltrarPorID(id);

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }

        }

        //Adicionar uma Ação a Tabela
        [HttpPost("SalvarAcao")]
        public async Task<ActionResult> SalvarAcao(SalvarAcao SalvarAcao)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Acao novaAcao = new Acao
                {
                    Conteudo = SalvarAcao.Conteudo,
                    TipoAcao = SalvarAcao.TipoAcao
                };

                _dataContext.Acao.Add(novaAcao);

                await _dataContext.SaveChangesAsync();

                return Ok(novaAcao);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado!");
            }
        }

        //Editar uma Ação
        [HttpPut("EditarAcao")]
        public async Task<ActionResult> EditarAcao(EditarAcao EditarAcao)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return BadRequest(new { Errors = errors });
                }

                if (!Enum.IsDefined(typeof(TipoAcao), EditarAcao.TipoAcao))
                {
                    return BadRequest("Tipo de ação inválido.");
                }

                Acao acao = await _dataContext.Acao.FindAsync(EditarAcao.Id);
                if (acao == null)
                {
                    return BadRequest("Ação não encontrada");
                }

                acao.Conteudo = EditarAcao.Conteudo;
                TipoAcao = EditarAcao.TipoAcao;


                await _dataContext.SaveChangesAsync();

                return Ok(acao);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado!");
            }
        }

        //Deletando uma Ação de chat
        [HttpDelete("DeletarAcao/{id}")]
        public async Task<ActionResult> DeletarSessao(long id)
        {
            Response response = await _acaoCommand.DeletarAcao(id);

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