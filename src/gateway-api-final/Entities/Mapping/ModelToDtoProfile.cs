using AutoMapper;
using gateway_api_final.Dto;
using gateway_api_final.Entities.DataTransferObjects;
using gateway_api_final.Model;
using gateway_api_final.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Entities.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Peripheral, PeripheralDetailedDto>().ForMember(src => src.Status,
                opt => opt.MapFrom(src => src.Status.ToDescriptionString()));
            CreateMap<Peripheral, PeripheralSimpleDto>().ForMember(src => src.Status,
                opt => opt.MapFrom(src => src.Status.ToDescriptionString()));
            CreateMap<Gateway, GatewayDto>();
            CreateMap<Gateway, GatewayDetailedDto>();
            CreateMap<Gateway, GatewaySimpleDto>();
        }
    }
}
