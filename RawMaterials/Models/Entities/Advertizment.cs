using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Advertizment
    {
        public long Id { get; set; }

        public TeamWork TeamWork { get; set; }

        public int TeamWorkId { get; set; }

        public PaymentInfo PaymentInfo { get; set; }

        public long PaymentInfoId { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public bool Active { get; set; }

        public string Media { get; set; }


    }
}
