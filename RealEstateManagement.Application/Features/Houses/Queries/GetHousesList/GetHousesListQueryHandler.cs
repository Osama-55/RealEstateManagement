using AutoMapper;
using MediatR;
using RealEstateManagement.Application.Contracts.Presistence;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Queries.GetHousesList
{
    public class GetHousesListQueryHandler : IRequestHandler<GetHousesListQuery, List<HousesListVm>>
    {
        private readonly IAsyncRepository<House> _houseRepository;
        private readonly IMapper _mapper;

        public GetHousesListQueryHandler(IAsyncRepository<House> houseRepository,
                                         IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<List<HousesListVm>> Handle(GetHousesListQuery request, CancellationToken cancellationToken)
        {
            var houses = await _houseRepository.GetAllAsync();
            return _mapper.Map<List<HousesListVm>>(houses);
        }
    }
}
