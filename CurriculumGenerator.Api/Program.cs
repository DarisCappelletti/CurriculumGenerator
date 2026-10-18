using CurriculumGenerator.Api.Services;
using DinkToPdf.Contracts;
using DinkToPdf;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddSingleton<CurriculumGeneratorService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

// Servi file statici (per la build React in wwwroot)
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

if (!app.Environment.IsDevelopment())
{
    // In produzione: fallback su index.html per il routing SPA
    app.MapFallbackToFile("index.html");
}

app.Run();