public static class Battle
{
    public static void Start(Player player, Monster monster)
    {
        Console.WriteLine($"A wild {monster.Name} appears!\n");

        while (player.CurrentHitPoints > 0 && !monster.IsDead)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1 - Attack");
            Console.WriteLine("2 - Heal");
            Console.WriteLine("3 - Run");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    int damage = player.Attack();
                    monster.CurrentHitPoints -= damage;
                    if (monster.CurrentHitPoints < 0) monster.CurrentHitPoints = 0;

                    Console.WriteLine($"{monster.Name} HP: {monster.CurrentHitPoints}/{monster.MaximumHitPoints}\n");

                    if (monster.IsDead)
                    {
                        Console.WriteLine($"You defeated {monster.Name}!\n");
                        return;
                    }
                    break;

                case "2":
                    player.Heal();
                    Console.WriteLine($"Player HP: {player.CurrentHitPoints}/{player.MaximumHitPoints}\n");
                    break;

                case "3":
                    if (player.TryFlee())
                    {
                        Console.WriteLine("You successfully fled the battle!\n");
                        return;
                    }
                    Console.WriteLine("You failed to flee!\n");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Enter 1, 2, or 3.\n");
                    continue;
            }

            if (!monster.IsDead)
            {
                int monsterDamage = monster.attack();
                player.CurrentHitPoints -= monsterDamage;
                if (player.CurrentHitPoints < 0) player.CurrentHitPoints = 0;

                Console.WriteLine($"Player HP: {player.CurrentHitPoints}/{player.MaximumHitPoints}\n");

                if (player.CurrentHitPoints <= 0)
                {
                    Console.WriteLine("You have been defeated!\n");
                    return;
                }
            }
        }
    }
}

