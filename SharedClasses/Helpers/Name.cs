namespace SharedClasses.Helpers;
public class Name
{
    public Name(string fname, string sname)
    {
        FirstName = fname;
        Surname = sname;
    }
    public string? FirstName { get; set; }
    public string? Surname { get; set; }

}