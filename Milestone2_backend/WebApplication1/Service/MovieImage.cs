using WebApplication1.IService;

namespace WebApplication1.Service
{
    public class MovieImage : IMovieImage
    {
        private readonly IWebHostEnvironment _environment;

        public MovieImage(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveImage(IFormFile img, string name)
        {
            var imagefolder = Path.Combine(_environment.ContentRootPath, "MovieImages");

            if (!Directory.Exists(imagefolder)) /// create the moviImages folder if not exists
            {
                Directory.CreateDirectory(imagefolder);
            }

            string[] fileext = [".jpg", ".jpeg", ".png"];

            var ext = Path.GetExtension(img.FileName);
            if (!fileext.Contains(ext)) // to check whether the file is a image type png or jpg or jpeg
            {
                throw new ArgumentException($"Only {string.Join(",", fileext)} are allowed.");
            }

            string uniqueFileName = Guid.NewGuid().ToString() + name + ext;

            string imagePath = Path.Combine(imagefolder, uniqueFileName);

            using var stream = new FileStream(imagePath, FileMode.Create);
            await img.CopyToAsync(stream);

            return imagePath;
        }

        public void Deleteimg(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }
            //var cpath = _environment.ContentRootPath;
            var path = Path.Combine(_environment.ContentRootPath, "MovieImages", filename);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Invalid File path");
            }
            File.Delete(path);
        }

        public async Task<string> SaveImage(List<IFormFile> images, string name)
        {
            var imagefolder = Path.Combine(_environment.ContentRootPath, "MovieImages");

            if (!Directory.Exists(imagefolder)) /// create the moviImages folder if not exists
            {
                Directory.CreateDirectory(imagefolder);
            }

            string[] fileext = [".jpg", ".jpeg", ".png"];
            string imagepaths ="";

            foreach (var img in images)
            {
                var ext = Path.GetExtension(img.FileName);
                if (!fileext.Contains(ext)) // to check whether the file is a image type png or jpg or jpeg
                {
                    throw new ArgumentException($"Only {string.Join(",", fileext)} are allowed.");
                }

                string uniqueFileName = Guid.NewGuid().ToString() + name + ext;

                string imagePath = Path.Combine(imagefolder, uniqueFileName);

                using var stream = new FileStream(imagePath, FileMode.Create);
                await img.CopyToAsync(stream);
                if (imagepaths=="")
                {
                    imagepaths = imagePath;
                }
                else
                {
                    imagepaths += "," + imagePath;
                }
           
            }
            return imagepaths;

        }

    }
}
