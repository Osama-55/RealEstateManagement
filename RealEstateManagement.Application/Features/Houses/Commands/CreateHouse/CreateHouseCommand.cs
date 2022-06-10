using MediatR;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseCommand : IRequest<Guid>
    {
        #region Properties
        public OfferType OfferType { get; set; }
        public ICollection<HouseAddress> Addresses { get; set; }
        #endregion
    }
}
