namespace CourseApp
{
    using RpgSaga.Configuration;
    using RPGSaga.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            ArgumentsProcessor argumentProcessor = new ArgumentsProcessor();
            Game.Run(argumentProcessor.SelectConfig(args));
        }
    }
}
