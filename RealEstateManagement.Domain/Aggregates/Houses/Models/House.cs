using RealEstateManagement.Domain.Base;
using RealEstateManagement.Domain.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Aggregates.Houses
{

    [Collection(nameof(House))]
    public class House : AuditableEntity, IAggregateRoot
    {
        #region Properties
        public OfferType OfferType { get; protected set; }
        public ICollection<HouseAddress> Addresses { get; set; }
        public ICollection<HouseImage> Images { get; protected set; }
        #endregion

        public void AddHouseImage(HouseImage houseImage)
        {
            if (Images == null)
                Images = new List<HouseImage>();

            Images.Add(houseImage);
        }
    }
}
