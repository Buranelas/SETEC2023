using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models;

public class Usuario
{
    public Usuario(long id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }
}

