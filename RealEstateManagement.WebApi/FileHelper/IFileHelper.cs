namespace RealEstateManagement.WebApi.Helpers
{
    public interface IFileHelper
    {
        Task<string> SaveFormFileAndGetFileName(IFormFile file);
    }
}
