using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models;

public class MensagemPadrao
{
    public MensagemPadrao(long id, string texto, int indiceArvore, int proximoIndice, int indiceAnterior)
    {
        Id = id;
        Texto = texto;
        IndiceArvore = indiceArvore;
        ProximoIndice = proximoIndice;
        IndiceAnterior = indiceAnterior;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Texto { get; set; }
    public int IndiceArvore { get; set; }
    public int ProximoIndice { get; set; }
    public int IndiceAnterior { get; set; }

}
