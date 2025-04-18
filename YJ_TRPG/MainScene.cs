﻿using System;

public static class MainScene
{
    public static void Start()
    {
        int inputNumber = 0;

        while (true)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 휴식하기");
            Console.WriteLine("5. 던전 탐험");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out inputNumber))
            {
                switch (inputNumber)
                {
                    case 1:
                        Status.Show();
                        break;
                    case 2:
                        Inventory.Show();
                        break;
                    case 3:
                        Shop.Show();
                        break;
                    case 4:
                        Player.Recovery();
                        break;
                    case 5:
                        Dungeon.Show();
                        break;
                    default:
                        Console.WriteLine("1~3 사이의 숫자를 입력해주세요.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
            }

            Console.WriteLine();
        }
    }
}
