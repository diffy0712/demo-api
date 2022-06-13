global using FastEndpoints;
using FastEndpoints.Swagger;
using Api.Data;
using Api.Repositories;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "DemoApi RESTful API";
    settings.Version = "v1";
});

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();

var app = builder.Build();


app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.Run();