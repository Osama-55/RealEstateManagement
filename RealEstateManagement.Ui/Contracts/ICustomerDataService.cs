
using RealEstateManagement.Ui.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateManagement.Ui.Contracts
{
    public interface ICustomerDataService
    {
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<Guid> CreateCustomer(CustomerViewModel customerViewModel);
        Task DeleteCustomer(Guid id);
        Task UpdateCustomer(CustomerViewModel customerViewModel);
    }
}
