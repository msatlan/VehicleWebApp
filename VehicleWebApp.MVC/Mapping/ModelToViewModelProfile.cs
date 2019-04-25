using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.ViewModels.VehicleMakeViewmodels;
using VehicleWebApp.MVC.ViewModels.VehicleModelViewModels;
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

            CreateMap<VehicleModel, VehicleModelViewModel>();
        }
    }
}
