﻿using Microsoft.Extensions.Logging;

namespace QuizGame {
    public static partial class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                   .ConfigureFonts(fonts => {
                       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                       fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                   });

#if DEBUG
            builder.Logging.AddDebug();
            builder.Services.AddLogging(
                                        configure => {
                                            configure.AddDebug();
                                            configure.AddConsole();
                                        }
                                       );

#endif

            builder.Services.AddSingleton<QuestionRepository>(s => new QuestionRepository(
                                                                   "/storage/emulated/0/Android/data/space.kodirex.quizgame/files/db.sqlite")
                                                             );

            return builder.Build();
        }
    }
}