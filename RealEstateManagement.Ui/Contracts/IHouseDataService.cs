using RealEstateManagement.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateManagement.Ui.Contracts
{
    public interface IHouseDataService
    {
        Task<List<HouseViewModel>> GetAllHouses();
        Task<Guid> CreateHouse(HouseViewModel houseViewModel);
        Task DeleteHouse(Guid id);
        Task UpdateHouse(HouseViewModel houseViewModel);
    }
}
