using AutoMapper;
using FamilyLoan.Core.ApplicationServices.Moeins.Commands.AddMoein;
using FamilyLoan.Core.ApplicationServices.Moeins.Commands.UpdateMoein;
using FamilyLoan.Core.Domains.Moeins;
using FamilyLoan.Core.Domains.Moeins.DTO;
using FamilyLoan.Endpoints.WebUI.VIewModels.Moeins;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Moeins
{
    public class MoeinProfile : Profile
    {
        public MoeinProfile()
        {
            CreateMap<Moein, Moein>();
            CreateMap<AddMoeinCommand, Moein>();
            CreateMap<MoeinDTO, Moein>();
            CreateMap<AddMoeinViewModel, AddMoeinCommand>();
            CreateMap<Moein, MoeinDTO>();
            CreateMap<MoeinDTO, UpdateMoeinViewModel>();
            CreateMap<UpdateMoeinViewModel, UpdateMoeinCommand>();

        }
    }
}
