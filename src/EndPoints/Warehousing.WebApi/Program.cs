using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Warehousing.DataAccess.EF.Context;
using Warehousing.IOC;

var builder = WebApplication.CreateBuilder(args);
//var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
//var _siteSetting = builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();

//builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContextService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.ConfigureServices(builder.Configuration);

//#region Security JWT

//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = _siteSetting.TokenSettings.Issuer,
//        ValidAudience = _siteSetting.TokenSettings.Audience,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_siteSetting.TokenSettings.SecretKey!)),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//    };
//});

//builder.Services.AddAuthorization();

//#endregion Security JWT

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.SchemaGeneratorOptions.IgnoreObsoleteProperties = true;
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sample Project",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header
        },
        new List<string>()
        }
    });
});

#endregion Swagger

var app = builder.Build();

//app.UseCustomExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
//app.UseJWTHandler();

app.Run();


#region Logger
//Run(logger);

//void Run(NLog.Logger logger)
//{
//    try
//    {
//        logger.Debug("Initialize Main");
//        app.Run();
//    }
//    catch (Exception ex)
//    {
//        logger.Error(ex, "Stopped program because of exception");
//        throw;
//    }
//    finally
//    {
//        NLog.LogManager.Shutdown();
//    }
//}
#endregion Logger

