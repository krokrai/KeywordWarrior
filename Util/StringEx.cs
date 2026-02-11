using System;
using System.Text;

public static class StringExt
{
    public static void ColorPrinterString(this string s, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(s);
        Console.ResetColor();
    }

    public static void ColorPrinterChar(this char c, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(c);
        Console.ResetColor();
    }

    public static void ColorPrinterInt(this int n, ConsoleColor color)
    {
        if (n > 9 || n < 0) return;
        switch(n)
        {
            case 0 :
                '０'.ColorPrinterChar(color);
                break;
            case 1:
                '１'.ColorPrinterChar(color);
                break;
            case 2:
                '２'.ColorPrinterChar(color);
                break;
            case 3:
                '３'.ColorPrinterChar(color);
                break;
            case 4:
                '４'.ColorPrinterChar(color);
                break;
            case 5:
                '５'.ColorPrinterChar(color);
                break;
            case 6:
                '６'.ColorPrinterChar(color);
                break;
            case 7:
                '７'.ColorPrinterChar(color);
                break;
            case 8:
                '８'.ColorPrinterChar(color);
                break;
            case 9:
                '９'.ColorPrinterChar(color);
                break;
        }
    }

    // 받아온 수를 분리
    // 분리된 수를 2 바이트 문자열로 전환
    // 전환된 문자열을 출력
    public static void InttoString(this int n, ConsoleColor color)
    {
        int[] num = new int[8];
        byte count = 0;
        int i;

        while (n > 9)
        {
            num[count] = n / 10;
            n %= 10;
            count++;
        }

        count--;

        for (i = 0; i < count / 2; i++)
        {
            int temp = num[i];
            num[i] = num[count - i];
            num[count - i] = temp;
        }

        for (i =0; i < count; i++)
        {
            num[i].ColorPrinterInt(color);
        }
    }
}