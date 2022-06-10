using System;

namespace RealEstateManagement.Ui.ViewModels
{
    public class CustomerViewModel
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CustomerPhoneNumberViewModel> PhoneNumbers { get; set; }
        public ICollection<CustomerAddressViewModelcs> Addresses { get; set; }
    }
}
