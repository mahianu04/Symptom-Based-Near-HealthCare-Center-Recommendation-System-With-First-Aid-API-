using SBNHCRSWFAA;
using SBNHCRSWFAA.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure MongoDB and DI
var mongoClient = new MongoClient(builder.Configuration["MongoDBSettings:ConnectionString"]);
var mongoDatabase = mongoClient.GetDatabase(builder.Configuration["MongoDBSettings:DatabaseName"]);

// Register MongoDB services
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

// Register Application Services
builder.Services.AddSingleton<IUserServices, UserServices>();
builder.Services.AddSingleton<IHealthProfileServices, HealthProfileServices>();
builder.Services.AddSingleton<IHealthcareCenterService, HealthcareCenterService>();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map Controllers to the HTTP request pipeline
app.MapControllers();

app.Run();