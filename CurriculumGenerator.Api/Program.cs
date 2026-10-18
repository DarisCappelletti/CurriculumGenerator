using CurriculumGenerator.Api.Services;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

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
else
{
    // In debug la UI è servita da Vite in proxy: basta F5 sull'API, niente
    // secondo terminale per npm run dev.
    // Nota: non usiamo UseReactDevelopmentServer perché legge l'output di npm
    // aspettando il messaggio di create-react-app ("Compiled successfully!"),
    // che Vite non stampa mai: avviamo Vite noi e attendiamo la porta.
    const int portaVite = 3000;
    var uiPath = Path.GetFullPath(Path.Combine(app.Environment.ContentRootPath, "..", "curriculum-generator-ui"));

    var giaAvviato = false;
    try
    {
        using var sonda = new System.Net.Sockets.TcpClient();
        await sonda.ConnectAsync("127.0.0.1", portaVite);
        giaAvviato = true;
    }
    catch { /* porta chiusa: Vite non sta girando */ }

    if (!giaAvviato)
    {
        var vite = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c npm run dev")
        {
            WorkingDirectory = uiPath,
            UseShellExecute = false,
        });
        app.Lifetime.ApplicationStopping.Register(() =>
        {
            try { vite?.Kill(entireProcessTree: true); } catch { /* già chiuso */ }
        });

        // Attendi che il dev server risponda (max 30 s)
        var scadenza = DateTime.UtcNow.AddSeconds(30);
        while (DateTime.UtcNow < scadenza)
        {
            try
            {
                using var sonda = new System.Net.Sockets.TcpClient();
                await sonda.ConnectAsync("127.0.0.1", portaVite);
                break;
            }
            catch { await Task.Delay(500); }
        }
    }

    // /api NON passa dal proxy SPA: Vite rimanderebbe qui quelle chiamate
    // (il suo proxy /api punta a quest'app) e si creerebbe un loop infinito
    app.MapWhen(ctx => !ctx.Request.Path.StartsWithSegments("/api"), spaBranch =>
    {
        spaBranch.UseSpa(spa =>
        {
            spa.Options.SourcePath = Path.Combine("..", "curriculum-generator-ui");
            spa.UseProxyToSpaDevelopmentServer($"http://localhost:{portaVite}");
        });
    });
}

app.Run();