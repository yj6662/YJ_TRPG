public class SaveData
{
    public PlayerData player { get; set; }
    public List<ItemData> Inventory { get; set; }
}

public class PlayerData
{
    public string Name { get; set; }
    public string Job { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }
    public int Gold { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int MaxHp { get; set; }
    public int Hp { get; set; }
}

public class ItemData
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool IsEquipped { get; set; }
    public bool IsOccupied { get; set; }
}