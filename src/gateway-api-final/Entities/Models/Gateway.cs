using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Model
{
    public class Gateway
    {

        public string SerialNumber { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Port { get; set; }


        public IList<Peripheral> AssociatedPeripherals { get; set; } = new List<Peripheral>();

    }
}
