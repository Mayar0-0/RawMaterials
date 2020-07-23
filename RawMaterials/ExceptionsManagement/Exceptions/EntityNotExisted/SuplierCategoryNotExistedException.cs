using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted
{
    public class SuplierCategoryNotExistedException: EntityNotExistedException
    {
        public SuplierCategoryNotExistedException() : base("SuplierCategory") { }
    }
}
