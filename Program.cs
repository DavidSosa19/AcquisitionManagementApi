using AcquisitionManagementAPI.Models;
using AcquisitionManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AcquisitiondbContext>(
    options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAcquisitionService, AcquisitionService>();
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<IUnityService, UnityService>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();

var app = builder.Build();


app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html", permanent: false);
        return;
    }
    await next();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
