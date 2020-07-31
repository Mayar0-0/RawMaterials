using System.Collections.Generic;

namespace RawMaterials.Models.Entities
{
    public class TeamWork : User
    {
        public string Field_Name { get; set; }

        public virtual List<Advertizment> Advertizments { get; set; }

    }
}
