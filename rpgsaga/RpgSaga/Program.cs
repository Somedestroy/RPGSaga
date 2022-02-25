namespace CourseApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Configuration;
    using RPGSaga.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> arguments = args.ToList();

            if (args.Contains("-k"))
            {
                int numberOfHeroes = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                Game.Run(new ArgsConfig(numberOfHeroes));
            }
            else
            {
                Game.Run(new KeyboardConfig());
            }
        }
    }
}
