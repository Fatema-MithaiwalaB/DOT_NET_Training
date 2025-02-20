var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

if (!OpenWeather.StationDictionary.TryGetClosestStation(29.3389, -98.4717, out var stationInfo))
{
    Console.WriteLine($@"Could not find a station.");
    return;
}

Console.WriteLine($@"Name: {stationInfo.Name}");
Console.WriteLine($@"ICAO: {stationInfo.ICAO}");
Console.WriteLine($@"Lat/Lon: {stationInfo.Latitude}, {stationInfo.Longitude}");
Console.WriteLine($@"Elevation: {stationInfo.Elevation}m");
Console.WriteLine($@"Country: {stationInfo.Country}");
Console.WriteLine($@"Region: {stationInfo.Region}");

app.Run();
