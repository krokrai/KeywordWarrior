using System;

namespace KeywordWarrior
{
    public class ScreenRenderer
    {
        // console 기본 크기
        private const int TOP = 18;
        private const int LEFT = 80;

        private const int CONSOLESIZEI = 20;
        private const int CONSOLESIZEE = 161;

        public ScreenRenderer()
        {
            Console.SetWindowSize(CONSOLESIZEE, CONSOLESIZEI);
        }

        public void BasicMapRender()
        {
            // 모서리 : ◎ / 수평 일자 : 〓 / 수직 일자 : ㅣ 빈공간 : "　"
            for (int i = 0; i < TOP; i++)
            {
                for (int j = 0; j < LEFT; j++)
                {
                    if ((i == 0 && j == 0) || (i == TOP - 1 && j == LEFT - 1) || (i == TOP - 1 && j == 0) || (i == 0 && j == LEFT - 1))
                    {
                        "◎".ColorPrinterString(ConsoleColor.Gray);
                    }
                    else if ( ( i == 0 || i == TOP - 1 ) )
                    {
                        "〓".ColorPrinterString(ConsoleColor.Gray);
                    }
                    else if ( (j == 0 || j == LEFT - 1) )
                    {
                        "ㅣ".ColorPrinterString(ConsoleColor.Gray);
                    }
                    else
                    {
                        "　".ColorPrinterString(ConsoleColor.Gray);
                    }
                }
                Console.WriteLine();
            }
        }

        public void ScreenRender()
        {

        }
    }
}