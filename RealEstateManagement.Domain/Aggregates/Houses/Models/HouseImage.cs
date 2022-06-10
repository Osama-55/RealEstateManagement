using RealEstateManagement.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Aggregates.Houses
{
    public class HouseImage : AuditableEntity
    {
        #region Properties
        public string ImageName { get; set; }
        #endregion
    }
}
