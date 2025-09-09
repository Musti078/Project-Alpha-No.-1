public static class Player
{
    public List<string> QuestCompleted { get; set; } = new List<string>();
    public string location { get; set; }
    public List<string> inventory { get; set; } = new List<string>();

    public bool PlayerHasWon()
    {
        bool DoneThreeQuest = QuestCompleted.Count >= 3;
        bool AtCastle = location == "Castle";
        bool hasGoldenSpider = inventory.Contains("Golden Spider");

        return DoneThreeQuest && AtCastle && hasGoldenSpider;
    }

}