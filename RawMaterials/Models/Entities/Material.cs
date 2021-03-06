﻿namespace RawMaterials.Models.Entities
{
    public class Material
    {
        public long Id { get; set; }

        public virtual Category Category { get; set; }

        public long CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
