using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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


    public void MapLoader(MapList list)
    {
        _position = new List<Position>();
        _currentSelect = 0;
        switch (list)
        {
            case 0:
                MainMenu();
                break;
        }
    }

    private void MainMenu()
    {
        if (_position.Count > 0)
            _position.Clear();
        _position.Add(new Position(4, 0));
        _position.Add(new Position(5, 0));
        _scr = new string[] { "□ㅡㅡㅡㅡㅡㅡㅡ□",
                                        "ㅣ키워드　워리어ㅣ",
                                        "□ㅡㅡㅡㅡㅡㅡㅡ□",
                                        "ㅣ　게임　시작　ㅣ",
                                        "ㅣ　게임　종료　ㅣ",
                                        "□ㅡㅡㅡㅡㅡㅡㅡ□"};

        _scrSel = new string[] { "〓→게임　시작　〓",
                                             "〓→게임　종료　〓" };
    }
}