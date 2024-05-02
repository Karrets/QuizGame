using System.Diagnostics;
using SQLite;

namespace QuizGame.Views;

public partial class MainPage : ContentPage {
    private readonly List<string> _resultsImage = [
        "score0",
        "score1",
        "score2",
        "score3",
        "score4",
    ];

    private int _questionIndex = 1;
    private int _surferPoints = 0;
    public MainPage() {
        InitializeComponent();

        var current = App.QuestionRepo.Get(_questionIndex);

        QuestionImage.Source = current.QuestionImage;
        QuestionLabel.Text = current.QuestionText ?? "Oops, something went wrong...";
    }

    private void AnswerPressed(bool answer) {
        _surferPoints += App.QuestionRepo.Get(_questionIndex).ApplySurferPoint(answer);

        _questionIndex++;

        if (_questionIndex == App.QuestionRepo.Count() + 1) {
            YesButton.IsVisible = false;
            NoButton.IsVisible = false;
            AdvancedQuizButton.IsVisible = true;

            QuestionImage.Source = _resultsImage[_surferPoints];
            QuestionLabel.Text = $"You are this amount surfer bro: {_surferPoints}";

            return;
        }

        QuestionImage.Source = App.QuestionRepo.Get(_questionIndex).QuestionImage;
        QuestionLabel.Text = App.QuestionRepo.Get(_questionIndex).QuestionText ?? "Oops, something went wrong...";
    }

    private void YesButton_OnPressed(object? sender, EventArgs e) {
        AnswerPressed(true);
    }

    private void NoButton_OnPressed(object? sender, EventArgs e) {
        AnswerPressed(false);
    }

    private void AdvancedQuizButton_OnPressed(object? sender, EventArgs e) {
        Navigation.PushAsync(new AdvancedQuiz(), true);
    }
}