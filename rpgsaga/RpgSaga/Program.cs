namespace CourseApp
{
    using RpgSaga.Configuration;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            IInputConfig gameConfig = null;
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor();
            var save = argumentsProcessor.GetConfig(args, ref gameConfig);
            Game.Run(gameConfig, save);
        }
    }
}
