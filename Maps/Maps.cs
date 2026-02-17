using System;
using System.Collections.Generic;

public enum MapList
{
    MainMenu = 0,
}

public struct Maps
{
    public string[] _scr;
    public string[] _scrSel;
    public int _currentSelect;
    public List<Position> _position;


    // 여기 맞춰서 재작업 할것
    public Position MapLoader(MapList list)
    {
        _position = new List<Position>();
        _currentSelect = 0;
        switch (list)
        {
            case 0:
                MainMenu();
                break;
        }

        return _position[0];
    }

    private void MainMenu()
    {
        if (_position.Count > 0)
            _position.Clear();
        
        _position.Add(new Position(71, 4)); // 생성될 위치
        
        _position.Add(new Position(72, 8)); // 선택지에 따라 바뀔 위치.
        _position.Add(new Position(72, 9));

        _scr = new string[] { "□ㅡㅡㅡㅡㅡㅡㅡ□",
                                        "ㅣ키워드　워리어ㅣ",
                                        "□ㅡㅡㅡㅡㅡㅡㅡ□",
                                        "ㅣ　게임　시작　ㅣ",
                                        "ㅣ　게임　종료　ㅣ",
                                        "□ㅡㅡㅡㅡㅡㅡㅡ□"};

        _scrSel = new string[] { "ㅣ→게임　시작　ㅣ",
                                             "ㅣ→게임　종료　ㅣ",
                                             "ㅣ　게임　시작　ㅣ",
                                             "ㅣ　게임　종료　ㅣ"};
    }
}