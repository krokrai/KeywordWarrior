using KeywordWarrior;
using System;

class Program // warrior do you best
{
    // - Todo 능력 발현 마무리하기,  능력 추가
    // - 던전 맵 제작 구현 (부분 완료)
    // - 던전 적 구현
    // - UI 만들기 ( 자동화 필수)
    // - 적 ai 만들기(;;;;)

    static int FLOOR = 1;
    static string[] combatLog = new string[5];

    static void Main(string[] args)
    {
        ScreenRenderer scrRender = new ScreenRenderer();
        scrRender.BasicMapRender();
        scrRender.ScreenRender();
        while  (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.UpArrow)
            {
                scrRender.ScreenPartlyRender(Select.Up);
            }
            else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
            {
                scrRender.ScreenPartlyRender(Select.Down);
            }
        }
            

        // 랜더링 재작업 75%
        // 추가 작업 필요 : 화면 내에서 선택 및 전환 추가 필요
        // 이후 작업 : 랜더이 외에 작업



        //Character p = new Character();
        //Character e = new Character();
        //p.SelectChar(0);
        //e.SelectMonster(0);

        //CombatScreenPrinter(p, e);
        //char[,] Map;
        //KeywordsActive("점화 복제 강화 점화 강화");
        //int maxCharater = 1; // 수동으로 어쩌구 캐릭터 최대치
        //Character ch = new Character();
        //int isStart = MainMenu();
        //while (isStart == 0)
        //{
        //    ch.SelectChar(0);
        //    int tempChoice = GameStartPointScreens();
        //    if (tempChoice == 0) // 야영지 입장
        //    {
        //        ch.SelectChar(ChoiceCharater(maxCharater));
        //    }
        //    else if (tempChoice == 1) // 던전 입장
        //    {
        //    
        //    }
        //}
        //ChoiceYourDifficulty();

    }

    /// <summary>
    /// 마참네 던전 코드 만든다.
    /// </summary>
    static void EntertheDungeon()
    {
        int difficulty = ChoiceYourDifficulty();
        while (true)
        {

        }
        // Random aaa = new Random());
        // int aa = aaa.Next(1,5); // 1이상 5미만의 임의의 숫자 1개
    }

    /// <summary>
    /// 난이도 선택기...
    /// </summary>
    /// <returns> 0 : 연습 ~ 4 : 오염된 던전 </returns>
    static int ChoiceYourDifficulty()
    {
        int arrowPos = 0;
        Console.WriteLine("-------------------------------\n" +
            "----------난이도 선택----------\n" +
            "-------------------------------\n" +
            "      ->     연습\n" +
            "             쉬움\n" +
            "             보통\n" +
            "            어려움\n" +
            "         오염된 던전\n");
        while (true)
        {
            ConsoleKey cnKey = Console.ReadKey().Key;
            if (cnKey == ConsoleKey.DownArrow || cnKey == ConsoleKey.UpArrow)
            {
                switch (cnKey)
                {
                    case ConsoleKey.DownArrow:
                        arrowPos = (arrowPos + 1) < 5 ? arrowPos + 1 : 0;
                        break;
                    case ConsoleKey.UpArrow:
                        arrowPos = (arrowPos - 1) > -1 ? arrowPos - 1 : 4;
                        break;
                }
                Console.Clear();
                switch (arrowPos)
                {
                    case 0:
                        Console.WriteLine("-------------------------------\n" +
            "----------난이도 선택----------\n" +
            "-------------------------------\n" +
            "      ->     연습\n" +
            "             쉬움\n" +
            "             보통\n" +
            "            어려움\n" +
            "         오염된 던전\n");
                        break;
                    case 1:
                        Console.WriteLine("-------------------------------\n" +
            "----------난이도 선택----------\n" +
            "-------------------------------\n" +
            "             연습\n" +
            "      ->     쉬움\n" +
            "             보통\n" +
            "            어려움\n" +
            "         오염된 던전\n");
                        break;
                    case 2:
                        Console.WriteLine("-------------------------------\n" +
            "----------난이도 선택----------\n" +
            "-------------------------------\n" +
            "             연습\n" +
            "             쉬움\n" +
            "      ->     보통\n" +
            "            어려움\n" +
            "         오염된 던전\n");
                        break;
                    case 3:
                        Console.WriteLine("-------------------------------\n" +
            "----------난이도 선택----------\n" +
            "-------------------------------\n" +
            "             연습\n" +
            "             쉬움\n" +
            "             보통\n" +
            "      ->    어려움\n" +
            "         오염된 던전\n");
                        break;
                    case 4:
                        Console.WriteLine("-------------------------------\n" +
            "----------난이도 선택----------\n" +
            "-------------------------------\n" +
            "             연습\n" +
            "             쉬움\n" +
            "             보통\n" +
            "            어려움\n" +
            "      -> 오염된 던전\n");
                        break;
                }
            }
            else if (cnKey == ConsoleKey.Enter)
            {
                Console.Clear();
                return arrowPos;
            }
        }
    }

    /* 1. 적들은 아래에 정해진 방 이외에 모든 방으로 채운다.
     *  2. 보스는 해당 층의 마지막 방에 나온다, (안나오게 하는 것도 재밌을 듯, 안나온다면 빈방?)
     *  3. 상점은 한 게임 내에 0~2회, 마지막층과 마지막 방에서 나오지 않음
     *  4. 휴식은 층당 0~1회, 마지막 방에서 나오지 않음
     *  5. 이벤트는 한 게임당 5~7회, 마지막 방에서 나오지 않음
     */
    /*static void MapMaker(ref char[,] map)
    {
        Random random = new Random();
        int t = random.Next(7, 12);
        map = new char[5, t];
        //byte a = 0;
        //(45 - 11) / 4 = 8 / 1 // 마지막 층은 반드시 9칸 - > 임시적으로 모든 층의 방에 갯수 통일

        // 층이 넣어지면 a--;
        // t

        // 9칸을 기준으로 7칸은 전투 1~2칸을 휴식 상점 이벤트 배치는 무관  // 77.77% => 80
        //t -= 11;
        //byte b = 0;
        //byte shop = 0;
        //byte rest = 0;
        //byte gameEvent = 0;
        for (int i = 0; i < 5; i++)
        {
            //if (a > 0)
            //{
            //    if ( a >= i)
            //    {
            //        a--;
            //        b++;
            //    }
            //}
            //for (int j = 0; j < t / 4 + b ; j++)
            for (int j = 0; j < map.GetLength(1); j++)
            {
                byte chance = Convert.ToByte(random.Next(1, 101));
                if (j == (map.GetLength(1) - 1))
                {
                    // 이방은 보스 방이여;
                }
                else if (chance <= 80) // 전투 이외의 방
                {
                    byte nomalEvents = Convert.ToByte(random.Next(1, 21)); // 1 ~ 20 11 이벤트 7 휴식 3 상점
                    if (0 < chance && chance < 12) // 1 ~ 11
                    {
                        // 이벤트
                    }
                    else if (11 < chance && chance < 19) // 12 ~ 18
                    {
                        // 휴식
                    }
                    else // 19 ~ 20
                    {
                        // 상점

                    }
                }
                else
                {
                    // 전투방
                }
            }
            b = 0;
        }

    }*/


    //int a = 5;
    //string ss = $" 1 턴당 {a}를 얻는다.";
    static void UserInterfacePrinter(ref Character ch)
    {

        //Console.WriteLine("┌───────────────────────────────────────────────────────────────┐");
        //Console.WriteLine($"│───────────────────────────────────────────────────────────────│");
        //Console.WriteLine("│                                                               │");
        Console.WriteLine("┌───────────────────────────────────────────────────────────────┐");
        Console.WriteLine($"│──────────────────────── 현제 2 층 ────────────────────────────│");
        Console.WriteLine("│┌───────────────────────────┐     ┌───────────────────────────┐│");
        Console.WriteLine($"││체력   : 100  보호막 : 100 │     │체력  :  100  보호막 : 100 ││");
        Console.WriteLine($"││공격력 : 100  주문력 : 100 │     │공격력 : 100  주문력 : 100 ││ ");
        Console.WriteLine("│├──────── 상태 이상 ────────┤     ├──────── 상태 이상 ────────┤│");
        Console.WriteLine("││ 점화 lv.3 3 / 감점 lv.2 1 │     │ 점화 lv.3 3 / 감점 lv.2 1 ││"); // 27 34 50 61 77
        Console.WriteLine("│└───────────────────────────┘     └───────────────────────────┘│");
        Console.WriteLine("│┌───────────────────── 키워드 사용 가능 ──────────────────────┐│");
        Console.WriteLine("││1 턴당 얻는 키워드 : 3  \t최대 보유 가능 키워드 수 : 5   ││");
        Console.WriteLine("││점화\t 강화\t                                               ││");
        Console.WriteLine("││                                                             ││");
        Console.WriteLine("│└─────────────────────────────────────────────────────────────┘│");
        Console.WriteLine("│ 플레이어는 대상에게 점화 lv.2을 사용했다 피해량 : 100         │");
        Console.WriteLine("│ 플레이거는 대상에게 상태이상 화염을 걸었다.                   │");
        Console.WriteLine("│ 플레이어는 대상에게 점화 lv.1을 사용했다 피해량 : 100         │");
        Console.WriteLine("│                                                               │");
        Console.WriteLine("│                                                               │");
        Console.WriteLine("│───────────────────────────────────────────────────────────────┤");
        Console.WriteLine("│ 키워드 입력 : 불 강화 강화 불 강화                            │");
        Console.WriteLine("└───────────────────────────────────────────────────────────────┘");

    }

    enum AttackAbilitys
    {
        Attack, Ignition, strike
    }

    enum DefensiveAbilitys
    {
        Defens, Shield
    }

    enum UtilityAbilitys
    {
        Reinforce, Copy
    }

    static int KeywordsActive(string s)
    {
        string[] keyWords = s.Split(' ');
        int lv = 0;
        if (keyWords.Length > 5)
            return -1;
        for (int i = 0; i < keyWords.GetLength(0); i++)
        {
            //탐색기
            switch (keyWords[i])
            {
                case "점화":
                    //Console.WriteLine("");
                    EnchantedSkill(keyWords, ref i, out lv);
                    AbilityActive("점화", lv);
                    break;
            }
        }
        return 0;
    }

    static void AbilityActive(in string s, in int lv)
    {
        Console.WriteLine($"{s} Lv.{lv} 공격!");
    }

    /// <summary>
    /// 복제 처리 및 그 외에 모든 강화 처리
    /// </summary>
    /// <param name="ss"> 주문 배열 참조 </param>
    /// <param name="aa"> 현제 주문의 위치 </param>
    /// <param name="lv"> 주문 강화 </param>
    /// <returns></returns>
    static bool EnchantedSkill(in string[] ss, ref int aa, out int lv)
    {
        lv = 0;
        for (int i = aa + 1; i < ss.GetLength(0); i++)
        {

            switch (ss[i])
            {
                case "복제":
                    ss[i] = ss[i - 1];
                    break;
            }
        }
        for (int i = aa + 1; i < ss.GetLength(0); i++)
        {

            switch (ss[i])
            {
                case "강화":
                    lv += 1;
                    break;
                default:
                    return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 메인 메뉴 띄어주기!
    /// switch 문을 사용한 ★노☆가★다☆
    /// </summary>
    /// <returns> 0 : 게임 시작 / 1 : 게임 종료</returns>
    static int MainMenu()
    {
        byte arrowPos = 0;
        Console.WriteLine("-------------------------------");
        Console.WriteLine("------Keyword Warrior----------");
        Console.WriteLine("-------------------------------\n");
        Console.WriteLine("      -> 게임 시작");
        Console.WriteLine("         게임 종료");
        while (true)
        {
            ConsoleKey cnKey = Console.ReadKey().Key;
            if (cnKey == ConsoleKey.DownArrow || cnKey == ConsoleKey.UpArrow)
            {
                Console.Clear();
                switch (arrowPos)
                {
                    case 0:
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("------Keyword Warrior----------");
                        Console.WriteLine("-------------------------------\n");
                        Console.WriteLine("         게임 시작");
                        Console.WriteLine("      -> 게임 종료");
                        arrowPos++;
                        break;
                    case 1:
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("------Keyword Warrior----------");
                        Console.WriteLine("-------------------------------\n");
                        Console.WriteLine("      -> 게임 시작");
                        Console.WriteLine("         게임 종료");
                        arrowPos--;
                        break;
                }
            }
            else if (cnKey == ConsoleKey.Enter)
            {
                Console.Clear();
                return arrowPos;
            }
        }
    }

    /// <summary>
    /// 게임 시작 화면
    /// 야영지와 던전을 선택할 수 있으며, 던전 선택시, 기본 캐릭터 0번으로 진입
    /// </summary>
    /// <returns> 0 : 야영지 / 1 : 던전</returns>
    static int GameStartPointScreens()
    {
        Console.WriteLine("                                - O\n" +
                                      "           mm                       |\n " +
                                      "        uuuuu                                 \n" +
                                      "       ↓                                  \n" +
                                      "   _________                   ______\n" +
                                      "  /  야영지 \\                 | 던전 | \n" +
                                      " |          |                 |      | \n" +
                                      " |     □   |                 |  □  | \n" +
                                      "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm\n" +
                                      "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh\n");
        byte arrowPos = 0;
        while (true)
        {
            ConsoleKey cnKey = Console.ReadKey().Key;
            if (cnKey == ConsoleKey.RightArrow || cnKey == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                switch (arrowPos)
                {
                    case 0:
                        Console.WriteLine("                                - O\n" +
                                      "           mm                       |\n " +
                                      "        uuuuu                                 \n" +
                                      "                                 ↓        \n" +
                                      "   _________                   ______\n" +
                                      "  /  야영지 \\                 | 던전 | \n" +
                                      " |          |                 |      | \n" +
                                      " |     □   |                 |  □  | \n" +
                                      "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm\n" +
                                      "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh\n");
                        arrowPos++;
                        break;
                    case 1:
                        Console.WriteLine("                                - O\n" +
                                      "           mm                       |\n " +
                                      "        uuuuu                                 \n" +
                                      "       ↓                                  \n" +
                                      "   _________                   ______\n" +
                                      "  /  야영지 \\                 | 던전 | \n" +
                                      " |          |                 |      | \n" +
                                      " |     □   |                 |  □  | \n" +
                                      "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm\n" +
                                      "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh\n");
                        arrowPos--;
                        break;
                }
            }
            else if (cnKey == ConsoleKey.Enter)
            {
                Console.Clear();
                return arrowPos;
            }
        }
    }

    /// <summary>
    /// 캐릭터 선택창
    /// </summary>
    /// <param name="limitChar"> 현제 완성된 캐릭터 최대수</param>
    /// <returns> 선택한 0~11로 반환</returns>
    static int ChoiceCharater(int limitChar)
    {
        Console.WriteLine("               ↓                                                           \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                                      \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ?????????????  | ?????????????  | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ?????????????  | ?????????????  | ????????????? |_______\n");
        int arrowPos = 0;
        while (true)
        {
            ConsoleKey cnKey = Console.ReadKey().Key;
            if (cnKey == ConsoleKey.RightArrow || cnKey == ConsoleKey.LeftArrow || cnKey == ConsoleKey.DownArrow || cnKey == ConsoleKey.UpArrow)
            {
                switch (cnKey)
                {
                    case ConsoleKey.LeftArrow:
                        arrowPos = ((arrowPos - 1) < 0) ? 11 : arrowPos - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        arrowPos = ((arrowPos + 1) > 11) ? 0 : arrowPos + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        arrowPos = ((arrowPos - 3) < 0) ? arrowPos + 9 : arrowPos - 3;
                        break;
                    case ConsoleKey.DownArrow:
                        arrowPos = ((arrowPos + 3) > 11) ? arrowPos - 9 : arrowPos + 3;
                        break;
                }
                Console.Clear();
                switch (arrowPos)
                {
                    case 0:
                        Console.WriteLine("               ↓                                                           \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                                      \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 1:
                        Console.WriteLine("                               ↓                                           \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                                      \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 2:
                        Console.WriteLine("                                               ↓                      \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                                      \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 3:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |       ↓                                                                             \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 4:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                       ↓                                                   \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 5:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                       ↓                               \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 6:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                                   \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |       ↓                                                                             \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 7:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                             \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                       ↓                                                   \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 8:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                             \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                       ↓                                    \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                       \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 9:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                                      \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |       ↓                                                                             \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 10:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                          \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                       ↓                                                   \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                    case 11:
                        Console.WriteLine("                                                                          \n" +
                                      " ------|  균형과 조화  |  겁화의 상징  | 얼어붙은 심장 | ---------- \n" +
                                      "       |                                                                      \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                                                                 \n" +
                                      "       | ????????????? | ????????????? | ????????????? |\n" +
                                      "       |                                       ↓                               \n" +
                                      "_______| ????????????? | ????????????? | ????????????? |_______\n");
                        break;
                }
            }
            else if (cnKey == ConsoleKey.Enter)
            {
                if (arrowPos < limitChar)
                {
                    Console.Clear();
                    return arrowPos;
                }
                continue;
            }
        }
    }

    /*public struct ChoiceYourDestinyCharacter
    {
        public FirstCharacter(double _healthPoint, double _healthRegen, double _attackDamage, double _armor, double _abilityPower, double _magicResistnce, double _speed)
        {
            healthPoint = _healthPoint;
            healthRegen = _healthRegen;
            attackDamage = _attackDamage;
            armor = _armor;
            abilityPower = _abilityPower;
            magicResistnce = _magicResistnce;
            speed = _speed;
        }

        public ChoiceYourDestinyCharacter(int a)
        {
            switch(a)
            {
                case 1:
                    healthPoint = 100;
                    healthRegen = 1;
                    attackDamage = 1;
                    armor = 1;
                    abilityPower = 1;
                    magicResistnce = 1;
                    speed = 100;
                    break;

                default:
                    healthPoint = 100;
                    healthRegen = 1;
                    attackDamage = 1;
                    armor = 1;
                    abilityPower = 1;
                    magicResistnce = 1;
                    speed = 100;
                    break;
            }
        }


        public void PlayerStateInfo(out double hp, out double hpr, out double admg, out double arm, out double abilityP, out double mR, out double speeed )
        {
            hp = healthPoint;
            hpr = healthRegen;
            admg = attackDamage;
            arm = armor;
            abilityP = abilityPower;
            mR = magicResistnce;
            speeed = speed;
        }

        private double healthPoint { get; }
        private double healthRegen { get; }
        private double attackDamage { get; }
        private double armor { get; }
        private double abilityPower { get; }
        private double magicResistnce { get; }
        private double speed { get; }
    }*/

    static void CombatScreenPrinter(Character pChar, Character eChar) // pad를 이용한 공간 맞추기... // 문자기준 x = 80 y = 16
    {
        Console.WriteLine("┌───────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine($"│──────────────────────────── 현제 {FLOOR} 층 ────────────────────────────────│");
        Console.WriteLine("│┌───────────────────────────────┐     ┌───────────────────────────────┐│");
        Console.WriteLine($"││ 체력   : {pChar.GetCharacterInfo(CharacterType.healthPoint)} 보호막 : {pChar.GetCharacterInfo(CharacterType.shield)} │     │ 체력   : {eChar.GetCharacterInfo(CharacterType.healthPoint)} 보호막 : {eChar.GetCharacterInfo(CharacterType.shield)} ││");
        Console.WriteLine($"││ 공격력 : {pChar.GetCharacterInfo(CharacterType.attackDamage)} 주문력 : {pChar.GetCharacterInfo(CharacterType.abilityPower)} │     │ 공격력 : {eChar.GetCharacterInfo(CharacterType.attackDamage)} 주문력 : {eChar.GetCharacterInfo(CharacterType.abilityPower)} ││ ");
        Console.WriteLine("│├────────── 상태 이상 ──────────┤     ├────────── 상태 이상 ──────────┤│");
        Console.WriteLine("││ 점화 lv.3 3 / 감점 lv.2 1 │     │ 점화 lv.3 3 / 감점 lv.2 1 ││");
        Console.WriteLine("│└───────────────────────────────┘     └───────────────────────────────┘│");
        Console.WriteLine("│ 플레이어는 대상에게 점화 lv.2을 사용했다 피해량 : 100         │");
        Console.WriteLine("│ 플레이거는 대상에게 상태이상 화염을 걸었다.                   │");
        Console.WriteLine("│ 플레이어는 대상에게 점화 lv.2을 사용했다 피해량 : 100         │");
        Console.WriteLine("│                                                                       │");
        Console.WriteLine("│                                                                       │");
        Console.WriteLine("│───────────────────────────────────────────────────────────────────────┤");
        Console.WriteLine("│ 키워드 입력 :                                                         │"); //14 17
        Console.WriteLine("└───────────────────────────────────────────────────────────────────────┘");
        Console.SetCursorPosition(15, 14);
        KeywordsActive(Console.ReadLine());
    }

    // 추가 해볼만한 이름들 : 용맹의 방패,
    enum PCharacter
    {
        balanceAndHarmony, symbolOfHellfire, heartOfFrozen,
    }

    enum CharacterType
    {
        maxHealthPoint, healthPoint, healthRegen, maxShield, shield, attackDamage, armor, abilityPower, magicResistnce, speed, level
    }

    static void CombatLogPrinter()
    {
        for (int i = 0; i < combatLog.Length; i++)
        {

        }
        Console.SetCursorPosition(3, 8);
    }

    struct AbnormalEffect
    {
        private string effectName;
        private int lv;
        private int turn;

        public AbnormalEffect GetInfo()
        {
            return new AbnormalEffect()
            {
                effectName = this.effectName,
                lv = this.lv,
                turn = this.turn
            };
        }

        public void SetInfo(string _name, int _lv, int _trun)
        {
            effectName = _name;
            lv = _lv;
            turn = _trun;
        }
    }

    /// <summary>
    /// 플레이어랑 적들 기본 구조
    /// </summary>
    struct Character
    {
        private double maxHealthPoint;
        private double healthPoint;
        private double healthRegen;
        private double maxShield;
        private double shield;
        private double attackDamage;
        private double armor;
        private double abilityPower;
        private double magicResistnce;
        private double speed;
        private int level;

        private AbnormalEffect[] aEffect;

        //public Character(double _healthPoint, double _healthRegen, double _attackDamage, double _armor, double _abilityPower, double _magicResistncs, double _speed = 100)
        //{
        //    healthPoint = _healthPoint;
        //    healthRegen = _healthRegen;
        //    attackDamage = _attackDamage;
        //    armor = _armor;
        //    abilityPower = _abilityPower;
        //    magicResistnce = _magicResistncs;
        //    speed = _speed;
        //    level = 0;
        //}

        public void Addeffect(AttackAbilitys type)
        {
            byte slot = 0;
            for (byte i = 0; i < aEffect.Length; i++)
            {
                /*if (aEffect[i].Equals(new AbnormalEffect { "", 0, 0 }))
                {
                    slot = i;
                    break;
                }*/
            }
            if (slot > 0)
            {
                switch (type)
                {
                    case AttackAbilitys.Ignition:
                        //aEffect[slot] = new AbnormalEffect { "점화", 1, 2 };
                        break;
                }
            }
            else
            {
                Console.Write("상태이상을 더 걸 수 없습니다.(최대 2개)");
            }
        }

        public string GetCharacterInfo(CharacterType type)
        {
            string s;
            switch (type)
            {
                case CharacterType.maxHealthPoint:
                    s = maxHealthPoint.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.healthPoint:
                    s = healthPoint.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.healthRegen:
                    s = healthRegen.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.maxShield:
                    s = maxShield.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.shield:
                    s = shield.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.attackDamage:
                    s = attackDamage.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.armor:
                    s = armor.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.abilityPower:
                    s = abilityPower.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.magicResistnce:
                    s = magicResistnce.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.speed:
                    s = speed.ToString("0.0");
                    s = s.PadLeft(5, ' ');
                    return s;
                case CharacterType.level:
                    s = level.ToString();
                    s = s.PadLeft(3, ' ');
                    return s;
            }
            return "None";
        }

        public void Healing(double point = 0, bool isheal = false)
        {
            if (isheal)
            {
                healthPoint = (healthPoint + point) > maxHealthPoint ? maxHealthPoint : healthPoint + point;
            }
            else
            {
                healthPoint = (healthPoint + healthRegen) > maxHealthPoint ? maxHealthPoint : healthPoint + healthRegen;
            }
        }

        public void ShieldUp(double point = 0)
        {
            shield = (shield + point) > maxShield ? maxShield : shield + point;
        }

        public void ChangedState(double index, CharacterType type)
        {
            switch (type)
            {
                case CharacterType.maxHealthPoint:
                    maxHealthPoint += index;
                    break;
                case CharacterType.healthPoint:
                    healthPoint += index;
                    break;
                case CharacterType.healthRegen:
                    healthRegen += index;
                    break;
                case CharacterType.maxShield:
                    maxShield += index;
                    break;
                case CharacterType.shield:
                    shield += index;
                    break;
                case CharacterType.attackDamage:
                    attackDamage += index;
                    break;
                case CharacterType.armor:
                    armor += index;
                    break;
                case CharacterType.abilityPower:
                    abilityPower += index;
                    break;
                case CharacterType.magicResistnce:
                    magicResistnce += index;
                    break;
                case CharacterType.speed:
                    speed += index;
                    break;
                case CharacterType.level:
                    level += (int)index;
                    break;
            }
        }

        public double GetDef(bool isMagic)
        {
            return isMagic ? magicResistnce : armor;
        }

        public double GetDmg(bool isMagic)
        {
            return isMagic ? abilityPower : attackDamage;
        }

        public void SelectChar(int c)
        {
            aEffect = new AbnormalEffect[2];
            switch (c)
            {
                case 0:
                    //균형과 조화
                    maxHealthPoint = 100;
                    healthPoint = 100;
                    healthRegen = 1;
                    maxShield = 100;
                    shield = 0;
                    attackDamage = 1;
                    armor = 1;
                    abilityPower = 1;
                    magicResistnce = 1;
                    speed = 100;
                    level = 0;
                    break;
                case 1:
                    // 겁화의 상징

                    break;
                case 2:
                    // 얼어붙은 심장

                    break;
                default:
                    healthPoint = 100;
                    healthRegen = 1;
                    attackDamage = 5;
                    armor = 1;
                    abilityPower = 5;
                    magicResistnce = 1;
                    speed = 100;
                    level = 0;
                    break;
            }
        }

        private void LeveUpPlayer(int charNum, int lv)
        {
            switch (charNum)
            {
                case 0:
                    maxHealthPoint = 100;
                    healthPoint = 100;
                    healthRegen = 1;
                    maxShield = 100;
                    shield = 0;
                    attackDamage = 1;
                    armor = 1;
                    abilityPower = 1;
                    magicResistnce = 1;
                    speed = 100;
                    level = 0;
                    break;
            }
        }

        public void SelectMonster(int m)
        {
            aEffect = new AbnormalEffect[2];
            switch (m)
            {
                case 0:
                    // 몬스터 1
                    healthPoint = 20;
                    healthRegen = 1;
                    attackDamage = 1;
                    armor = 1;
                    abilityPower = 1;
                    magicResistnce = 1;
                    speed = 60;
                    level = 0;
                    break;
                case 1:

                    break;
                case 2:

                    break;
                default:
                    healthPoint = 100;
                    healthRegen = 1;
                    attackDamage = 1;
                    armor = 1;
                    abilityPower = 1;
                    magicResistnce = 1;
                    speed = 100;
                    level = 0;
                    break;
            }
        }
    }

}
