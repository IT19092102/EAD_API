using fuel_API.Models;
using fuel_API.Services;





var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<FuelAPISettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<QueueService>();
builder.Services.AddSingleton<UserServices>();
builder.Services.AddSingleton<StationServices>();
// builder.Services.AddSingleton<QueueServices>();




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

app.Run();
