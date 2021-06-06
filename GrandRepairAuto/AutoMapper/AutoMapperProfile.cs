using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;
using GrandRepairAuto.Services.Models.OrderDTOs;
using GrandRepairAuto.Services.Models.ServiceDTOs;
using GrandRepairAuto.Services.Models.UserDTOs;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using GrandRepairAuto.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace GrandRepairAuto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateDTO>().ReverseMap();

            CreateMap<Order, OrderWithCustomerServicesDTO>().ReverseMap();
            CreateMap<Order, OrderCreateWithCustomerServicesDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateWithCustomerServicesDTO>().ReverseMap();

            CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerCreateDTO>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerUpdateDTO>().ReverseMap();

            CreateMap<Service, ServiceCreateDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Service, ServiceUpdateDTO>().ReverseMap();

            CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelCreateDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelUpdateDTO>().ReverseMap();

            CreateMap<CustomerService, CustomerServiceDTO>().ReverseMap();
            CreateMap<CustomerService, CustomerServiceCreateDTO>().ReverseMap();
            CreateMap<CustomerService, CustomerServiceUpdateDTO>().ReverseMap();

            CreateMap<Vehicle, VehicleCreateDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleUpdateDTO>().ReverseMap();

            CreateMap<Vehicle, VehicleWithModelAndMakeCreateDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleWithModelAndMakeUpdateDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleWithModelAndMakeDTO>().ReverseMap();

            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();

            // Tests only
            CreateMap<CustomerServiceCreateDTO, CustomerServiceUpdateDTO>().ReverseMap();
            CreateMap<OrderCreateDTO, OrderUpdateDTO>().ReverseMap();
            CreateMap<ManufacturerCreateDTO, ManufacturerUpdateDTO>().ReverseMap();
            CreateMap<VehicleCreateDTO, VehicleUpdateDTO>().ReverseMap();
            CreateMap<VehicleModelCreateDTO, VehicleModelUpdateDTO>().ReverseMap();
            CreateMap<ServiceCreateDTO, ServiceUpdateDTO>().ReverseMap();

            //MVC
            CreateMap<UserVM, UserCreateDTO>()
                .ForMember(x => x.Roles, opt => opt.MapFrom(MapUserRoles));
            CreateMap<UserVM, UserUpdateDTO>()
                .ForMember(x => x.Roles, opt => opt.MapFrom(MapUserRoles));
            CreateMap<UserDTO, UserVM>()
                .ForMember(x => x.RoleSelection, opt => opt.MapFrom(MapUserRoles));

            CreateMap<ServiceCreateDTO, ServiceVM>().ReverseMap();
            CreateMap<ServiceDTO, ServiceVM>().ReverseMap();
            CreateMap<ServiceUpdateDTO, ServiceVM>().ReverseMap();

            CreateMap<ServiceDTO, CustomerServiceCreateDTO>().ReverseMap();

            CreateMap<VehicleModelDTO, VehicleModelVM>().ReverseMap();

            CreateMap<ManufacturerDTO, ManufacturerVM>().ReverseMap();

            CreateMap<VehicleVM, VehicleWithModelAndMakeCreateDTO>().ReverseMap();
            CreateMap<VehicleVM, VehicleWithModelAndMakeDTO>().ReverseMap();
            CreateMap<VehicleVM, VehicleWithModelAndMakeUpdateDTO>().ReverseMap();

            CreateMap<VehicleVM, VehicleDTO>().ReverseMap();
            CreateMap<VehicleVM, VehicleCreateDTO>().ReverseMap();
            CreateMap<VehicleVM, VehicleUpdateDTO>().ReverseMap();

            CreateMap<OrderVM, OrderCreateWithCustomerServicesDTO>().ReverseMap();
            CreateMap<OrderVM, OrderWithCustomerServicesDTO>().ReverseMap();
            CreateMap<OrderVM, OrderUpdateWithCustomerServicesDTO>().ReverseMap();

            CreateMap<CustomerServiceVM, CustomerServiceCreateDTO>().ReverseMap();
            CreateMap<CustomerServiceVM, CustomerServiceDTO>().ReverseMap();
            CreateMap<CustomerServiceVM, CustomerServiceUpdateDTO>().ReverseMap();

            CreateMap<DetailedOrderVM, OrderDTO>().ReverseMap();
            CreateMap<DetailedOrderVM, OrderWithCustomerServicesDTO>().ReverseMap();
            CreateMap<DetailedOrderVM, VehicleModelDTO>().ReverseMap();
            CreateMap<DetailedOrderVM, VehicleDTO>().ReverseMap();
            CreateMap<DetailedOrderVM, ManufacturerDTO>().ReverseMap();
        }

        private List<string> MapUserRoles<TDTO>(UserVM vm, TDTO dto)
        {
            return Data.Enums.Roles.AllRoles.Where(x => vm.RoleSelection.FirstOrDefault(y => y.Name == x)?.Checked == true).ToList();
        }

        private List<UserVM.RoleCheckbox> MapUserRoles(UserDTO dto, UserVM vm)
        {
            return Data.Enums.Roles.AllRoles.Select(x => new UserVM.RoleCheckbox { Name = x, Checked = dto.Roles.Contains(x) }).ToList();
        }
    }
}
