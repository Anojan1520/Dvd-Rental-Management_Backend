
using Microsoft.Extensions.FileProviders;
using WebApplication1.Controller;
using WebApplication1.Database;
using WebApplication1.IRepository;
using WebApplication1.IRepositroy;
using WebApplication1.IService;
using WebApplication1.Repository;
using WebApplication1.Service;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            var DatabaseInitialize = new DatabaseInitialize(connectionString);
            DatabaseInitialize.Initialize();

            //dependency add service and Repository
            //IUserRepository userRepository = new UserRepository(connectionString);
            //IUserService userService = new UserService(userRepository);
            //UsersController userController = new UsersController(userService);

            builder.Services.AddSingleton<IUserRepository>(provider => new UserRepository(connectionString));
            builder.Services.AddSingleton<IUserService>(provider => new UserService(provider.GetRequiredService<IUserRepository>()));


            builder.Services.AddSingleton<ILoginRepository>(provider => new LoginRepository(connectionString));
            builder.Services.AddSingleton<ILoginService>(provider => new LoginService(provider.GetRequiredService<ILoginRepository>(),provider.GetRequiredService<IUserRepository>()));

            builder.Services.AddSingleton<INotificationRepository>(provider => new NotificationRepository(connectionString));
            builder.Services.AddSingleton<INotificationService>(provider => new NotificationService(provider.GetRequiredService<INotificationRepository>()));

            builder.Services.AddSingleton<IConfirmOrderRepository>(provider => new ConfirmOrderRepository(connectionString));
            builder.Services.AddSingleton<IConfirmOrderService>(provider => new ConfirmOrderService(provider.GetRequiredService<IConfirmOrderRepository>()));



            builder.Services.AddSingleton<IMovieImage>(provider => new MovieImage(provider.GetRequiredService<IWebHostEnvironment>()));

            builder.Services.AddSingleton<IMovieRepository>(provider => new MovieRepository(connectionString));
            builder.Services.AddSingleton<IMovieService>(provider => new MovieService(provider.GetRequiredService<IMovieRepository>(), provider.GetRequiredService<IMovieImage>()));


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "MovieImages")),
                RequestPath = "/Resources"
            });

            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();
            
            
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
