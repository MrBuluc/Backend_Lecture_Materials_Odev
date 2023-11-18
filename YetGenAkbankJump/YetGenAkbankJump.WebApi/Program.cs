using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text.Json.Serialization;
using YetGenAkbankJump.Persistence.Contexts;
using YetGenAkbankJump.Shared;
using YetGenAkbankJump.Shared.Services;
using YetGenAkbankJump.Shared.Utilities;
using YetGenAkbankJump.WebApi.Services;
using YetGenAkbankJumpOOPConsole.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PasswordGenerator>();

builder.Services.AddSingleton<RequestCountService>(new RequestCountService());

builder.Services.AddScoped<FakeDataService>();

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IIPService, IPService>();

builder.Services.AddSingleton<ITextService, TextService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetSection("YetgenPostgreSQLDB").Value);
});

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    CultureInfo trCulture = new("tr-TR");

    List<CultureInfo> locales = new()
    {
        trCulture,
        new("en-GB")
    };

    options.SupportedCultures = locales;

    options.SupportedUICultures = locales;

    options.DefaultRequestCulture = new(trCulture);

    options.ApplyCurrentCultureToResponseHeaders = true;
});

builder.Services.AddSharedServices();

var app = builder.Build();

app.UseCors("AllowAll");

IOptions<RequestLocalizationOptions> options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

if (options is not null)
{
    app.UseRequestLocalization(options.Value);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
