using System;
using System.Numerics;
using System.Runtime.CompilerServices;

public static class Shop
{
    static List<Item> StoreItems = Item.AllItems;
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine($"보유 골드: {Player.Gold}G\n");

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                Console.WriteLine("게임이 저장되었습니다.");
                SaveManager.SaveGame();
                Thread.Sleep(1000);
                Console.Clear();
                break;
            }
            else if (input == "1") Buy();
            else if (input == "2") Sell();
            else
            {
                Console.WriteLine("\n잘못된 입력입니다. 다시 시도해주세요.");
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
    private static void Buy()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("구매할 아이템을 선택해주세요.\n");

            Console.WriteLine("[보유골드]");
            Console.WriteLine(Player.Gold + "G");

            Console.WriteLine("\n[아이템 목록]");
            if (StoreItems.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.\n");
            }
            else
            {
                for (int i = 0; i < StoreItems.Count; i++)
                {
                    if (StoreItems[i].IsOccupied == true)
                    {
                        Console.WriteLine($"- {i + 1}. {StoreItems[i].Name} | + {StoreItems[i].Atk} | + {StoreItems[i].Def} | {StoreItems[i].Description} | (구매완료)");
                    }
                    else
                        Console.WriteLine($"- {i + 1}. {StoreItems[i].Name} | + {StoreItems[i].Atk} | + {StoreItems[i].Def} | {StoreItems[i].Description} | 구매가격 {StoreItems[i].Price}G");
                }
            }
            Console.WriteLine("\n0. 나가기");

            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                break;
            }
            else if (int.TryParse(input, out int selection))
            {
                int index = selection - 1;

                if (index >= 0 && index < StoreItems.Count)
                {
                    Console.Clear();

                    var item = StoreItems[index];
                    if (item.IsOccupied == false && Player.Gold >= item.Price)
                    {
                        Player.Gold -= item.Price;
                        item.IsOccupied = true;
                        Inventory.renew();
                        Console.WriteLine($"{item.Name} 구매 완료!");
                    }
                    else if (item.IsOccupied == false && Player.Gold < item.Price)
                    {
                        Console.WriteLine($"{item.Name}을 구매하기에는 골드가 부족합니다.");
                    }
                    else if (item.IsOccupied == true)
                    {
                        Console.WriteLine("이미 보유 중인 아이템입니다.");
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                        Console.WriteLine("아무 키나 눌러서 계속.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                Console.ReadKey();
            }
        }
    }
    private static void Sell()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("판매할 아이템을 선택해주세요.\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine(Player.Gold + "G");
            Console.WriteLine("\n[아이템 목록]");
            if (Inventory.Items.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.\n");
            }
            else
            {
                for (int i = 0; i < Inventory.Items.Count; i++)
                {
                    Console.WriteLine($"- {i + 1}. {Inventory.Items[i].Name} | + {Inventory.Items[i].Atk} | + {Inventory.Items[i].Def} | {Inventory.Items[i].Description} | 판매가격 {Inventory.Items[i].Price * 0.85f}G");
                }
            }
            Console.WriteLine("\n0. 나가기");


            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                break;
            }
            else if (int.TryParse(input, out int selection))
            {
                int index = selection - 1;

                if (index >= 0 && index < Inventory.Items.Count)
                {
                    Console.Clear();

                    var item = Inventory.Items[index];
                    if (item.IsEquipped == true)
                    {
                        Console.WriteLine("장착 중인 아이템은 판매할 수 없습니다.");
                        Console.WriteLine("아무 키나 눌러서 계속.");
                        Console.ReadKey();
                    }
                    else if (item.IsOccupied == true)
                    {
                        Player.Gold += Convert.ToInt32(item.Price * 0.85f);
                        item.IsOccupied = false;
                        Inventory.renew();
                        Console.WriteLine($"{item.Name} 판매 완료!");
                    }
                    else if (item.IsOccupied == false)
                    {
                        Console.WriteLine($"{item.Name}을(를) 보유하지 않았습니다!");
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                        Console.WriteLine("아무 키나 눌러서 계속.");
                        Console.ReadKey();

                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                Console.ReadKey();
            }
        }
    }
}
