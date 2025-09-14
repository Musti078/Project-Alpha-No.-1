public class Player
{
    public List<string> QuestCompleted { get; set; } = new List<string>();
    public string location { get; set; }
    public List<string> inventory { get; set; } = new List<string>();
    public int CurrentHitPoints;
    public int MaximumHitPoints;

    private static Random rng = new Random();

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

    public bool PlayerHasWon()
    {
        bool DoneThreeQuest = QuestCompleted.Count >= 3;
        bool AtCastle = location == "Castle";
        bool hasGoldenSpider = inventory.Contains("Golden Spider");

        bool WinGame = DoneThreeQuest && AtCastle && hasGoldenSpider;

        if (WinGame)
        {
            DisplayVictory();
        }
        return DisplayVictory;
    }

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

