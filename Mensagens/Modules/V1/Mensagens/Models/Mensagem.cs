using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models;

public class Mensagem
{
    public Mensagem(long id,string? texto, DateTime dataHora)
    {
        Id = id;
        Texto = texto;
        DataHora = dataHora;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuarioEnvio { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuarioRecebido { get; set; }

    [ForeignKey("SessaoChat")]
    public long IdSessaoChat { get; set; }

    [ForeignKey("MensagemPadrao")]
    public long? IdMensagemPadrao { get; set; }

    [ForeignKey("Acoes")]
    public long? IdAcoes { get; set; }

    [MaxLength(800, ErrorMessage = "{0} deve ter no maximo {1} caractares.")]
    public string? Texto { get; set; }

    public DateTime DataHora { get; set; }

    public StatusMensagem StatusMensagem { get; set; }

    // Objetos que não fazem parte da entidade
    public Usuario? UsuarioAbertura { get; set; }

    public Usuario? UsuarioRecebido { get; set; }

    public SessaoChat? Sessao { get; set; }

    public MensagemPadrao? MensagemPadrao { get; set; }

    public Acao? Acoes { get; set; }
}