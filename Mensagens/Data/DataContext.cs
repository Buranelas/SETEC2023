using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Data;

#pragma warning disable CS8618
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Acao> Acao { get; set; }

    public DbSet<Mensagem> Mensagem { get; set; }

    public DbSet<MensagemPadrao> MensagemPadrao { get; set; }

    public DbSet<SessaoChat> SessaoChat { get; set; }

    public DbSet<Usuario> Usuario { get; set; }

}
#pragma warning restore CS8618