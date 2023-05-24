namespace SharedClasses.Helpers;
public struct Name
{
    public Name(string FirstName, string Surname, params string[]? Middlenames)
    {
        this.FirstName = FirstName;
        this.Surname = Surname;
    }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public List<string>? MiddleNames { get; set; }

}