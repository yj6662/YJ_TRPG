using System;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("  SPARTA RPG  ");
            Console.WriteLine("");
            Console.WriteLine(" 1. 새 게임   ");
            Console.WriteLine(" 2. 불러오기  ");
            Console.WriteLine(" 3. 종료      ");
            Console.WriteLine("");
            Console.Write(">> ");

            var choice = Console.ReadLine();
            if (choice == "1")
            {
                Player.Reset();
                PlayerSetup.Start(); 
                MainScene.Start();
                break;
            }
            else if (choice == "2")
            {
                if (SaveManager.LoadGame())
                {
                    Console.Clear();
                    MainScene.Start();
                    break;
                }
                else
                {
                    Console.WriteLine("\n저장된 게임이 없습니다.");
                    Console.WriteLine("새 게임을 시작하려면 아무키나 누르세요.");
                    Console.ReadKey();

                    Player.Reset();
                    PlayerSetup.Start(); 
                    MainScene.Start();
                }
            }
            else if (choice == "3")
            {
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n잘못된 입력입니다. 다시 선택해주세요.");
                Console.ReadKey();
            }
        }

        SaveManager.SaveGame();
    }
}    
