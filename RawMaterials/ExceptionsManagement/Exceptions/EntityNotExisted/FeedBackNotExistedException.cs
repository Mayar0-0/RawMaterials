using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted
{
    public class FeedBackNotExistedException : EntityNotExistedException
    {
        public FeedBackNotExistedException() : base("FeedBack") { }

    }
}
