

using BookLibrary.Services.BookService;

namespace BookLibrary.Config;

public static class BookLibraryServiceInstaller
{
    public static IServiceCollection AddBookLibraryServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IBookService, BookService>();
        
        services.AddDbContext<DataContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));

        return services;
    }
}