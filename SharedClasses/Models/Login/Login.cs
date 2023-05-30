namespace SharedClasses.Models.Login;

public class Login
{
    public static bool LoginUser(string username, string password)
    {

        var usernameFilter = Builders<Player>.Filter.Eq(x => x.Username, username);

        var user = DataBaseClient.PlayerCollection.Find(usernameFilter).FirstOrDefault();

        string hashedPassword = password.Hash(ParseExtensions.salt);


        if(user.Password == hashedPassword)
            return true;

        return false;

    }


    public static void CreateLogin()
    {

    }
}