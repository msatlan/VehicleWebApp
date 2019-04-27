﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.ViewModels.VehicleMakeViewmodels;
using VehicleWebApp.MVC.ViewModels.VehicleMakeViewModels;
using VehicleWebApp.MVC.ViewModels.VehicleModelViewModels;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.MVC.Mapping
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<SaveVehicleMakeViewModel, VehicleMake>();

            CreateMap<SaveVehicleModelViewModel, VehicleModel>();

            CreateMap<VehicleMakePaginationViewModel, PaginationModel>();
        }
    }
}
