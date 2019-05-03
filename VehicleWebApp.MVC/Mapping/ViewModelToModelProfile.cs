using AutoMapper;
using VehicleWebApp.MVC.ViewModels;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;

namespace VehicleWebApp.MVC.Mapping
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<VehicleMakeViewModel, VehicleMake>();

            CreateMap<VehicleModelViewModel, VehicleModel>();

            CreateMap<QueryViewModel, PagingModel>();

            CreateMap<QueryViewModel, SortingModel>();

            CreateMap<QueryViewModel, FilteringModel>();
        }
    }
}
