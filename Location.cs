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

}