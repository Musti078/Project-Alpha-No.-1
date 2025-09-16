public class Location
{
    // all the fields for locations
    public int ID;
    public string Name;
    public string Description;
    public bool ItemRequiredToEnter;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
    public Location LocationToNorth;
    public Location LocationToEast;
    public Location LocationToSouth;
    public Location LocationToWest;

    // constructor with the parameters and assigning them correctly
    public Location(int id, string name, string description, bool itemRequired, Quest questready = null, Monster monsterHere = null)
    {
        ID = id;
        Name = name;
        Description = description;
        ItemRequiredToEnter = itemRequired;
        questready = questready;
        MonsterLivingHere = monsterHere;
        /*
        List<Location> North = new List<Location>
        { townsquare.LocationToNorth, alchemistHut.LocationToNorth };
        List<Location> East = new List<Location>
        { townSquare.LocationToEast, farmhouse.LocationToEast, farmersField.LocationToEast, guardPost.LocationToEast, bridge.LocationToEast };
        List<Location> South = new List<Location>
        { townSquare.LocationToSouth, alchemistHut.LocationToSouth, alchemistsGarden.LocationToSouth, bridge.LocationToSouth };
        List<Location> West = new List<Location>
        { townSquare.LocationToWest, farmhouse.LocationToWest, guardPost.LocationToWest, bridge.LocationToWest, spiderField.LocationToWest };
        */
    }

    // Where the player currently is
    public Location CurrentLocation;

    // Attempt to move in a given direction
    // public string Move(string direction)
    // {
    //     // you can use switch to shorten and make the code clearer and more understandable.
    //     // switch tries to match the condition
    //     Location nextLocation = direction.ToLower() switch
    //     {
    //         "north" => LocationToNorth,
    //         "east" => LocationToEast,
    //         "south" => LocationToSouth,
    //         "west" => LocationToWest,
    //         _ => null
    //     };


    // //                    [AlchemistsGarden]
    // //                            ↑
    // //                      [AlchemistHut]
    // //                            ↑
    // //     Farmersfield <-> [TownSquare] ←→ [GuardPost] ←→ [Bridge] ←→ [SpiderField]
    // //                            ↑
    // //                          [Home]

    //     bool goNorth = CurrentLocation == LocationToNorth;
    //     bool goWest = CurrentLocation == LocationToWest;
    //     bool goEast = CurrentLocation == LocationToEast;
    //     bool goSouth = CurrentLocation == LocationToSouth;
    //     string VerticalLine = "|";
    //     string HorizontalLine = "──";

    //     if (goNorth)
    //     {
    //         Console.WriteLine("N");
    //     }



    //     if (nextLocation == null)
    //     {
    //         return "You cannot go that way! Choose another way";
    //     }

    //     CurrentLocation = nextLocation;
    //     return "You moved to: " + CurrentLocation.Name + "\n" + ShowAvailableMoves();
    // }

    // // Show directions the player can travel from current location
    // public string ShowAvailableMoves()
    // {
    //     string result = "Possible moves:\n";

    //     if (CurrentLocation.LocationToNorth != null) result += "north → " + CurrentLocation.LocationToNorth.Name + "\n";
    //     if (CurrentLocation.LocationToEast != null) result += "east → " + CurrentLocation.LocationToEast.Name + "\n";
    //     if (CurrentLocation.LocationToSouth != null) result += "south → " + CurrentLocation.LocationToSouth.Name + "\n";
    //     if (CurrentLocation.LocationToWest != null) result += "west → " + CurrentLocation.LocationToWest.Name + "\n";

    //     // Remove any trailing whitespace or line breaks from the end of the string.
    //     return result.TrimEnd();
    // }
}
