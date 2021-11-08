using AutoMapper;
using gateway_api_final.Dto;
using gateway_api_final.Entities.DataTransferObjects;
using gateway_api_final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Entities.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<PeripheralDetailedDto, Peripheral>();
            CreateMap<PeripheralDto, Peripheral>();
            CreateMap<GatewayDetailedDto, Gateway>();
            CreateMap<GatewayDto, Gateway>();
        }
    }
}
