using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SheepTools;

/// <summary>
/// This class is designed to manage Advent of Code "Seven Seg" Displays which are generally used to
/// show text on screens made up of pixels.  These displays use characters which are 4x6 and contain a
/// single column of spaces (and are thus 5px wide).
/// </summary>
public class AoCSixHeightDisplay
{
    List<bool> pixels = new List<bool>();
    int Width;
    public AoCSixHeightDisplay(int width)
    {
        Width = width;
    }

    int currentPixel = 0;

    public void SetNext(bool active)
    {
        pixels.Add(active);
        currentPixel++;
    }

    public string ToString()
    {
        int numChars = Width / 5;
        string value = "";
        for(int i = 0; i < numChars; i++)
        {
            value += GetChar(i);
        }
        return value;
    }

    private char GetChar(int i)
    {
        return '?';
    }
    public void Print()
    {
        for(int i  = 0; i < pixels.Count; i++)
        {
            if (pixels[i])
                Console.Write("█");
            else
                Console.Write(".");
            if ((i+1) % Width == 0 && i > 0)
                Console.WriteLine();
        }

    }

}
