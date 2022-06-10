using MediatR;
using RealEstateManagement.Application.Contracts.Presistence;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.DeleteHouse
{
    public class DeleteHouseCommandHandler : IRequestHandler<DeleteHouseCommand>
    {
        private readonly IAsyncRepository<House> _houseRepository;

        public DeleteHouseCommandHandler(IAsyncRepository<House> houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task<Unit> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
        {
            await _houseRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
