namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class ArgumentsProcessor
    {
        public bool SelectConfig(string[] args, ref IGameConfig gameConfig)
        {
            List<string> arguments = args.ToList();

            if (!arguments.Any())
            {
                gameConfig = new KeyboardConfig();
                return false;
            }

            if (arguments.Contains("-i") && arguments.Contains("-s"))
            {
                FileService.FileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                FileService.FileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                gameConfig = new FileConfig();
                return true;
            }

            if (arguments.Contains("-k") && arguments.Contains("-s"))
            {
                int numberOfPlayers = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                FileService.FileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                gameConfig = new ArgsConfig(numberOfPlayers);
                return true;
            }

            if (arguments.Contains("-k"))
            {
                int numberOfHeroes = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                gameConfig = new ArgsConfig(numberOfHeroes);
                return false;
            }

            if (arguments.Contains("-i"))
            {
                FileService.FileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                gameConfig = new FileConfig();
                return false;
            }

            if (arguments.Contains("-s"))
            {
                FileService.FileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                gameConfig = new KeyboardConfig();
                return true;
            }
            else
            {
                throw new ArgumentException("Argument is wrong");
            }
        }
    }
}
