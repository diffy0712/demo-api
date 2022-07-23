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
    settings.Description = "<a href='https://github.com/diffy0712/demo-api' target='_blank'>Backend repo</a> - " +
                           "<a href='https://github.com/diffy0712/clean-spa-architecture' target='_blank'>Frontend repo</a> <br/>" +
                           "<a href='https://www.guidgenerator.com/online-guid-generator.aspx' target='_blank'>Guid generator</a>";
    settings.Version = "v1";
});

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();


app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.Run();