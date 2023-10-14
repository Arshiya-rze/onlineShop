namespace api.Repositories;

public class AccountRepository : IAccountRepository
{
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;

    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        _collection = database.GetCollection<AppUser>(_collectionName);
    }

    public async Task<UserDto?> CreateAsync(RegisterDto userInput, CancellationToken cancellationToken)
    {
        // check if user/email already exists
        bool doesAccountExist = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doesAccountExist)
            return null;

        // if user/email does not exist, create a new AppUser. 
        AppUser appUser = new AppUser(
            Id: null,
            Email: userInput.Email.ToLower().Trim(),
            Password: userInput.Password,
            ConfirmPassword: userInput.ConfirmPassword
        );

        if (_collection is not null)
            await _collection.InsertOneAsync(appUser, null, cancellationToken);

        if (appUser.Id is not null)
        {
            UserDto userDto = new UserDto(
                Id: appUser.Id,
                Email: appUser.Email // amir@gmail.com
            );

            return userDto;
        }

        return null;
    }

    public async Task<UserDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()
            && user.Password == userInput.Password).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        if (appUser.Id is not null)
        {
            UserDto userDto = new UserDto(
                Id: appUser.Id,
                Email: appUser.Email
            );

            return userDto;
        }

        return null;
    }
}