using System;
using System.Collections.Generic;

// weapon class 
public class Weapon
{
    public string Name;
    public int Damage;

    public string GetName() => Name;
    public int GetDamage() => Damage;

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
    public static string EquippedWeaponName = "Rusty Sword";
    public static int EquippedWeaponDamage = 3;

    public static string GetEquippedWeaponName() => EquippedWeaponName;
    public static int GetEquippedWeaponDamage() => EquippedWeaponDamage;

    // show rewards before starting a quest
    public static void PreviewQuestRewards(string questName)
    {
        var (weapon, potions, _) = GetReward(questName);
        if (weapon is null)
        {
            Console.WriteLine($"No reward for quest: {questName}");
            return;
        }

        Console.WriteLine($"Quest: {questName}");
        Console.WriteLine($"Rewards:");
        Console.WriteLine($" - Weapon: {(weapon.GetName())} (DMG {weapon.GetDamage()})");
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
        playerInventory.Add(weapon.GetName());
        Console.WriteLine($"{weapon.GetName()} added to inventory.");

        foreach (var item in items)
        {
            playerInventory.Add(item);
            Console.WriteLine($"{item} added to inventory");
        }

        // auto-equip if better than current
            if (weapon.GetDamage() > EquippedWeaponDamage)
            {
                string prevName = EquippedWeaponName;
                int prevDmg = EquippedWeaponDamage;

                EquippedWeaponName = weapon.GetName();
                EquippedWeaponDamage = weapon.GetDamage();

                if (string.IsNullOrEmpty(prevName))
                    Console.WriteLine($"{weapon.GetName()} equipped.");
                else
                    Console.WriteLine($"{weapon.GetName()} equipped (upgraded from {prevName} {prevDmg} → {weapon.GetDamage()}).");
            }
            else
            {
                Console.WriteLine($"{weapon.GetName()} not an upgrade.");
            }

        completedQuests.Add(questName);
    }

    // REWARD TABLE
    private static (Weapon? weapon, int potions, List<string> items) GetReward(string questName)
    {
        if (string.Equals(questName, QuestFarmer, StringComparison.OrdinalIgnoreCase))
            return (new Weapon("Sturdy Sword", 6), 1);

        if (string.Equals(questName, QuestAlchemist, StringComparison.OrdinalIgnoreCase))
            return (new Weapon("Steel Sword", 8), 1);

        if (string.Equals(questName, QuestSpiders, StringComparison.OrdinalIgnoreCase))
            return (new Weapon("Spider King Slayer", 15), 1, new List<string> {ItemCatalog.GoldenSpider});

        return (null, 0, new List<string>()); // no reward
    }

    // Display current weapon
    public static void ShowEquippedWeapon()
    {
        Console.WriteLine($"Equipped Weapon: {EquippedWeaponName} (DMG {EquippedWeaponDamage})");
    }
}