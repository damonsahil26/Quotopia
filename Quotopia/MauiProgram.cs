using Microsoft.Extensions.Logging;

namespace Quotopia
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
                    fonts.AddFont("AmaticSC-Bold.ttf", "AmaticBold");
                    fonts.AddFont("AmaticSC-Regular.ttf", "AmaticRegular");
                    fonts.AddFont("Annie-Regular.ttf", "AnnieRegular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
