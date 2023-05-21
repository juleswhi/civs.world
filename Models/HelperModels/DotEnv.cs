using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.HelperModels
{
    public static class DotEnv
    {
        public static void SetEnvironmentVariables()
        {
            DotNetEnv.Env.Load();
            var message = Environment.GetEnvironmentVariable("Hello");
            System.Console.WriteLine(message);
        }   
    }
}