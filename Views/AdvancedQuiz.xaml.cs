namespace QuizGame.Views;

public partial class AdvancedQuiz : ContentPage {

    private readonly List<string> _resultsImage = [
        "score0",
        "score1",
        "score2",
        "score3",
        "score4",
    ];

    private int _questionIndex = 1;
    private int _surferPoints = 0;

    public AdvancedQuiz() {
        InitializeComponent();

        var current = App.QuestionRepo.Get(_questionIndex);

        QuestionImage.Source = current.QuestionImage;
        QuestionLabel.Text = current.QuestionText ?? "Oops, something went wrong...";
    }

    private void AnswerSwiped(bool answer) {
        if(_questionIndex < App.QuestionRepo.Count())
            _surferPoints += App.QuestionRepo.Get(_questionIndex).ApplySurferPoint(answer);

        _questionIndex++;

        if(_questionIndex == App.QuestionRepo.Count() + 1) {

            QuestionImage.Source = _resultsImage[_surferPoints];
            QuestionLabel.Text = $"You are this amount surfer bro: {_surferPoints}";

            return;
        }

        QuestionImage.Source = App.QuestionRepo.Get(_questionIndex).QuestionImage;
        QuestionLabel.Text = App.QuestionRepo.Get(_questionIndex).QuestionText ?? "Oops, something went wrong...";
    }
    
    private void Image_OnSwiped_Left(object? sender, SwipedEventArgs e) {
        AnswerSwiped(false);
    }

    private void Image_OnSwiped_Right(object? sender, SwipedEventArgs e) {
        AnswerSwiped(true);
    }
}