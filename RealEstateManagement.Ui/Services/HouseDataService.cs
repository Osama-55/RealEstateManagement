using AutoMapper;
using Blazored.LocalStorage;
using RealEstateManagement.Ui.Contracts;
using RealEstateManagement.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateManagement.Ui.Services
{
    public class HouseDataService : IHouseDataService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorage;

        public HouseDataService(IClient client, IMapper mapper, ILocalStorageService localStorage)
        {
            _mapper = mapper;
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<List<HouseViewModel>> GetAllHouses()
        {
            var allHouses = await _client.GetAllHousesAsync();
            var mappedHouses = _mapper.Map<ICollection<HouseViewModel>>(allHouses);

            return mappedHouses.ToList();
        }

        public async Task<Guid> CreateHouse(HouseViewModel createHouseViewModel)
        {
            CreateHouseCommand createHouseCommand = _mapper.Map<CreateHouseCommand>(createHouseViewModel);
            var createHouseCommandResponse = await _client.CreateHouseAsync(createHouseCommand);

            return createHouseCommandResponse;
        }

        public async Task UpdateHouse(HouseViewModel houseViewModel)
        {
            UpdateHouseCommand updateHouseCommand = _mapper.Map<UpdateHouseCommand>(houseViewModel);
            await _client.UpdateHouseAsync(updateHouseCommand);
        }

        public async Task DeleteHouse(Guid id)
        {
            await _client.DeleteHouseAsync(id);
        }
    }
}