using gateway_api_final.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Entities.DataTransferObjects
{
    public class PeripheralDto
    {
        [StringLength(60, ErrorMessage = "Vendor can't be longer than 60 characters")]
        public string Vendor { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTimeOffset? CreationDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public PeripheralStatus? Status { get; set; }

        [Required]
        public string GatewayId { get; set; }
    }
}
