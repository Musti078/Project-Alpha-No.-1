public class Program
{
    public static void Main()
    {
        var quests = World.Quests;
        Console.WriteLine($"there are {quests.Count} quests");

        Player player = new Player(0, 10);

        // asking the user his/her name
        Console.WriteLine("Enter your name, warrior");
        string userName = Console.ReadLine() ?? "";

        Location location = World.Locations[0];
        Console.WriteLine($"Current location is {location.Name}");

        //hier stoppen omdat speler bewegen error geeft.
        Environment.Exit(0);

        string usermovement = "";
        while (usermovement.ToLower() != "exit")
        {
            location.ShowAvailableMoves();
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("'exit' to quit");
            usermovement = Console.ReadLine() ?? "";

            location.Move(usermovement);
        }

        if (player.PlayerHasWon())
        {
            /*
            if (WinGame)
            {
                Victory = player.DisplayVictory();
            }
            return Victory;
            */
        }

        /* testen

        // the objects for the classes that we can use
        //Location locations = new Location(locations, username, _);
        Player player = new Player(100, 100);
        Weapon weapon = new Weapon(userName, 5);
        Monster Rat = new Monster(100, rat, 6, 20, Splinter);
        Monster Snake = new Monster(100, snake, 10, 50, Snakey);
        Monster GiantSpider = new Monster(100, giantSpider, 15, 100, Spidey);
        Quest quests = new Quest();

        //the objects for the locations
        Location alchemisthut = World.LocationByID(World.LOCATION_ID_ALCHEMISTS_GARDEN);
        Location farmhouse = World.LocationByID(World.LOCATION_ID_FARMHOUSE);
        Location bridge = World.LocationByID(World.LOCATION_ID_BRIDGE);
        Location home = World.LocationByID(World.LOCATION_ID_ALCHEMISTS_GARDEN);
        Location townsquare = World.LocationByID(World.LOCATION_ID_FARMHOUSE);
        Location alchemistgarden = World.LocationByID(World.LOCATION_ID_BRIDGE);
        Location farmersfield = World.LocationByID(World.LOCATION_ID_ALCHEMISTS_GARDEN);
        Location gueardpost = World.LocationByID(World.LOCATION_ID_FARMHOUSE);
        Location spiderfield = World.LocationByID(World.LOCATION_ID_BRIDGE);

        //quest objects
        Quest firstQuest = World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN);
        Quest secondQuest = World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD);
        Quest thirdQuest = World.QuestByID(World.QUEST_ID_COLLECT_SPIDER_SILK);

        */


    }


}