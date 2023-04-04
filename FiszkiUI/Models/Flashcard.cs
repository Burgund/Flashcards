namespace FlashcardsUI.Models;

public class Flashcard
{
    public string Name { get; set; }
    public string LearningName { get; set; }
    public Languages Language { get; set; }
    public Languages LearningLanguage { get; set; }
    public Priorities Priority { get; set; } = Priorities.Normal;
    public DateTime LastAnswer { get; set; } = DateTime.Now;
    public bool Learned { get; set; } = false;
    public string Description { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Flashcard(string name, string learningName, Languages language, Languages learningLanguage, string description)
    {
        this.Name = name;
        this.LearningName = learningName;
        this.Language = language;
        this.LearningLanguage = learningLanguage;
        this.Description = description;
    }

    public override string ToString()
    {
        var result = string.Format("Nazwa: {0}, nazwa do nauki: {1},{2}twój język: {3}, język którego się uczysz: {4},{5}priorytet: {6}, ostatnia odpowiedź: {7},{8}nauczona: {9}, komentarz: {10},{11}opis: {12}", 
            Name, 
            LearningName, 
            Environment.NewLine, 
            Language, 
            LearningLanguage,
            Environment.NewLine,
            Priority,
            LastAnswer,
            Environment.NewLine,
            Learned,
            Comment,
            Environment.NewLine,
            Description);

        return result;
    }
}

public enum Languages
{
    English = 0,
    German = 1,
    Polish = 2
}

public enum Priorities
{
    Basic = 0,
    Normal = 1,
    Important = 2,
    VeryImportant = 3
}
