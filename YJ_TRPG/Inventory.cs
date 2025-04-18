using System;
using System.Collections.Generic;

public static class Inventory
{
    public static List<Item> Items = new List<Item>();

    public static void renew()
    {
        Items.Clear();
        foreach (var item in Item.AllItems)
        {
            if (item.IsOccupied)
            {
                Items.Add(item);
            }
        }
    }
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

            Console.WriteLine("[아이템 목록]");
            if (Items.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.\n");
            }
            else
            {
                foreach (var item in Items)
                {
                    string Equip = item.IsEquipped ? "[E]" : "   ";
                    Console.WriteLine($"- {Equip}{item.Name} | + {item.Atk} | + {item.Def} | {item.Description}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                MainScene.Start();
                return;
            }
            else if (input == "1")
                EquipManager();
            else
                Console.WriteLine("\n잘못된 입력입니다. 다시 시도해주세요.");
        }

    }
    private static void EquipManager()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            if (Items.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.\n");
            }
            else
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    var item = Items[i];
                    string Equip = item.IsEquipped ? "[E]" : "   ";
                    Console.WriteLine($"{i + 1}. {Equip}{item.Name} | 공격력 + {item.Atk} | 방어력 + {item.Def} | {item.Description}");
                }
            }
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n장착할 아이템의 번호를 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            if (int.TryParse(input, out int selection))
            {
                int index = selection - 1;
 
                if (index >= 0 && index < Items.Count)
                {
                    Console.Clear();

                    var item = Items[index];
                    if (item.IsEquipped == false)
                    {
                        var oldItem = Items.Find(i => i.IsEquipped && i.Type == item.Type);
                        if (oldItem != null)
                        {
                            oldItem.IsEquipped = false;
                            Console.WriteLine($"{oldItem.Name}의 장착을 해제했습니다.");
                        }
                        item.IsEquipped = true;
                        Console.WriteLine($"{item.Name}을 장착했습니다."); 
                    }
                    else
                    {
                        item.IsEquipped = false;
                        Console.WriteLine($"{item.Name}의 장착을 해제했습니다.");
                    }
                    Console.WriteLine("아무 키나 눌러서 계속.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
            }
        }
    }
}

