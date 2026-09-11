using BookStoreApi.Extensions;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

const string allowedHostsString = "AllowedHosts";
const string corsPolicyName = "AllowAngularApp";

var builder = WebApplication.CreateBuilder(args);

var allowedHosts = builder.Configuration.GetSection(allowedHostsString).Get<string[]>();
if (allowedHosts != null && allowedHosts.Length > 0)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(corsPolicyName, policy =>
        {
            policy.WithOrigins(allowedHosts)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    });
}

builder.Services.AddControllers();
builder.Services.AddOpenApi("v1", options =>
{
    options.AddDocumentTransformer((document, _, _) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "Store for learn",
            Description = "Учебный проект для того, чтобы вспомнить старое, научиться новому и пробовать применять всякое",
            Version = "v1.0.0",
            Contact = new OpenApiContact
            {
                Name = "Аноним",
                Email = "email@example.com",
                Url = new Uri("https://localhost")
            },
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            },
            TermsOfService = new Uri("https://localhost")
        };
        document.Servers = new List<OpenApiServer>
        {
            new()
            {
                Url = "http://localhost:5290",
                Description = "Development server"
            }
        };
        document.AddComponent("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            Description = "Вставьте ваш JWT токен"
        });

        return Task.CompletedTask;
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = AuthOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddStoreServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => options
        .AddPreferredSecuritySchemes("Bearer"));

    // TODO убрать в будущем
    // Создание БД при запуске
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    StoreContext.SeedData(dbContext);
}

app.UseRouting();
app.UseCors(corsPolicyName);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();