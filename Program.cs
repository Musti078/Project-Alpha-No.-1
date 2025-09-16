public class Program
{

    public static void Main()
    {

        World.PopulateLocations();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateWeapons();


        var quests = World.Quests;
        Console.WriteLine($"there are {quests.Count} quests");


        Player player = new Player(30, 30);
        Location currentlocation = World.LocationByID(World.LOCATION_ID_HOME);

        // asking the user his/her name
        Console.WriteLine("Enter your name, warrior");
        string userName = Console.ReadLine() ?? "";


        Location location = World.Locations[0];
        location.CurrentLocation = location;
        Console.WriteLine($"Current location is {location.Name}");



        //hier stoppen omdat speler bewegen error geeft.
        //Environment.Exit(0);
        string usermovement = "";
        while (usermovement.ToLower() != "exit")
        {
            Console.WriteLine($"\n You are at {currentlocation.Name}");
            Console.WriteLine(currentlocation.Description);

            Console.WriteLine("Directions you can move to");
            if (currentlocation.LocationToNorth != null) Console.WriteLine("- North");
            if (currentlocation.LocationToEast != null) Console.WriteLine("- East");
            if (currentlocation.LocationToSouth != null) Console.WriteLine("- South");
            if (currentlocation.LocationToWest != null) Console.WriteLine("- West");

            Console.WriteLine("\n Where would you like to go? (to stop type 'Exit')");
            usermovement = Console.ReadLine().Trim().ToLower() ?? "";

            Location nextLocation = usermovement switch
            {
                "north" => currentlocation.LocationToNorth,
                "east" => currentlocation.LocationToEast,
                "south" => currentlocation.LocationToSouth,
                "west" => currentlocation.LocationToWest,
                _ => null
            };

            if (nextLocation == null)
            {
                Console.WriteLine("You cannot go that way choose another direction");
            }
            else
            {
                currentlocation = nextLocation;
                Console.WriteLine($"You moved to: {currentlocation.Name}");


                //om de quest te testen zet ik de Current Location op een quest.
                var quest = currentlocation.QuestAvailableHere;

                if (quest is not null)
                {
                    Console.WriteLine("Do you want to start the quest or not? Y/N");
                    string choice = Console.ReadLine().ToUpper();

                    if (choice == "Y")
                    {
                        quest.StartQuest();

                        int monstersDefeated = 0;
                        Monster questMonster = null;

                        // decide which monster belongs to this quest
                        if (quest.ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN)
                            questMonster = World.MonsterByID(World.MONSTER_ID_RAT);
                        else if (quest.ID == World.QUEST_ID_CLEAR_FARMERS_FIELD)
                            questMonster = World.MonsterByID(World.MONSTER_ID_SNAKE);
                        else if (quest.ID == World.QUEST_ID_COLLECT_SPIDER_SILK)
                            questMonster = World.MonsterByID(World.MONSTER_ID_GIANT_SPIDER);

                        // fight 3 times
                        while (monstersDefeated < 3)
                        {
                            string result = Battle.Start(player, questMonster);

                            if (result == "Victory")
                            {
                                monstersDefeated++;
                                player.PotionAmount++;
                                Console.WriteLine("You gained a health potion");
                                Console.WriteLine($"{questMonster.Name}s defeated: {monstersDefeated}/3");

                                // Reset monster
                                questMonster.CurrentHitPoints = questMonster.MaximumHitPoints;
                                questMonster.IsDead = false;
                            }
                            else if (result == "Fled")
                            {
                                Console.WriteLine("You fled from the battle!");
                                break;
                            }
                            else if (result == "Defeat")
                            {
                                Console.WriteLine("Game Over!");
                                Environment.Exit(0);
                            }
                        }

                        if (monstersDefeated == 3)
                        {
                            // Grant rewards and auto-equip weapon if stronger
                            WeaponSystem.GrantQuestRewards(
                                quest.Name,
                                player.inventory,
                                player.questCompleted
                            );

                            WeaponSystem.ShowEquippedWeapon();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Then please proceed to another location");
                    }
                }

                }
            }
        }

        // if (player.PlayerHasWon())
            // {
            //     /*
            //     if (WinGame)
            //     {
            //         Victory = player.DisplayVictory();
            //     }
            //     return Victory;
            //     */
            // }



}

