namespace SharedClasses.Helpers;
public static class DotEnv
{
    public static void SetEnvironmentVariables()
    {
        DotNetEnv.Env.Load();
    }
}