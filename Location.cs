public class Locations
{
    public int ID;
    public string Name;
    public string Description;
    public bool ItemRequiredToEnter = true;
    public bool QuestAvailableHere = true;
    public bool MonsterLivingHere = true;
    public Location LocationToNorth;
    public Location LocationToEast;
    public location LocationToSouth;
    public location LocationToWest;

    public Location(int id, string name, string description, bool itemRequired, bool questready, bool monsterHere)
    {
        ID = id;
        Name = name;
        Description = Description;
        ItemRequiredToEnter = itemRequired;
        questready = questready;
        MonsterLivingHere = monsterHere;
    }

}