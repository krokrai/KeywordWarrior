using System;

public enum Select
{
    Up = 1,Down = -1, Nomal = 0
}

namespace KeywordWarrior
{
    public class ScreenRenderer
    {
        // console 기본 크기
        private const int TOP = 18;
        private const int LEFT = 80;

        private const int CONSOLESIZEI = 20;
        private const int CONSOLESIZEE = 161;

        private int _currentSelected;
        private int _maxSelectNum;

        private Position CursorPos;

        private Maps _map;

        public ScreenRenderer()
        {
            Console.SetWindowSize(CONSOLESIZEE, CONSOLESIZEI);
            _currentSelected = 0;
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
                        "□".ColorPrinterString(ConsoleColor.Gray);
                    }
                    else if ( ( i == 0 || i == TOP - 1 ) )
                    {
                        "ㅡ".ColorPrinterString(ConsoleColor.Gray);
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

        // 아래 Render부분 하드코딩으로 임시 작업 및 후에 필요시 코드 개선

        // 화면 전체를 랜더링 해줄 함수
        // + 화면 위치에 따라서 자동 랜더링 하는 거 만들기.
        //public void ScreenRender(in string[] s)
        public void ScreenRender()
        {
            CursorPos = _map.MapLoader(0);
            _maxSelectNum = _map._position.Count;

            Console.SetCursorPosition(CursorPos.X,CursorPos.Y);
            CursorPos++;
            for (int i = 0; i < _map._scr.Length;i++)
            {
                Console.SetCursorPosition(CursorPos.X, CursorPos.Y + i);
                _map._scr[i].ColorPrinterString(ConsoleColor.Gray);
            }

            ScreenPartlyRender(Select.Up);
        }

        // 화면 일부(선택 부분이 바뀔) 랜더링 함수
        // + 위에 구현된 부분에서 몇번째 줄만 바뀔 건지.
        //public void ScreenPartlyRender(Position p, string s)
        public void ScreenPartlyRender(Select sel)
        {
            // 움직임에 문제가 있음.
            // 움직일 때마다 초기화 필요함.
            switch(sel)
            {
                case Select.Up:
                    if ( _currentSelected < _maxSelectNum )
                        _currentSelected++;
                    break;
                case Select.Down:
                    if (_currentSelected > 2)
                        _currentSelected--;
                    break;
                case Select.Nomal:

                    break;
            }

            CursorPos = _map._position[_currentSelected];

            Console.SetCursorPosition(CursorPos.X, CursorPos.Y);
            _map._scrSel[_currentSelected - 1].ColorPrinterString(ConsoleColor.Gray);

        }
    }
}