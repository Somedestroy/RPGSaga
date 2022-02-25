namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class ArgumentsProcessor
    {
        private FileService fileService;

        public ArgumentsProcessor()
        {
            fileService = new FileService();
        }

        public (IGameConfig, bool) SelectConfig(string[] args)
        {
            List<string> arguments = args.ToList();

            if (!arguments.Any())
            {
                return (new KeyboardConfig(), false);
            }
            else if (arguments.Contains("-k"))
            {
                int numberOfHeroes = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                return (new ArgsConfig(numberOfHeroes), false);
            }
            else if (arguments.Contains("-i"))
            {
                fileService.FileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                return (new FileConfig(), false);
            }
            else if (arguments.Contains("-s"))
            {
                fileService.FileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return (new KeyboardConfig(), true);
            }
            else if (arguments.Contains("-i") && arguments.Contains("-s"))
            {
                fileService.FileNameToGet = arguments[arguments.FindIndex(w => w == "-i") + 1];
                fileService.FileNameToSave = arguments[arguments.FindIndex(w => w == "-s") + 1];
                return (new FileConfig(), true);
            }
            else if (arguments.Contains("-k") && arguments.Contains("-s"))
            {
                int numberOfPlayers = int.Parse(arguments[arguments.FindIndex(w => w == "-k") + 1]);
                fileService.FileNameToSave = arguments[arguments.FindIndex(w => w == "-s") + 1];
                return (new ArgsConfig(numberOfPlayers), true);
            }
            else
            {
                throw new ArgumentException("Argument is wrong");
            }
        }
    }
}
