using AutoMapper;
using MediatR;
using RealEstateManagement.Application.Contracts.Presistence;
using RealEstateManagement.Domain.Aggregates.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomersListVm>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IAsyncRepository<Customer> customerRepository,
                                            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomersListVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<List<CustomersListVm>>(customers);
        }
    }
}
