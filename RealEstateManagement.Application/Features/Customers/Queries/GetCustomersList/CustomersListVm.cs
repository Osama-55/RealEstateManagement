using RealEstateManagement.Domain.Aggregates.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CustomerPhoneNumber> PhoneNumbers { get; set; }
        public ICollection<CustomerAddress> Addresses { get; set; }
    }
}
