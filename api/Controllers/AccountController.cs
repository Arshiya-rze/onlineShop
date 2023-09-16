namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    #region Db and Token Settings
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;
    private readonly IAccountRepository _accountRepository;

    // private readonly ITokenService _tokenService; // save user credential as a token

    // constructor - dependency injection
    public AccountController(IMongoClient client, IMongoDbSettings dbSettings, IAccountRepository accountRepository)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        _collection = database.GetCollection<AppUser>(_collectionName);

        _accountRepository = accountRepository;
        // _tokenService = tokenService;

    }
    #endregion

    // Concurrency => async
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Create(RegisterDto userInput, CancellationToken cancellationToken)
    {
        _accountRepository.CalcTotalAges(12, 25);

        if (userInput.Password != userInput.ConfirmPassword)
            BadRequest("Passwords don't match!"); // is it correct? What does it do?
                                                  // return BadRequest("Passwords don't match!");

        // check if user/email already exists
        bool doesExist = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doesExist)
            return BadRequest("Email/Username is taken.");

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
                Email: appUser.Email
            );

            return userDto;
        }

        return BadRequest("User was not created successfully");
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        _accountRepository.Create(23, "Mozhgan");

        AppUser appUser = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()
            && user.Password == userInput.Password).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return Unauthorized("Wrong username or password");

        if (appUser.Id is not null)
        {
            UserDto userDto = new UserDto(
                Id: appUser.Id,
                Email: appUser.Email
            );

            return userDto;
        }

        return BadRequest("Task failed");
    }
}
