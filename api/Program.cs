var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MongoDbSettings
///// get values from this file: appsettings.Development.json /////
// get section
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));

// get values
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

// get connectionString to the db
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    MongoDbSettings uri = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;


    return new MongoClient(uri.ConnectionString);
});
#endregion MongoDbSettings

#region Cors: baraye ta'eede Angular HttpClient requests
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy => 
            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
    });
#endregion Cors

#region Dependency Injections
// builder.Services.AddSingleton<IAccountRepository, AccountRepository>(); App LifeCycle
builder.Services.AddScoped<IAccountRepository, AccountRepository>(); // Controller LifeCycle
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion Dependency Injections

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(); // this line is added

app.UseAuthorization();

app.MapControllers();

app.Run();
