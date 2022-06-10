using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Queries.GetHousesList
{
    public class HousesListVm
    {
        public Guid Id { get; set; }
        public OfferType OfferType { get; set; }
        public ICollection<GetHouseImageDto> Images { get; set; }
    }
}
