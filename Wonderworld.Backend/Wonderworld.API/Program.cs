using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Wonderworld.API.Services.AccountServices;
using Wonderworld.Application;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Interfaces;
using Wonderworld.Application.Interfaces.Services;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;
using Wonderworld.Application.Interfaces.Services.ExternalServices;
using Wonderworld.Infrastructure.Services;
using Wonderworld.Infrastructure.Services.DefaultDataServices;
using Wonderworld.Infrastructure.Services.ExternalServices;
using Wonderworld.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ISharedLessonDbContext).Assembly));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AlloyAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = "http://localhost:7275",
            ValidIssuer = "http://localhost:7275",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("yJhcmJjPj9143mZN2JhcmJjPj9143mZN"))
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpClient<IOrganizationSearchService, OrganizationSearchService>(c =>
{
    c.BaseAddress = new Uri("https://search-maps.yandex.ru/v1/");
});


builder.Services.AddScoped<ISharedLessonDbContext, SharedLessonDbContext>();
builder.Services.AddScoped<IDefaultSearchService, DefaultSearchService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IOrganizationSearchService, OrganizationSearchService>();
builder.Services.AddScoped<IYandexAccountService, YandexAccountService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var servicesProvider = scope.ServiceProvider;
    try
    {
        var context = servicesProvider.GetRequiredService<SharedLessonDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = servicesProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AlloyAll");
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();