
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RealEstateManagement.Ui.Contracts;
using RealEstateManagement.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealEstateManagement.Ui.Pages
{
    public partial class CustomerOverview
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CustomerViewModel> Customers { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public string CustomerId { get; set; }
        private Guid SelectedCustomerId = Guid.Empty;
        protected override async Task OnInitializedAsync()
        {
            Customers = await CustomerDataService.GetAllCustomers();
        }

        protected void AddNewCustomer()
        {
            NavigationManager.NavigateTo("/addcustomer");
        }

        protected async Task DeleteCustomer()
        {
            await CustomerDataService.DeleteCustomer(SelectedCustomerId);
        }

        [Inject]
        public HttpClient HttpClient { get; set; }
    }
}
