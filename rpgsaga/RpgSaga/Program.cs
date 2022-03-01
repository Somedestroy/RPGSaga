namespace CourseApp
{
    using RpgSaga.Configuration;
    using RPGSaga.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor();
            Game.Run(argumentsProcessor.GetConfig(args));
        }
    }
}
