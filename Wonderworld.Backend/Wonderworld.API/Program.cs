using System.Reflection;
using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Application.Interfaces;
using Wonderworld.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ISharedLessonDbContext).Assembly));
});

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();