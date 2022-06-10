using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.AddHouseImages
{
    public class AddHouseImagesCommand : IRequest
    {
        public Guid Id { get; set; }
        public ICollection<CreateHouseImageDto> Images { get; set; }
    }
}
