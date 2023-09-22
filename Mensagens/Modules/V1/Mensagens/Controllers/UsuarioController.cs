using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Controllers
{

    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly UsuarioCommand _usuarioCommand;

        public UsuarioController(DataContext dataContext, UsuarioCommand usuarioCommand)
        {
            _dataContext = dataContext;
            _usuarioCommand = usuarioCommand;
        }

        //Buscar todos os Usuários da Tabela
        [HttpGet("BuscarTodos")]
        public async Task<ActionResult> Get()
        {
            Response response = await _usuarioCommand.RetornarTodos();

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }
        }

        //Buscar um Usuáiro pela variável "nome" na Tabela
        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult> GetPeloNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return BadRequest("O parâmetro nome não pode ser vazio");
            }

            Response responsenome = await _usuarioCommand.FiltrarPorNome(nome);

            if (responsenome.Sucesso)
            {
                return Ok(responsenome);
            }
            else
            {
                return BadRequest(responsenome.Status);
            }
        }

        
        //Deletar um Usuário da Tabela
        [HttpDelete("DeletarUsuario/{id}")]
        public async Task<ActionResult> DeletarUsuario(long id)
        {
            Response response = await _usuarioCommand.DeletarUsuario(id);

            if (response.Sucesso)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Status);
            }
        }

        //Adicionar um Usuário a Tabela
        [HttpPost("SalvarUsuario")]
        public async Task<ActionResult> Post(SalvarUsuario SalvarUsuario)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { Errors = errors });
            }

            Usuario usuario = new Usuario(0, SalvarUsuario.Nome, SalvarUsuario.Email);
            _dataContext.Usuario.Add(usuario);
            await _dataContext.SaveChangesAsync();
            return Ok(usuario);
        }

        //Editar um Usuário da Tabela
        [HttpPut("EditarUsuario")]
        public async Task<ActionResult> EditarUsuario(long id, EditarUsuario EditarUsuario)
        {
            Usuario? usuario = await _dataContext
                .Usuario.FindAsync(id);
            if (usuario == null)
            {
                return BadRequest("ID do usuário não foi encontrado");
            }

            usuario.Nome = EditarUsuario.Nome;
            usuario.Email = EditarUsuario.Email;

            await _dataContext.SaveChangesAsync();
            return Ok(usuario);
        }

    }
}