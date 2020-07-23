using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class ImporterCategoryExistedException: EntityPropExistedException
    {
        public ImporterCategoryExistedException(string value) : base("Category", "name", value) { }
    }
}
