using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.DeleteHouse
{
    public class DeleteHouseCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
