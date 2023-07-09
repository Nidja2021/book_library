

namespace BookLibrary.Services;

public class UsersService : IUsersService
{
    private readonly DataContext _context;

    public UsersService(DataContext context)
    {
        _context = context;
    }

    public async Task<User?> RegisterUser(UserDto userDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
        if (user != null) throw new Exception("User already exists");
        
        user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) throw new Exception("User does not exist");

        return user;
    }
}