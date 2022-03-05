namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Configuration.Destination;
    using RpgSaga.Interfaces;

    public class ArgumentsProcessor
    {
        public IHeroSource BuildHeroSource(List<string> arguments)
        {
            if (!arguments.Any())
            {
                return new KeyboardSource();
            }

            if (arguments.Contains("-k"))
            {
                int numberOfHeroes = int.Parse(arguments[arguments.FindIndex(b => b == "-k") + 1]);
                return new ArgsHeroSource(numberOfHeroes);
            }

            if (arguments.Contains("-i"))
            {
                string fileNameToGet = arguments[arguments.FindIndex(b => b == "-i") + 1];
                return new FileSource(fileNameToGet);
            }

            if (arguments.Contains("-s"))
            {
                return new KeyboardSource();
            }
            else
            {
                throw new ArgumentException("You used wrong line argument(s)!\n Arguments available to use:\n" +
                    "\"-s filename.json\" - saves the list of players to the filename.ext located on your desktop;\n" +
                    "\"-i filename.json\" - loads list of players from the filename.ext located on your desktop;\n" +
                    "\"-k numberofplayers\" - starts the game with specified number of players;\n\n" +
                    "These line arguments can be mixed, e.g.:\n" +
                    "\"-i inputfile.json -s outputfile.json\"\n" +
                    "\"-k 20 -s outputfile.json\"");
            }
        }

        public IHeroDestination BuildHeroDestination(List<string> arguments)
        {
            if (arguments.Contains("-s"))
            {
                string fileNameToSave = arguments[arguments.FindIndex(b => b == "-s") + 1];
                return new FileDestination(fileNameToSave);
            }
            else
            {
                return new DummyHeroDestination();
            }
        }
    }
}
