using SQLite;

namespace QuizGame;

[Table("question")]
public class Question {

    public Question() { }

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [MaxLength(256)] public string? QuestionText { get; set; }
    [MaxLength(256)] public string? QuestionImage { get; set; }
    public bool TrueIsPositive { get; set; } = true;

    public int ApplySurferPoint(bool answer) {
        return TrueIsPositive == answer ? 1 : 0;
    }

    public override string ToString() {
        return $"Id={Id},QuestionText={QuestionText},QuestionImage={QuestionImage},TrueIsPositive={TrueIsPositive}";
    }
}