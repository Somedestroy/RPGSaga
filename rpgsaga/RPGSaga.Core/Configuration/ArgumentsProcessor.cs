namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;

    public class ArgumentsProcessor
    {
        public (IInputConfig, bool) GetConfig(string[] args)
        {
            List<string> arguments = args.ToList();

            if (!arguments.Any())
            {
                return (new KeyboardConfig(), false);
            }

            if (arguments.Contains("-i") && arguments.Contains("-s"))
            {
                string fileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                string fileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return (new FileConfig(fileNameToGet, fileNameToSave), true);
            }

            if (arguments.Contains("-k") && arguments.Contains("-s"))
            {
                int numberOfPlayers = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                string fileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return (new ArgsConfig(numberOfPlayers, fileNameToSave), true);
            }

            if (arguments.Contains("-k"))
            {
                int numberOfHeroes = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                return (new ArgsConfig(numberOfHeroes), false);
            }

            if (arguments.Contains("-i"))
            {
                string fileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                return (new FileConfig(fileNameToGet), false);
            }

            if (arguments.Contains("-s"))
            {
                string fileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return (new KeyboardConfig(fileNameToSave), true);
            }
            else
            {
                throw new ArgumentException("Argument is wrong");
            }
        }
    }
}
