using Microsoft.Extensions.Logging;
using JobBoard.Mobile.Services;

namespace JobBoard.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            //builder.Services.AddScoped(sp => new HttpClient
            //{
            //    BaseAddress = new Uri(builder.Configuration["https://localhost:7241"])
            //});

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddSingleton(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7241/")
            });

            builder.Services.AddScoped(typeof(ApiService<>));

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
