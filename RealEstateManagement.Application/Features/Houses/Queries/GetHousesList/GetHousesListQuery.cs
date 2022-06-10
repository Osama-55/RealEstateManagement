using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Queries.GetHousesList
{
    public class GetHousesListQuery : IRequest<List<HousesListVm>>
    {
    }
}
