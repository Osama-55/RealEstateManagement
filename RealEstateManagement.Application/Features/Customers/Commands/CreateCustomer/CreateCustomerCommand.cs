using MediatR;
using RealEstateManagement.Domain.Aggregates.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CustomerPhoneNumber> PhoneNumbers { get; set; }
        public ICollection<CustomerAddress> Addresses { get; set; }
    }
}
