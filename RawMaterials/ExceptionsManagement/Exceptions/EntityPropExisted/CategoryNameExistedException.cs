using RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class CategoryNameExistedException: EntityPropExistedException
    {
        public CategoryNameExistedException(string value): base("category", "name", value) {}
    }
}
