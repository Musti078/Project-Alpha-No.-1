using System;
using System.Collections.Generic;

// weapon class 
public class Weapon
{
    public string Name { get; }
    public int Damage { get; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}
// this is the class for items
public static class ItemCatalog
{
    public const string HealPotion = "Heal Potion";
    public const string GoldenSpider = "Golden Spider";
}

// the weapon system class
public static class WeaponSystem
{
    ///  Quest from given case     NOTE: The const keyword>>
    /// You use the const keyword to declare a constant field or a local constant. 
    /// Constant fields and locals aren't variables and can't be modified. 
    /// Constants can be numbers, Boolean values, strings, or a null reference.

    public const string QuestFarmer = "Clear the Farmer's Field";
    public const string QuestAlchemist = "Clear the Alchemist's Garden";
    public const string QuestSpiders = "Collect the Spider's Silk";

    // Current equipped weapon ( WE START WITH RUSTY SWORD)
    public static string EquippedWeaponName { get; private set; } = "Rusty Sword";
    public static int EquippedWeaponDamage { get; private set; } = 3;

    // show rewards before starting a quest
    public static void PreviewQuestRewards(string questName)
    {
        var (weapon, potions) = GetReward(questName);
        if (weapon is null)
        {
            Console.WriteLine($"No reward for quest: {questName}");
            return;
        }

        Console.WriteLine($"Quest: {questName}");
        Console.WriteLine($"Rewards:");
        Console.WriteLine($" - Weapon: {weapon.Name} (DMG {weapon.Damage})");
        Console.WriteLine($" - Heal Potion x{potions}");
        Console.WriteLine();
    }

    // Give rewards when quest is completed
    public static void GrantQuestRewards(
        string questName,
        List<string> playerInventory,
        List<string> completedQuests)
    {
        if (completedQuests.Contains(questName))
        {
            Console.WriteLine($"Quest: '{questName}' already completed.");
            return;
        }

        var (weapon, potions, items) = GetReward(questName);
        if (weapon is null)
        {
            Console.WriteLine($"Quest '{questName}' complete! (No weapon reward defined).");
            completedQuests.Add(questName);
            return;
        }

        Console.WriteLine($"Quest '{questName}' complete!");

        // Heal potions or potion
        for (int i = 0; i < potions; i++)
            playerInventory.Add("Heal Potion");
        Console.WriteLine($"{ItemCatalog.HealPotion} x{potions} added to inventory.");

        // weapon to inventory
        playerInventory.Add(weapon.Name);
        Console.WriteLine($"{weapon.Name} added to inventory.");

        foreach (var item in items)
        {
            playerInventory.Add(item);
            Console.WriteLine($"{item} added to intventory");
        }

        // auto-equip if better than current
            if (weapon.Damage > EquippedWeaponDamage)
            {
                string prevName = EquippedWeaponName;
                int prevDmg = EquippedWeaponDamage;

                EquippedWeaponName = weapon.Name;
                EquippedWeaponDamage = weapon.Damage;

                if (string.IsNullOrEmpty(prevName))
                    Console.WriteLine($"{weapon.Name} equipped.");
                else
                    Console.WriteLine($"{weapon.Name} equipped (upgraded from {prevName} {prevDmg} → {weapon.Damage}).");
            }
            else
            {
                Console.WriteLine($"{weapon.Name} not an upgrade.");
            }

        completedQuests.Add(questName);
    }

    // REWARD TABLE
    private static (Weapon? weapon, int potions) GetReward(string questName)
    {
        if (string.Equals(questName, QuestFarmer, StringComparison.OrdinalIgnoreCase))
            return (new Weapon("Sturdy Sword", 6), 1);

        if (string.Equals(questName, QuestAlchemist, StringComparison.OrdinalIgnoreCase))
            return (new Weapon("Steel Sword", 8), 1);

        if (string.Equals(questName, QuestSpiders, StringComparison.OrdinalIgnoreCase))
            return (new Weapon("Spider King Slayer", 15), 1, new List<string> {ItemCatalog.GoldenSpider});

        return (null, 0, List<string>()); // no reward
    }

    // Display current weapon
    public static void ShowEquippedWeapon()
    {
        Console.WriteLine($"Equipped Weapon: {EquippedWeaponName} (DMG {EquippedWeaponDamage})");
    }
}