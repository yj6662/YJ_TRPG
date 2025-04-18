using System;
using System.Diagnostics;


public class Item
{
    public string Name;
    public string Type;
    public int Atk;
    public int Def;
    public string Description;
    public int Price;
    public bool IsEquipped;
    public bool IsOccupied;

    public Item(string name, string type, int atk, int def, string description, int price, bool isEquipped = false, bool isOccupied = false)
    {
        Name = name;
        Type = type;
        Atk = atk;
        Def = def;
        Description = description;
        Price = price;
        IsEquipped = isEquipped;
        IsOccupied = isOccupied;
    }
    public static Item TraineeArmor = new Item("수련자 갑옷", "Armor", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000);
    public static Item IronArmor = new Item("무쇠갑옷", "Armor", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000);
    public static Item SpartanArmor = new Item("스파르타의 갑옷", "Armor", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500);
    public static Item OldSword = new Item("낡은 검", "Weapon", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 600);
    public static Item BronzeAxe = new Item("청동 도끼", "Weapon", 5, 0, "어디선가 사용됐던거 같은 도끼입니다.", 1500);
    public static Item SpartanSpear = new Item("스파르타의 창", "Weapon", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000);
    public static Item SpecialItem = new Item("특별한 아이템", "Special", 15, 15, "특별한 아이템입니다.", 150);

    public static List<Item> AllItems = new List<Item>
{
    TraineeArmor,
    IronArmor,
    SpartanArmor,
    OldSword,
    BronzeAxe,
    SpartanSpear,
    SpecialItem
};

}

