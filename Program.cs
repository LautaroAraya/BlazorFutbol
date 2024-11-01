using BlazorFutbol.Interfaces;
using BlazorFutbol;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorFutbol.Modelos;
using CurrieTechnologies.Razor.SweetAlert2;
using Firebase.Auth;
using BlazorFutbol.Services.Login;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Logging.SetMinimumLevel(LogLevel.Debug);
        var urlApi = builder.Configuration.GetValue<string>("urlApi");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlApi) });
        builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        builder.Services.AddScoped<GenericService<Liga>>();
        builder.Services.AddScoped<GenericService<Equipo>>();
        builder.Services.AddScoped<GenericService<Entrenador>>();
        builder.Services.AddScoped<GenericService<Jugador>>();
        builder.Services.AddScoped<GenericService<Partido>>();
        builder.Services.AddScoped<FirebaseAuthService>();

        builder.Services.AddSweetAlert2();
        await builder.Build().RunAsync();
    }
}