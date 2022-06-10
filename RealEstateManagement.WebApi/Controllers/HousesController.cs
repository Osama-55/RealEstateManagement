using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Features.Houses.Commands.AddHouseImages;
using RealEstateManagement.Application.Features.Houses.Commands.CreateHouse;
using RealEstateManagement.Application.Features.Houses.Commands.DeleteHouse;
using RealEstateManagement.Application.Features.Houses.Commands.UpdateHouse;
using RealEstateManagement.Application.Features.Houses.Queries.GetHousesList;
using RealEstateManagement.WebApi.Helpers;

namespace RealEstateManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private FileHelper _fileHelper;

        public HousesController(IMediator mediator,
                                IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
            _fileHelper = new FileHelper(Path.Combine("wwwroot", _configuration.GetValue<string>("HousesImagesFolderPath")));
        }

        [HttpGet("GetAllHouses", Name = "GetAllHouses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<HousesListVm>>> GetAllHouses()
        {
            var housesDtos = await _mediator.Send(new GetHousesListQuery());
            return Ok(housesDtos);
        }

        [HttpPost("CreateHouse")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateHouse([FromBody] CreateHouseCommand createHouseCommand)
        {
            var response = await _mediator.Send(createHouseCommand);
            return Ok(response);
        }

        [HttpPut("{houseId}/AddHouseImages")]
        public async Task<ActionResult> UploadHouseImages(Guid houseId, List<IFormFile> images)
        {
            
            var imagesNames = new List<string>();

            images.ToList().ForEach(image =>
            {
                var imageName = _fileHelper.SaveFormFileAndGetFileName(image);
                imagesNames.Add(imageName.Result);
            });

            var houseImagesDto = imagesNames.Select(imageName => new CreateHouseImageDto { ImageName = imageName }).ToList();

            var addHouseImagesCommand = new AddHouseImagesCommand { Id = houseId, Images = houseImagesDto };

            await _mediator.Send(addHouseImagesCommand);

            return NoContent();
        }

        [HttpDelete("DeleteHouse/{id}", Name = "DeleteHouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            var deleteHouseCommand = new DeleteHouseCommand { Id = id };
            await _mediator.Send(deleteHouseCommand);
            return NoContent();
        }

        [HttpPut("UpdateHouse")]
        public async Task<ActionResult> UpdateHouse([FromBody] UpdateHouseCommand updateHouseCommand)
        {
            await _mediator.Send(updateHouseCommand);
            return NoContent();
        }


    }
}
