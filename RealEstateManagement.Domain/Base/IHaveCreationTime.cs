using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Base
{
    public interface IHaveCreationTime
    {
       public DateTime CreationDate { get; set; }
    }
}
