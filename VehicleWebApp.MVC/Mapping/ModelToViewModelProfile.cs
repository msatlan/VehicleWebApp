using AutoMapper;
using System.Linq;
using VehicleWebApp.MVC.ViewModels;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.MVC.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>()
                .ForMember(dest => dest.Models, opts => opts.MapFrom(src => src.Models.Select(model => model.Name)
                .ToList()));

            CreateMap<VehicleModel, VehicleModelViewModel>()
                .ForMember(dest => dest.Make, opts => opts.MapFrom(src => src.Make.Name));
        }
    }
}
