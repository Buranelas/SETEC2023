using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models;

public class SessaoChat
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdSessaoChat { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuarioAbertura { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuarioRecebido { get; set; }

    public DateTime Abertura { get; set; }

    public DateTime UltimaAtividade { get; set; }

    public StatusSessaoChat StatusSessao { get; set; }

    public AvaliacaoChat Avaliacao { get; set; }

    // Objetos que não fazem parte da entidade
    public Usuario? UsuarioAbertura { get; set; }

    public Usuario? UsuarioRecebido { get; set; }
}