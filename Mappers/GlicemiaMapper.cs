using AutoMapper;

using ControleGlicemia_002.Models;
using ControleGlicemia_002.ViewModel;

namespace ControleGlicemia_002.Mappers
{
    public class GlicemiaMapper : Profile
    {
        public GlicemiaMapper()
        {
            CreateMap<GlicemiaViewModel, Glicemia>();
            CreateMap<Glicemia, GlicemiaViewModel>();
        }
    }
}
