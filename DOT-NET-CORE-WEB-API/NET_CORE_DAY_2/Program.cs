using NET_CORE_DAY_2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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


app.Run(async (context) =>
{
    await context.Response.WriteAsync("Middleware 2 created");
});
 
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

app.Run();
