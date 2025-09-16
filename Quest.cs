public class Quest
{
    
    /// <summary>
    /// unique id of quest
    /// </summary>
    public int ID;

    /// <summary>
    /// name of the quest
    /// </summary>
    public string Name;

    /// <summary>
    /// description of the quest, which is displayed when the quest start
    /// </summary>
    public string Description;

    /// <summary>
    /// List with monsters that need to be defeated
    /// </summary>
    public List<Monster> Monsters = [];


    /// <summary>create a new quest</summary>
    /// <param name="id">unique id of quest</param>
    /// <param name="name">name of the quest</param>
    /// <param name="description">description of the quest, which is displayed when the quest start</param>
    public Quest(int id, string name, string description = "")
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
    }

    //World.Weapons;
    //World.Monsters;
    //World.Quest;
    //World.Locations;
    //World.RandomGenerator;


    /// <summary>
    /// usage: Location.QuestAvailableHere.StartQuest()
    /// </summary>
    public void StartQuest()
    {


        //When the player enters a location with a quest, ask the user if he wants to start the quest or not - af vandaag
        //hoe weten we of er een quest is op een locatie

        //Id = QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
        //Name = "Clear the alchemist's garden",
        //Description = "Kill rats in the alchemist's garden ");



        WeaponSystem.PreviewQuestRewards(Name); //todo: beter met ID ophalen?
        Console.WriteLine($"The quest has started: {this.Name}");
        Console.WriteLine($"Your objective is to: {this.Description}");


    }
}
/*
    /// <summary>Returns true if Quest is completed</summary>
    /// <returns>true if Quest is completed</returns>
    public bool QuestCompleted()
    {
        foreach (Monster monster in World.Monsters)
        {
            if (!monster.IsDead)
            {
                return false;
            }
        }
        Console.WriteLine("The quest completed");
        return true;
    }
}
*/
