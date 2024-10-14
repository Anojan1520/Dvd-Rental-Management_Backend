namespace WebApplication1.IService
{
    public interface IMovieImage
    {
        Task<string> SaveImage(List<IFormFile> images, string name);
        void Deleteimg(string images);
    }
}
