public class Location
{
    // all the fields for locations
    public int ID;
    public string Name;
    public string Description;
    public Item ItemRequiredToEnter;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
    public Location LocationToNorth;
    public Location LocationToEast;
    public Location LocationToSouth;
    public Location LocationToWest;

    // constructor with the parameters and assigning them correctly
    public Location(int id, string name, string description, Item itemRequired = null, Quest questready = null, Monster monsterHere = null)
    {
        ID = id;
        Name = name;
        Description = description;
        ItemRequiredToEnter = itemRequired;
        questready = questready;
        MonsterLivingHere = monsterHere;
    }

    // Where the player currently is
    public Location CurrentLocation;

    // Attempt to move in a given direction
    public string Move(string direction)
    {
        // you can use switch to shorten and make the code clearer and more understandable.
        // switch tries to match the condition
        Location nextLocation = direction.ToLower() switch
        {
            "north" => CurrentLocation.North,
            "east" => CurrentLocation.East,
            "south" => CurrentLocation.South,
            "west" => CurrentLocation.West,
            _ => null
        };

        if (newLocation == null)
        {
            return "You cannot go that way! Choose another way";
        }

        CurrentLocation = newLocation;
        return "You moved to: " + CurrentLocation.Name + "\n" + ShowAvailableMoves();
    }

    // Show directions the player can travel from current location
    public string ShowAvailableMoves()
    {
        string result = "Possible moves:\n";

        if (CurrentLocation.LocationToNorth != null) result += "north → " + CurrentLocation.LocationToNorth.Name + "\n";
        if (CurrentLocation.LocationToEast != null) result += "east → " + CurrentLocation.LocationToEast.Name + "\n";
        if (CurrentLocation.LocationToSouth != null) result += "south → " + CurrentLocation.LocationToSouth.Name + "\n";
        if (CurrentLocation.LocationToWest != null) result += "west → " + CurrentLocation.LocationToWest.Name + "\n";

        // Remove any trailing whitespace or line breaks from the end of the string.
        return result.TrimEnd();
    }
}
