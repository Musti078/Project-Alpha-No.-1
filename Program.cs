public class Program
{
    public static void Main()
    {

        // the objects for the classes that we can use
        Location locations = new Location(locations, username, _);
        Player player = new Player(100, 100);
        Weapon weapon = new Weapon(userName, 5);
        Monster Rat = new Monster(100, rat, 6, 20, Splinter);
        Monster Snake = new Monster(100, snake, 10, 50, Snakey);
        Monster GiantSpider = new Monster(100, giantSpider, 15, 100, Spidey);
        Quest quests = new Quest();

        // asking the user his/her name
        Console.WriteLine("Enter your name, warrior");
        string userName = Console.ReadLine() ?? "";

        Console.WriteLine(Locations[0]);

        string usermovement = "";

        while (usermovement.ToLower() != "exit")
        {
            locations.ShowAvailableMoves();
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("'exit' to quit");
            usermovement = Console.ReadLine() ?? "";

            locations.Move(usermovement);
        }

        
        
        if (player.PlayerHasWon())
        {
            if (WinGame)
            {
                Victory = player.DisplayVictory();
            }
            return Victory;
        }



    }


}