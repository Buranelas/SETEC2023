using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class UsuarioCommand
    {
        private readonly DataContext _dataContext;

        public UsuarioCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Response> RetornarTodos()
        {
            List<Usuario> usuarios = await _dataContext.Usuario.ToListAsync();

            if(usuarios.Count == 0)
            {
                return new Response(false, ("Nenhuma Mensagem Recebida"));
            }

            return new Response(true,usuarios, "Usuários Buscado com sucesso");
        }
        public async Task<Response> FiltrarPorNome(string nome)
        {
            List<Usuario> usuariosFiltrados = await _dataContext.Usuario
                .Where(x => x.Nome.Contains(nome))
                .ToListAsync();

            if (usuariosFiltrados.Count == 0)
            {
                return new Response(false, ("Nenhum usuário encontrado com o nome informado."));
            }

            return new Response(true, usuariosFiltrados, "Usuários filtrado com sucesso");
        }

        public async Task<Response> DeletarUsuario(long id)
        {
            Usuario usuario = await _dataContext
                .Usuario.FindAsync(id);
            if(usuario == null)
            {
                return new Response(false, ("ID do usuário não encontrado."));
            }

            _dataContext.Usuario.Remove(usuario);
            await _dataContext.SaveChangesAsync();

            return new Response(true, usuario, "Usuário excluido com sucesso!");
        }

    }
}