public class Program
{
    public static void Main()
    {

        World.PopulateLocations();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateWeapons();

        var quests = World.Quests;
        Console.WriteLine($"there are {quests.Count} quests");


        Player player = new Player(0, 10);
        Location currentlocation = World.LocationByID(World.LOCATION_ID_HOME);

        // asking the user his/her name
        Console.WriteLine("Enter your name, warrior");
        string userName = Console.ReadLine() ?? "";


        Location location = World.Locations[0];
        location.CurrentLocation = location;
        Console.WriteLine($"Current location is {location.Name}");


        // a string for movement from user
        /*
            its done in a while loop to keep asking the user wants to do if the user types in exit it will break the loop and stop the game
            first it shows your location that you are at and shows the description of that location
            below that it will show the location you can move to for example;
            if you are at home it will show home the only direction you can go to is north so it only shows north
            after that it will ask for your input to move around. 
            it checks your input with a switch statement to get you to move to the right direction
            after checking that it will use a if statement to check if your next location is null if so you cannot move there and have to input again
            if not null it will move you to that directions
            and shows that you moved to that location
        */
        string usermovement = "";
        while (usermovement.ToLower() != "exit")
        {
            Console.WriteLine($"\n You are at {currentlocation.Name}");
            Console.WriteLine(currentlocation.Description);

            Console.WriteLine("Directions you can move to");
            if (currentlocation.LocationToNorth != null) Console.WriteLine("- North");
            if (currentlocation.LocationToEast != null) Console.WriteLine("- East");
            if (currentlocation.LocationToSouth != null) Console.WriteLine("- South");
            if (currentlocation.LocationToWest != null) Console.WriteLine("- West");

            Console.WriteLine("\n Where would you like to go? (to stop type 'Exit')");
            usermovement = Console.ReadLine().Trim().ToLower() ?? "";

            Location nextLocation = usermovement switch
            {
                "north" => currentlocation.LocationToNorth,
                "east" => currentlocation.LocationToEast,
                "south" => currentlocation.LocationToSouth,
                "west" => currentlocation.LocationToEast,
                _ => null
            };

            if (nextLocation == null)
            {
                Console.WriteLine("You cannot go that way choose another direction");
            }
            else
            {
                currentlocation = nextLocation;
                Console.WriteLine($"You moved to: {currentlocation.Name}");

        


                //om de quest te testen zet ik de Current Location op een quest.
                location.CurrentLocation = World.LocationByID(World.LOCATION_ID_FARMHOUSE);
                var quest = location.CurrentLocation.QuestAvailableHere;
                if (quest is not null)
                {
                    quest.StartQuest();
                }
            }


            // if (player.PlayerHasWon())
            // {
            //     /*
            //     if (WinGame)
            //     {
            //         Victory = player.DisplayVictory();
            //     }
            //     return Victory;
            //     */
            // }


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
}
