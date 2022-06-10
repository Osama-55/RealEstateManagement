using AutoMapper;
using MediatR;
using RealEstateManagement.Application.Contracts.Presistence;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Houses.Commands.AddHouseImages
{
    public class AddHouseImagesCommandHandler : IRequestHandler<AddHouseImagesCommand>
    {
        private readonly IAsyncRepository<House> _houseRepository;
        private readonly IMapper _mapper;

        public AddHouseImagesCommandHandler(IAsyncRepository<House> houseRepository,
                                            IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddHouseImagesCommand request, CancellationToken cancellationToken)
        {
            var house = await _houseRepository.GetByIdAsync(request.Id);

            var houseImages = _mapper.Map<List<HouseImage>>(request.Images);

            houseImages.ForEach(houseImage =>
            {
                house.AddHouseImage(houseImage);
            });

            await _houseRepository.UpdateAsync(house);

            return Unit.Value;
        }
    }
}