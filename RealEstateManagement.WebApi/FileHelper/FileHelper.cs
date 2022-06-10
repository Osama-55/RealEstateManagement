namespace RealEstateManagement.WebApi.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string FolderPath;

        public FileHelper(string folderPath)
        {
            FolderPath = folderPath;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        public Task<string> SaveFormFileAndGetFileName(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid().ToString().Split("-")[0]}-{DateTime.Now.Ticks}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(FolderPath, fileName);
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return Task.FromResult(fileName);
            }
            throw new Exception("FailedToSaveFile");
        }
    }
}
