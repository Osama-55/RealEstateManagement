using AutoMapper;
using MediatR;
using RealEstateManagement.Application.Contracts.Presistence;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, Guid>
    {
        private readonly IAsyncRepository<House> _houseRepository;
        private readonly IMapper _mapper;

        public CreateHouseCommandHandler(IAsyncRepository<House> houseRepository,
                                         IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            var house = _mapper.Map<House>(request);

            var houseId = await _houseRepository.CreateAsync(house);

            return houseId;
        }
    }
}
