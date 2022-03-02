namespace CourseApp
{
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Configuration;
    using RPGSaga.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> arguments = args.ToList();
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor();
            var destination = argumentsProcessor.BuildHeroDestination(arguments);
            var source = argumentsProcessor.BuildHeroSource(arguments);
            Game.Run(destination, source);
        }
    }
}
