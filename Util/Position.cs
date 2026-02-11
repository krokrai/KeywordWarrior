using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Position operator +(Position p1, Position p2) => new Position(p1.X + p2.X, p1.Y + p2.Y);
    public static Position operator -(Position p1, Position p2) => new Position(p1.X - p2.X, p1.Y - p2.Y);
    public static Position operator *(Position p1, Position p2) => new Position(p1.X * p2.X, p1.Y * p2.Y);
    public static Position operator /(Position p1, Position p2) => new Position(p1.X / p2.X, p1.Y / p2.Y);
    public static Position operator %(Position p1, Position p2) => new Position(p1.X % p2.X, p1.Y % p2.Y);
    public static Position operator ++(Position p1) => new Position(p1.X + 1, p1.Y + 1);
    public static Position operator --(Position p1) => new Position(p1.X - 1, p1.Y - 1);
}
