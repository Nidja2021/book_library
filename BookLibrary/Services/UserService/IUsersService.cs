namespace BookLibrary.Services;

public interface IUsersService
{
    Task<User?> RegisterUser(UserDto userDto);
    Task<User?> GetUser(Guid id);
}