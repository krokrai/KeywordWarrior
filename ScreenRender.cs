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

        // console 사이즈 표준화
        private const int CONSOLESIZEI = 20;
        private const int CONSOLESIZEE = 161;

        private int _currentSelecte;
        private int _nextSelecte;
        private int _maxSelectNum;

        // 선택지가 여러개(2개 이상)일 때 선택 했던 부분 초기화 해주기 위한 보정치 변수
        private int _scrModif;

        private Position CursorPos;

        private Maps _map;

        public ScreenRenderer()
        {
            Console.SetWindowSize(CONSOLESIZEE, CONSOLESIZEI);
            _currentSelecte = 1;
            CursorPos = new Position(-1, -1);
        }

        /// <summary>
        /// 비용이 비싸서 가급적 호출 자제.
        /// </summary>
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
        /// <summary>
        /// 첫 화면인 경우에만 호출 후 사용 (예외처리 배제할 예정)
        /// </summary>
        public void ScreenRender(MapList maplist)
        {
            if(CursorPos.X != -1 &&  CursorPos.Y != -1)
                ScreenEraser();

            CursorPos = _map.MapLoader(maplist);
            _maxSelectNum = _map._position.Count - 2;
            _scrModif = _map._scrSel.Length / 2;

            //Console.SetCursorPosition(CursorPos.X,CursorPos.Y);
            //CursorPos++;
            for (int i = 0; i < _map._scr.Length;i++)
            {
                Console.SetCursorPosition(CursorPos.X, CursorPos.Y + i);
                _map._scr[i].ColorPrinterString(ConsoleColor.Gray);
            }

            ChangedSelect();
        }

        public void ScreenEraser()
        {
            //Console.SetCursorPosition(CursorPos.X,CursorPos.Y);
            int n = _map._scr[0].Length;
            int i;
            char[] c = new char[n];
            for (i = 0; i < c.Length; i ++)
            {
                c[i] = '　';
            }

            string s = new string(c);

            for (i = 0; i < _map._scr.Length; i++)
            {
                Console.SetCursorPosition(_map._position[0].X, _map._position[0].Y + i);
                s.ColorPrinterString(ConsoleColor.Gray);
            }
        }

        public void ScreenPartlyRender(Select sel)
        {
            switch(sel)
            {
                case Select.Up:
                    if (_currentSelecte <= 0) return;
                    _nextSelecte = _currentSelecte - 1;
                    ChangedSelect();
                    break;
                case Select.Down:
                    if (_currentSelecte >= _maxSelectNum) return;
                    _nextSelecte = _currentSelecte + 1;
                    ChangedSelect();
                    break;
                case Select.Nomal:

                    break;
            }
        }

        private void ChangedSelect()
        {
            CursorPos = _map._position[_currentSelecte + 1];
            Console.SetCursorPosition(CursorPos.X, CursorPos.Y);
            _map._scrSel[(_currentSelecte + _scrModif)].ColorPrinterString(ConsoleColor.Gray);

            CursorPos = _map._position[_nextSelecte + 1];
            Console.SetCursorPosition(CursorPos.X, CursorPos.Y);
            _map._scrSel[_nextSelecte].ColorPrinterString(ConsoleColor.Red);

            _currentSelecte = _nextSelecte;
        }
    }
}