namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;

    public class ArgumentsProcessor
    {
        public bool GetConfig(string[] args, ref IInputConfig gameConfig)
        {
            List<string> arguments = args.ToList();

            if (!arguments.Any())
            {
                gameConfig = new KeyboardConfig();
                return false;
            }

            if (arguments.Contains("-i") && arguments.Contains("-s"))
            {
                string fileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                string fileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                gameConfig = new FileConfig(fileNameToGet, fileNameToSave);
                return true;
            }

            if (arguments.Contains("-k") && arguments.Contains("-s"))
            {
                int numberOfPlayers = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                string fileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                gameConfig = new ArgsConfig(numberOfPlayers, fileNameToSave);
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
                string fileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                gameConfig = new FileConfig(fileNameToGet);
                return false;
            }

            if (arguments.Contains("-s"))
            {
                string fileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                gameConfig = new KeyboardConfig(fileNameToSave);
                return true;
            }
            else
            {
                throw new ArgumentException("Argument is wrong");
            }
        }
    }
}
