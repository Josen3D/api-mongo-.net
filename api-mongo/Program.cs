using api_mongo.Models;
using api_mongo.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add mongo setings to project
builder.Services.Configure<MongoSettings>(
        builder.Configuration.GetSection(nameof (MongoSettings)) // get class name in string
    );

// inject mongo connection
builder.Services.AddSingleton<IMongoSettings>(
        d => d.GetRequiredService<IOptions<MongoSettings>>().Value
    );

// inject services
builder.Services.AddSingleton<GameService>();

// set api urls to lowercase
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
