namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class NamesGenerator
    {
        private readonly List<string> heroesNames = new List<string>()
        {
            "Itheth Erinahr", "Darrsa Harrington", "Lormorgh Gashvahr",
            "Targrazh Skulash", "Razhrehz Bloodaxe", "Morghrash Roghlor", "Voshceh Lorrogh", "Makann Steinward",
            "Naward Magrenn", "Razhragh Raghgorz", "Erinahr Niendir", "Ahnnah Bluelace", "Ahnnah Bluelace", "Sannstein Goldcrown",
            "Dirmar Silverwalker", "Faggfagg Brownrigg", "Eithpenn Ahnthan", "Ienith Diala", "Eriria Eriria", "Renith Lightheart",
            "Ionnar Rilnah", "Yhneith Rilien", "Makbor Clayden", "Rennren Braveblade", "Vardmar Brownrigg", "Steinrenn Vagforh",
            "Ricmag Faraforh",
        };

        public string GetHeroName()
        {
            return heroesNames[Game.Rand.Next(0, heroesNames.Count)];
        }
    }
}
