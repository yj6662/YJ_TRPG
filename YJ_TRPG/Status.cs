using System;

public static class Status
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.WriteLine($"Lv. {Player.Level.ToString("D2")}");
            Console.WriteLine($"{Player.Name} ( {Player.Job} )");
            Console.WriteLine($"공격력 : {Player.totalAtk()}");
            Console.WriteLine($"방어력 : {Player.totalDef()}");
            Console.WriteLine($"체 력 : {Player.Hp} / {Player.MaxHp}");
            Console.WriteLine($"Gold : {Player.Gold} G");
            Console.WriteLine($"레벨 : {Player.level}\n");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();
            if (input == "0")
                break;
            else
                Console.WriteLine("\n잘못된 입력입니다. 다시 시도해주세요.");
        }
        Console.Clear();
    }
}
