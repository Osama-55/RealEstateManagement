using AutoMapper;
using MediatR;
using RealEstateManagement.Application.Contracts.Presistence;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.UpdateHouse
{
    public class UpdateHouseCommandHandler : IRequestHandler<UpdateHouseCommand>
    {
        private readonly IAsyncRepository<House> _houseRepository;
        private readonly IMapper _mapper;

        public UpdateHouseCommandHandler(IAsyncRepository<House> houseRepository,
                                         IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
        {
            var houseToUpdate = await _houseRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, houseToUpdate);

            await _houseRepository.UpdateAsync(houseToUpdate);

            return Unit.Value;
        }
    }
}
