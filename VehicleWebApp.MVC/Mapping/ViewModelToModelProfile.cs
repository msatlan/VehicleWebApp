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

            CreateMap<QueryViewModel, PagingModel>().ForMember(dest => dest.CurrentPage, opts => opts.NullSubstitute(1))
                .ForMember(dest => dest.ObjectsPerPage, opts => opts.NullSubstitute(3));

            CreateMap<QueryViewModel, SortingModel>();

            CreateMap<QueryViewModel, FilteringModel>();
        }
    }
}
