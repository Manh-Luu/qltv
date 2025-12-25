using Microsoft.Extensions.Logging;
using qltv;
using qltv.Data;
using qltv.Services;
using qltv.ViewModels;
using qltv.Views;

namespace qltv
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("materialdesignicons.ttf", "MaterialIcons");
                });

            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "library.db3");

            builder.Services.AddSingleton(
                s => new LibraryDatabase(dbPath));

            builder.Services.AddSingleton<BookService>();
            builder.Services.AddTransient<LibraryManagerViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<DocGiaViewModel>();
            builder.Services.AddTransient<DocGiaPage>();

            builder.Services.AddSingleton(new MuonTraDatabase(dbPath));
            builder.Services.AddTransient<MuonTraViewModel>();
            builder.Services.AddTransient<MuonTraPage>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}