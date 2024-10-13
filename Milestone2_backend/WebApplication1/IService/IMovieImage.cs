namespace WebApplication1.IService
{
    public interface IMovieImage
    {
        Task<string> SaveImage(List<IFormFile> images, string name);
        Task<string> SaveImage(IFormFile img, string name);
    }
}
