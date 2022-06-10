
using Microsoft.AspNetCore.Components;
using RealEstateManagement.Ui.Contracts;
using RealEstateManagement.Ui.ViewModels;
using System.Threading.Tasks;

namespace RealEstateManagement.Ui.Pages
{
    public partial class AddCustomer
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CustomerViewModel CustomerViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            CustomerViewModel = new CustomerViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await CustomerDataService.CreateCustomer(CustomerViewModel);
        }

    }
}
