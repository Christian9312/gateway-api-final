using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Model
{
    public class Peripheral
    {
        [Required]
        public uint UId { get; set; }

        public string Vendor { get; set; }

        [Required]
        public DateTimeOffset? CreationDate { get; set; }

        [Required]
        public PeripheralStatus? Status { get; set; }

        public string GatewayId { get; set; }
        public Gateway Gateway { get; set; }


    }

    public enum PeripheralStatus
    {

        [Description("Offline")]
        Offline,

        [Description("Online")]
        Online
    }
}
