using MediatR;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.UpdateHouse
{
    public class UpdateHouseCommand : IRequest
    {
        public Guid Id { get; set; }
        public OfferType OfferType { get; protected set; }
        public ICollection<HouseAddress> Addresses { get; set; }
    }
}
