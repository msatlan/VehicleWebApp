using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.ViewModels.Make;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.MVC.Mapping
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<SaveVehicleMakeViewModel, VehicleMake>();
        }
    }
}
