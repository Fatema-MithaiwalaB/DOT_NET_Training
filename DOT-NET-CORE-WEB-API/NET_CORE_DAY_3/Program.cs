using NET_CORE_DAY_2;
using NET_CORE_DAY_3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFileService,FileService>();

var key_s = builder.Services.AddSingleton<IGuidServicesSingleton, GuildServices>(); //singleton
var key_t = builder.Services.AddTransient<IGuidServicesTransient, GuildServices>(); //transient
var key_sc = builder.Services.AddScoped<IGuidServicesScoped, GuildServices>(); //scoped

Console.WriteLine($"Singleton: {key_s} \nTransient: {key_t} \nScoped: {key_sc}");

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

app.MapGet("/Guid", (IGuidServicesSingleton idSingleton,
                    IGuidServicesScoped idScoped1, IGuidServicesScoped idScoped2,
                    IGuidServicesTransient idTransient1, IGuidServicesTransient idTransient2) =>
{
    return $"Singleton instance: {idSingleton.Value}\r\n\r\n" +
        $"Scoped instance 1: {idScoped1.Value}\r\nScoped instance 2: {idScoped2.Value}\r\n\r\n" +
        $"Transient instance 1: {idTransient1.Value}\r\nTransient instance 2: {idTransient2.Value}";
});

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
