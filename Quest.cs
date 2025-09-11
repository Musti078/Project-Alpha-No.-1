using System;
public class Quest
{
    //As a player I want to start a quest so I can finish it (in order to complete the game)
    //When the player enters a location with a quest, ask the user if he wants to start the quest or not - af vandaag
    //If the player does not want to start the quest, then the user can choose to go to another location instead of the quest location -af vandaag
    //If the player starts the quest then the player gets a message that the quest has started with the objective -vrijdag
    //The player gets to see what the quest is about and what rewards are for the quest - vrijdag


    /// <summary>
    /// unique id of quest<
    /// /summary>
    public int Id;

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
        this.Id = id;
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


        Console.WriteLine("Do you want to start the quest or not? Y/N");
        string choice = Console.ReadLine().ToUpper();
        if (choice == "Y")
        {
            Console.WriteLine($"The quest has started: {this.Name}");
            Console.WriteLine($"Your objective is to: {this.Description}");
            Console.WriteLine($"If you succeed I will reward you with ???");
        }
        if (choice == "N")
        {
            Console.WriteLine("Then lease proceed to another location");
        }

    }

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















