public class Monster
{
    public int CurrentHitPoints;
    public int ID;
    public int MaximumDamage;
    public int MaximumHitPoints;
    public string Name;

    public bool IsDead;

    private static Random rng = new Random();

    public Monster(int id, string name, int maximumDamage, int maximumHitPoints, int currentHitPoints)
    {
        ID = id;
        Name = name;
        MaximumDamage = maximumDamage;
        MaximumHitPoints = maximumHitPoints;
        CurrentHitPoints = currentHitPoints;
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
        int damage = rng.Next(1, MaximumDamage + 1);

        if (roll > 90) // 10% chance to crit
        {
            damage = (int)(damage * 1.5);
            Console.WriteLine($"{Name} landed a CRITICAL HIT for {damage} damage!");
        }
        else
        {
            Console.WriteLine($"{Name} dealt {damage} damage.");
        }

        return damage;
    }

    public void DropLoot()
    {
        Console.WriteLine($"{Name} dropped a Healing Potion!");
        
    }

}

