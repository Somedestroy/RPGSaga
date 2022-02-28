namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class ArgumentsProcessor
    {
        public (IGameConfig, bool) SelectConfig(string[] args)
        {
            List<string> arguments = args.ToList();

            if (!arguments.Any())
            {
                return (new KeyboardConfig(), false);
            }

            if (arguments.Contains("-i") && arguments.Contains("-s"))
            {
                FileService.FileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                FileService.FileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return (new FileConfig(), true);
            }

            if (arguments.Contains("-k") && arguments.Contains("-s"))
            {
                int numberOfPlayers = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                FileService.FileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return (new ArgsConfig(numberOfPlayers), true);
            }

            if (arguments.Contains("-k"))
            {
                int numberOfHeroes = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                return (new ArgsConfig(numberOfHeroes), false);
            }

            if (arguments.Contains("-i"))
            {
                FileService.FileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                return (new FileConfig(), false);
            }

            if (arguments.Contains("-s"))
            {
                FileService.FileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return (new KeyboardConfig(), true);
            }
            else
            {
                throw new ArgumentException("Argument is wrong");
            }
        }
    }
}
