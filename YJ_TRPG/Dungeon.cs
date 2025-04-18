using System;
using System.Threading;
public static class Dungeon
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            int inputNumber = 0;
            Console.WriteLine($"던전 탐험");
            Console.WriteLine($"이곳에서 던전을 선택할 수 있습니다.\n");
            Console.WriteLine("1. 쉬운 던전 | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전 | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전 | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 던전을 선택해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                break;
            }
            if (int.TryParse(input, out inputNumber))
            {
                switch (inputNumber)
                {
                    case 1:
                        Explore(5, 1000);
                        break;
                    case 2:
                        Explore(11, 1700);
                        break;
                    case 3:
                        Explore(17, 2500);
                        break;
                    default:
                        Console.WriteLine("1~3 사이의 숫자를 입력해주세요.");
                        Console.WriteLine("계속하려면 아무 키나 누르세요.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                Console.WriteLine("계속하려면 아무 키나 누르세요.");
                Console.ReadKey();
            }
        }
    }
    public static void Explore(int recommendedDef, int baseReward)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("던전 탐험 중.");
            Console.WriteLine("고블린과 통성명을 합니다.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("던전 탐험 중..");
            Console.WriteLine("오크와 대화 중입니다.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("던전 탐험 중...");
            Console.WriteLine("드래곤과 친구가 되었습니다.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("던전 탐험이 끝났습니다.");
            Console.WriteLine("던전에서 나옵니다.");
            Console.WriteLine("아무 키나 눌러 결과 보기");
            Console.ReadKey();
            break;
        }
        float playerDef = Player.totalDef();
        float playerAtk = Player.totalAtk();

        Random random = new Random();

        if (playerDef<recommendedDef)
        {
            if (random.Next(0,100) < 40)
            {
                failure();
                return;
            }
        }
        int diff = (int)(recommendedDef - playerDef);
        int minLoss = 20 + diff;
        int maxLoss = 35 + diff;

        int hpLoss = random.Next(minLoss, maxLoss);
        int bonusPercent = random.Next((int)playerAtk, (int)playerAtk * 2);

        Clear(hpLoss, baseReward, bonusPercent);
    }
    public static void Clear(int hpLoss, int baseReward, int bonusPercent)
    {
        while (true)
        {
            Console.Clear();
            int totalGold = baseReward + baseReward * bonusPercent / 100;
            int prevHp = Player.Hp;
            int prevGold = Player.Gold;

            Player.TakeDamage(hpLoss);
            Player.Gold += totalGold;
            Player.Exp++;
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!");
            Console.WriteLine("던전을 클리어했습니다.");

            Console.WriteLine("[탐험 결과]");
            Player.LevelUp();

            Console.WriteLine($"체력 {prevHp} -> {Player.Hp}");
            Console.WriteLine($"골드 {prevGold} -> {Player.Gold}");

            Console.WriteLine("아무키나 눌러 결과창 나가기");
            Console.ReadKey();
            break;
        }
    }
    public static void failure()
    {
        while (true)
        {
            Console.Clear();
            Player.TakePercentageDamage(0.5f);
            Console.WriteLine("던전 실패");
            Console.WriteLine("던전 탐험에 실패했습니다.");
            Console.WriteLine("남은 체력이 절반이 되었습니다.");
            Console.WriteLine(Player.Hp + " / " + Player.MaxHp);
            Console.WriteLine("던전에서 나옵니다.");
            Console.WriteLine("아무 키나 눌러 던전에서 나오기");
            Console.ReadKey();
            break;
        }
    }
}
