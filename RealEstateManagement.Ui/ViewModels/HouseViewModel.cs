namespace RealEstateManagement.Ui.ViewModels
{
    public class HouseViewModel
    {
        public OfferType OfferType { get; protected set; }
        public ICollection<HouseAddressViewModel> Addresses { get; set; }
        public ICollection<HouseImageViewModel> Images { get; set; }
    }
}
