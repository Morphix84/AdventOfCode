using SheepTools.Model;
using System;
using System.Collections.Generic;
using System.Collections;
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

        //RZEKEFHA
        //lcdMapping.Add("", 'A');
        //lcdMapping.Add("", 'E');
        //lcdMapping.Add("", 'F');
        //lcdMapping.Add("", 'H');
        //lcdMapping.Add("", 'K');
        lcdMapping.Add("1110\r\n1001\r\n1001\r\n1110\r\n1010\r\n1001\r\n\r\n", 'R');
        lcdMapping.Add("1111\r\n0001\r\n0010\r\n0100\r\n1000\r\n1111\r\n\r\n", 'Z');
    }

    Dictionary<string, char> lcdMapping = new Dictionary<string, char>();

    public void SetNext(bool active)
    {
        pixels.Add(active);
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

    private char GetChar(int digit)
    {
        var arraylist = new List<BitArray>();
        for (int i = 0; i < 6; i++)
        {
            var bitarray = new BitArray(4);
            for (int j = 0; j < 4; j++)
            {
                bitarray[j] = pixels[i * Width + j + 5 * digit];
            }
            arraylist.Add(bitarray);
        }
        var matrix = new BitMatrix(arraylist);
        if(lcdMapping.ContainsKey(matrix.ToString()))
            return lcdMapping[matrix.ToString()];
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
