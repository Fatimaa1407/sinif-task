namespace WebApplication4.Utilities
{
    public static class FileExtension
    {
        public static string SaveImage(this IFormFile ImageFile, IWebHostEnvironment env, string folder)
        {
            string path = Path.Combine(env.WebRootPath, folder);
            string file = Guid.NewGuid() +ImageFile.FileName;
            string FullPath = Path.Combine(path, file);

            using (FileStream stream = new FileStream(FullPath, FileMode.Create))
            {
                ImageFile.CopyTo(stream);
            }

            return file;
        }
    }
}

