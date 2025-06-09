using AutoMapper;
using ServiSy_v1_Business.DTOs;
using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioCreateDto, Usuario>();

            CreateMap<Servico, Servico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Servico, ServicoDto>();
            CreateMap<ServicoEditDto, Servico>()
                .ForMember(dest => dest.Prestado_Id, opt => opt.Ignore())
                .ForMember(dest => dest.Prestador, opt => opt.Ignore())
                .ForMember(dest => dest.Feedbacks, opt => opt.Ignore());
            CreateMap<ServicoCreateDto, Servico>();

            CreateMap<Feedback, Feedback>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Feedback, FeedbackDto>();
            CreateMap<FeedbackEditDto, Feedback>()
                .ForMember(dest => dest.Servico, opt => opt.Ignore())
                .ForMember(dest => dest.Servico_Id, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario_Id, opt => opt.Ignore());
            CreateMap<FeedbackCreateDto, Feedback>();
        }
    }
}
