using System;

public static class Player
{
    public static string Name = "Chad";
    public static string Job = "전사";
    public static int Level = 1;
    public static int Hp = 100;
    public static int MaxHp = 100;
    public static float Atk = 10;
    public static float Def = 5;
    public static int Gold = 1500;
    public static int level = 1;
    public static int Exp = 0;

    public static float totalAtk()
    {
        float totalAtk = Atk;
        foreach (var item in Inventory.Items)
        {
            if (item.IsEquipped)
                totalAtk += item.Atk;
        }
        return totalAtk;
    }
    public static float totalDef()
    {
        float totalDef = Def;
        foreach (var item in Inventory.Items)
        {
            if (item.IsEquipped)
                totalDef += item.Def;
        }
        return totalDef;
    }
    public static void Recovery()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine("500 G를 내면 체력을 회복할 수 있습니다."); Console.WriteLine("보유골드 :" + Gold + "G");
            Console.WriteLine("현재 체력 :" + Hp + " / " + MaxHp + "\n");
            Console.WriteLine("1. 휴식하기");
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
            else if (input == "1")
            {
                Console.Clear();
                if (Hp == MaxHp)
                {
                    Console.WriteLine("체력이 가득 차 있습니다.");
                    Console.WriteLine("계속하려면 아무 키나 누르세요.");
                    Console.ReadKey();
                }
                else
                {
                    if (Gold < 500)
                    {
                        Console.WriteLine("골드가 부족합니다.");
                        Console.WriteLine("계속하려면 아무 키나 누르세요.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("500G를 지불하고 체력을 회복합니다.");
                        Gold -= 500;
                        Hp = MaxHp;
                        Console.WriteLine("체력이 회복되었습니다.");
                        Console.WriteLine("계속하려면 아무 키나 누르세요.");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다. 다시 시도해주세요.");
                Console.ReadKey();
            }
        }
    }
    public static void LevelUp()
    {
        int requiredClears = Level; 

        if (Exp >= requiredClears)
        {
            Exp = 0; 
            Level++;

            Atk += 0.5f;
            Def += 1f;

            Console.WriteLine($"레벨이 {Level}로 상승했습니다!");
            Console.WriteLine("공격력 +0.5, 방어력 +1 증가!");
        }
    }
    public static void Die()
    {
        Console.Clear();
        Console.WriteLine("당신은 사망했습니다.");
        Console.WriteLine("게임이 초기화됩니다...");
        Thread.Sleep(1500);

        Reset();
        PlayerSetup.Start();   
        MainScene.Start();     
    }
    public static void Reset()
    {
        Name = "Chad";
        Job = "전사";
        Level = 1;
        Hp = 20;
        MaxHp = 100;
        Atk = 10;
        Def = 5;
        Gold = 3000;
        level = 1;
        Exp = 0;
        foreach (var item in Item.AllItems)
        {
            item.IsEquipped = false;
            item.IsOccupied = false;
        }
        Inventory.Items.Clear();
        Inventory.renew();
    }

    public static void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Die();
        }
    }
    public static void TakePercentageDamage(float percent)
    {
        Hp = (int)(Hp * percent);
        if (Hp <= 0)
        {
            Die();
        }
    }

}
