public class Player
{
    // these are all the fields
    public List<string> questCompleted = new List<string>();
    // gets the quest
    public List<string> GetCompletedQuest()
    {
        return questCompleted;
    }
    // sets a quest value
    public void SetQuest(List<string> quest)
    {
        questCompleted = quest;
    }


    public string Location;

    public string GetLocation()
    {
        return Location;
    }
    public void setLocation(string value)
    {
        Location = value;
    }
    
    public List<string> inventory = new List<string>();
    public List<string> Getinventory()
    {
        return inventory;
    }

    public void Setinventory(List<string> items)
    {
        inventory = items;
    }
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    // a rng generator
    private static Random rng = new Random();

    // constructor with two parameters
    public Player(int currenthitpoints, int maximumhitpoints)
    {
        CurrentHitPoints = currenthitpoints;
        MaximumHitPoints = maximumhitpoints;
    }

    // options in combat

    public int Attack()
    {
        int baseDamage = WeaponSystem.EquippedWeaponDamage;
        int roll = rng.Next(1, 101); // 1–100

        if (roll <= 10) // 10% miss
        {
            Console.WriteLine($"You swing your {WeaponSystem.EquippedWeaponName} but MISS!");
            return 0;
        }

        int damage = baseDamage;

        if (roll > 90) // 10% crit
        {
            damage *= 2;
            Console.WriteLine($"CRITICAL HIT! You strike with {WeaponSystem.EquippedWeaponName} for {damage} damage!");
        }
        else
        {
            Console.WriteLine($"You attack with {WeaponSystem.EquippedWeaponName} for {damage} damage.");
        }

        return damage;
    }

    public bool TryFlee()
    {
        int roll = rng.Next(1, 101);
        if (roll <= 70)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal()
    {
        const int healAmount = 10;

        if (inventory.Contains("Heal Potion"))
        {
            CurrentHitPoints += healAmount;
            if (CurrentHitPoints > MaximumHitPoints)
                CurrentHitPoints = MaximumHitPoints;

            inventory.Remove("Heal Potion");
            Console.WriteLine($"You used a Heal Potion and recovered {healAmount} HP! (Current HP: {CurrentHitPoints}/{MaximumHitPoints})");
        }
        else
        {
            Console.WriteLine("You have no Heal Potions!");
        }
    }

    // this is to check if the player has won the game or not
    // so it first checks if three quests have been done or not
    // then checks if he is back at home
    // and last condition is to check if the players inventory contains the item Golden spider
    // when all conditions match it will display victory if not it wont do anything
    public bool PlayerHasWon()
    {
        bool DoneThreeQuest = QuestCompleted.Count >= 3;
        bool AtHome = location == "home";
        bool hasGoldenSpider = inventory.Contains("Golden Spider");

        bool WinGame = DoneThreeQuest && AtHome && hasGoldenSpider;

        return WinGame;
    }

    // this is to print the victory when you win it shows your location and items in your inventory
    // it will loop for quest with each quest you have done
    // and it does the same for invetory items both will print out your results
    public void DisplayVictory()
    {
        Console.WriteLine("\nCongratulations! You won!");
        Console.WriteLine($"You are at the {location}");
        Console.WriteLine("\nThe quests you have done:");
        foreach (var quest in QuestCompleted)
        {
            Console.WriteLine($"- {quest}");
        }

        Console.WriteLine("\n Your inventory items:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }
}

