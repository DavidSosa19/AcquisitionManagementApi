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

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AcquisitiondbContext>();
    dbContext.Database.EnsureDeleted(); // Opcional: Elimina la BD si ya existe
    dbContext.Database.EnsureCreated(); // Crea la BD automáticamente
    if (!dbContext.Providers.Any())
    {
        dbContext.Providers.AddRange(
           new Provider { Nombre = "Tech Corp" },
           new Provider { Nombre = "IT Solutions" }
       );
    }
    if (!dbContext.AssetServiceTypes.Any())
    {
        dbContext.AssetServiceTypes.AddRange(
            new AssetServiceType { Nombre = "Software" },
            new AssetServiceType { Nombre = "Hardware" }
        );
    }
    if (!dbContext.Unities.Any())
    {
        dbContext.Unities.AddRange(
            new Unit { Nombre = "Unidad A" },
            new Unit { Nombre = "Unidad B" }
        );
    }
    
        dbContext.SaveChanges();
    
}

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

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
