using System.Diagnostics;
using SQLite;

namespace QuizGame;

public class QuestionRepository {
    private readonly SQLiteConnection _connection;

    public QuestionRepository(string dbPath) {
        _connection = new SQLiteConnection(dbPath);
        _connection.CreateTable<Question>();

        Debug.WriteLine($"Question DB: ");
        foreach (var elem in _connection.Table<Question>().ToList()) {
            Debug.WriteLine($"  {elem}");
        }

        if (_connection.Table<Question>().Any()) return; //If we have no data, add data :)
        _connection.Insert(new Question { QuestionText = "Are you radical?", QuestionImage = "radical" });
        _connection.Insert(new Question { QuestionText = "Do you like surfing?", QuestionImage = "surfing" });
        _connection.Insert(new Question {
            QuestionText = "Are you afraid of sharks?", QuestionImage = "shark", TrueIsPositive = false
        });
        _connection.Insert(new Question { QuestionText = "Want some brewskis?", QuestionImage = "brewskis" });
    }

    public Question Get(int id) {
        return _connection.Get<Question>(id);
    }

    public int Count() {
        return _connection.Table<Question>().Count();
    }
}