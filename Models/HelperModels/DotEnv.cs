namespace Models.HelperModels;
    public static class DotEnv
    {
        public static void SetEnvironmentVariables()
        {
            DotNetEnv.Env.Load();
            var message = Environment.GetEnvironmentVariable("Hello");
            System.Console.WriteLine(message);
        }   
    }