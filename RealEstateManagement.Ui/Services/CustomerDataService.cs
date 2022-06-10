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
    public class CustomerDataService : ICustomerDataService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorage;

        public CustomerDataService(IClient client, IMapper mapper, ILocalStorageService localStorage)
        {
            _mapper = mapper;
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            var allCustomers = await _client.GetAllCustomersAsync();
            var mappedCustomers = _mapper.Map<ICollection<CustomerViewModel>>(allCustomers);

            return mappedCustomers.ToList();
        }

        public async Task<Guid> CreateCustomer(CustomerViewModel createCustomerViewModel)
        {
            CreateCustomerCommand createCustomerCommand = _mapper.Map<CreateCustomerCommand>(createCustomerViewModel);
            var createCustomerCommandResponse = await _client.CreateCustomerAsync(createCustomerCommand);

            return createCustomerCommandResponse;
        }

        public async Task UpdateCustomer(CustomerViewModel customerViewModel)
        {
            UpdateCustomerCommand updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            await _client.UpdateCustomerAsync(updateCustomerCommand);
        }

        public async Task DeleteCustomer(Guid id)
        {
            await _client.DeleteCustomerAsync(id);
        }
    }
}