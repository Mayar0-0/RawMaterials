using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class TeamWork : User
    {
        public string Field_Name { get; set; }

        public virtual List<Advertizment> Advertizments { get; set; }

    }
}
