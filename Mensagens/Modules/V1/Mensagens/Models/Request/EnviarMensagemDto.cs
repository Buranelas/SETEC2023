using AutoMapper;
using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models.Request;

public class EnviarMensagemDTO
{
    public int IdUsuarioAbertura { get; set; }

    public int IdUsuarioRecebido { get; set; }

    public long? IdMensagemPadrao { get; set; }

    public string? Texto { get; set; }
}

public class EnviarMensagemrMappingProfile : Profile
{
    public EnviarMensagemrMappingProfile()
    {
        CreateMap<EnviarMensagemDTO, Mensagem>()
            .ForMember(dest => dest.DataHora, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.StatusMensagem, opt => opt.MapFrom(src => StatusMensagem.Enviada))
            .ForMember(dest => dest.IdAcoes, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IdSessaoChat, opt => opt.Ignore());

        CreateMap<EnviarMensagemDTO, SessaoChat>()
            .ForMember(dest => dest.Abertura, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UltimaAtividade, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.StatusSessao, opt => opt.MapFrom(src => StatusSessaoChat.AguardandoRespostaRecebendo))
            .ForMember(dest => dest.Avaliacao, opt => opt.Ignore())
            .ForMember(dest => dest.IdSessaoChat, opt => opt.Ignore());
    }
}
