namespace FiszkiUI.Models;

public class CardModel
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
    public CardModel(string name, string learningName, Languages language, Languages learningLanguage, string description)
    {
        this.Name = name;
        this.LearningName = learningName;
        this.Language = language;
        this.LearningLanguage = learningLanguage;
        this.Description = description;
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
