using System;

public static class PlayerSetup
{
    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("원하시는 이름을 입력해주세요:");
        Console.Write(">> ");

        string input = Console.ReadLine();
        Player.Name = input;

        Console.WriteLine($"\n환영합니다, {Player.Name}님!");
        Console.WriteLine("아무 키나 눌러 스파르타 마을로 이동합니다...");
        Console.ReadKey();
        Console.Clear();
    }
}
 