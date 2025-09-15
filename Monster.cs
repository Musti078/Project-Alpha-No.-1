public class Monster
{
    public int CurrentHitPoints;
    public int ID;
    public int MaximumDamage;
    public int MaximumHitPoints;
    public string Name;

    private static Random rng = new Random();

    //new Monster(MONSTER_ID_RAT, "rat", 1, 3, 3);


    public Monster(int id, string name, int currenthitpoints,  int maximumdamage, int maximumhitpoints)
    {
        ID = id;
        Name = name;
        CurrentHitPoints = currenthitpoints;
        MaximumDamage = maximumdamage;
        MaximumHitPoints = maximumhitpoints;
    }

    public int attack()
    {
        // Roll for outcome
        int roll = rng.Next(1, 101);

        if (roll <= 10) // 10% chance to miss
        {
            Console.WriteLine($"{Name} missed the attack!");
            return 0;
        }

        // Base damage (1 to MaximumDamage)
        double damage = rng.Next(1, MaximumDamage + 1);

        if (roll > 90) // 10% chance to crit
        {
            damage *= 1.5;
            Console.WriteLine($"{Name} landed a CRITICAL HIT for {damage} damage!");
        }
        else
        {
            Console.WriteLine($"{Name} dealt {damage} damage.");
        }

        return (int)damage;
    }

    public string DropLoot()
    {
        Console.WriteLine($"{Name} dropped a Healing Potion!");
        return "Heal Potion";
    }


      public bool IsDead => CurrentHitPoints <= 0;
}

