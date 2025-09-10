using System;
public class Quest
{
    //As a player I want to start a quest so I can finish it (in order to complete the game)
    //When the player enters a location with a quest, ask the user if he wants to start the quest or not - today
    //If the player does not want to start the quest, then the user can choose to go to another location instead of the quest location -morgen
    //If the player starts the quest then the player gets a message that the quest has started with the objective -morgen
    //The player gets to see what the quest is about and what rewards are for the quest - vrijdag

    /// <summary>description of the quest, which is displayed when the quest start</summary>
    public string Description;

    /// <summary>unique id of quest</summary>
    public int Id;

    /// <summary>name of the quest</summary>
    public string Name;

    /// <summary>create a new quest</summary>
    /// <param name="id">unique id of quest</param>
    /// <param name="name">name of the quest</param>
    /// <param name="description">description of the quest, which is displayed when the quest start</param>
    public Quest(int id, string name, string description = "")
    {
        this.Description = description;
        this.Id = id;
        this.Name = name;
    }

    public void StartQuest()
    {
        Console.WriteLine("Do you want to start the quest or not? Y/N");
        string choice = Console.ReadLine().ToUpper();
        if (choice == "Y")
        {

            //maak quest actief
        }
        if (choice == "N")
        {
            //
        }
    }
}














