using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.ViewModels;
using VehicleWebApp.MVC.ViewModels.Common;
using VehicleWebApp.MVC.ViewModels.VehicleMakeViewmodels;
using VehicleWebApp.MVC.ViewModels.VehicleModelViewModels;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;

namespace VehicleWebApp.MVC.Mapping
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<SaveVehicleMakeViewModel, VehicleMake>();

            CreateMap<SaveVehicleModelViewModel, VehicleModel>();

            CreateMap<QueryViewModel, PagingModel>();

            CreateMap<QueryViewModel, SortingModel>();

            CreateMap<QueryViewModel, FilteringModel>();
        }
    }
}
