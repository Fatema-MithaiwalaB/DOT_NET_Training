using NET_CORE_DAY_2;
using NET_CORE_DAY_3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFileService,FileService>();

builder.Services.AddSingleton<IGuidServices, GuildServices>(); //singleton
builder.Services.AddTransient<IGuidServices, GuildServices>(); //transient
builder.Services.AddScoped<IGuidServices, GuildServices>(); //scoped

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherService, WeatherService>();

var CorsSetting = builder.Configuration.GetSection("AllowedCors");

var CorsOrigin = CorsSetting.GetSection("Origins").Get<string[]>() ?? new string[] { };
var CorsMethod = CorsSetting.GetSection("Methods").Get<string[]>() ?? new string[] { };
var CorsHeader = CorsSetting.GetSection("Headers").Get<string[]>() ?? new string[] { };

builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(CorsOrigin)
              .WithMethods(CorsMethod)
              .WithHeaders(CorsHeader);
    }
        );
});



var app = builder.Build();

//Custom middleware
app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 1 executed");
    await next();
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<Middleware>();


//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Middleware 2 created");
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors("CorsPolicy");

app.UseRouting();

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
