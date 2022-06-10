using RealEstateManagement.Domain.Base;
using RealEstateManagement.Domain.Common.CustomAttributes;

namespace RealEstateManagement.Domain.Aggregates.Customers
{
    [Collection(nameof(Customer))]
    public class Customer : AuditableEntity, IAggregateRoot
    {
        #region Properties
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public ICollection<CustomerPhoneNumber> PhoneNumbers { get; protected set; }
        public ICollection<CustomerAddress> Addresses { get; protected set; }
        #endregion
    }

}
