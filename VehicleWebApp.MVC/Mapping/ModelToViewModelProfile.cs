using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.ViewModels.Make;
using VehicleWebApp.MVC.ViewModels.Model;
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
                .ForPath(dest => dest.Make.Id, opts => opts.MapFrom(src => src.Make.Id))
                .ForPath(dest => dest.Make.Name, opts => opts.MapFrom(src => src.Make.Name))
                .ForPath(dest => dest.Make.Abbreviation, opts => opts.Ignore())
                .ForPath(dest => dest.Make.Models, opts => opts.Ignore());
        }
    }
}
