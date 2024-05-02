namespace QuizGame {
    public partial class App : Application {
        public App(QuestionRepository repository) {
            InitializeComponent();

            QuestionRepo = repository;
            MainPage = new NavigationPage(new MainPage());
            UserAppTheme = PlatformAppTheme;
        }

        public static QuestionRepository QuestionRepo { get; set; }

        protected override Window CreateWindow(IActivationState? activationState) {
            var window = base.CreateWindow(activationState);
            window.Title = "QuizGame";
            return window;
        }
    }
}