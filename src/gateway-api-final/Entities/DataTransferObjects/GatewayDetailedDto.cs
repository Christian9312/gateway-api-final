﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Entities.DataTransferObjects
{
    public class GatewayDetailedDto
    {
        [Required(ErrorMessage = "Serial number is required")]
        public string SerialNumber { get; set; }

        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public IEnumerable<PeripheralSimpleDto> AssociatedPeripherals { get; set; } = new List<PeripheralSimpleDto>();
    }
}
