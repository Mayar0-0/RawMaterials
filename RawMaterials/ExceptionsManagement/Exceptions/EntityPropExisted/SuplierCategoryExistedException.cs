using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class SuplierCategoryExistedException: EntityPropExistedException
    {
        public SuplierCategoryExistedException(string value) : base("Category", "name", value) { }
    }
}
