using dotnet_rpg.Services.CharacterService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// swagger open api setting
builder.Services.AddSwaggerGen(); 

// let web api to know that it has to use the CharacterService class whenever a controller wants
// to inject the CharacterService
// In essence, we registered the character service here
// we create a new instance of the requested service for every request
builder.Services.AddScoped<ICharacterService, CharacterService>();

// provides a new  instance to every controller and to every service, even within the same request
// builder.Services.AddTransient<ICharacterService, CharacterService>();

// only one instance for every request
// builder.Services.AddSingleton<ICharacterService, CharacterService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
