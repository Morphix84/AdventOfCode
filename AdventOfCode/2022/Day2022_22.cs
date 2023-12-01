﻿using Dijkstra.NET.Graph.Simple;
using Dijkstra.NET.ShortestPath;
using Microsoft.VisualBasic.FileIO;
using SheepTools;
using SheepTools.Extensions;
using SheepTools.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode;



public class Day2022_22 : BaseDay
{
    const string instructions = "24R38L36R1R28L11R39L5R36R41L31R9L16R4R36L38R31L38R17L18R31R6L40L2L19R41R27R24L33R21L27R7R11R27R11R2L46L34R3L23R29L45L13L25L37R46L21L20L22L4R31R36R10R13R39R27L27R20L12R49R21R44R50L5L9R13L11R26R44L48R44L24R44R46L49R20R13R27R4L25L5L39R10L29L12R3R39L11R49L13R45L2R3L50L12L33R22L20L2R37L32R32L1L41L26R1R10R25R49L48L24R48L27R43L28R7L30L15R46R32L11R7L2R24R32R16R16R10R28R11R19R5L45R4L20R49R24R44L31L46L29L32R2L48L33R36R44L41R37L17L35R40R14R48L45L16R42R30L22R28L17L2R24R22L37R3R6R32L4R1R42L33R44L9R22R19L16L17R17R37L45R46R1R34R45L10R22R12R28L42R31L27L33R24R29R24L40L41L26R9R23R11R20R13R28R20R16L17L14R48L34L12R16L12L30R42R15R19R20R15L39L8R33L31R35L12R29L37R42R4L41L30R15L12L6R27L10R23R17L10L23R35L48R47L46L12L27L22L46R50L37R45L37R21L8L2L18R46L3R23R18R32R37L27R43L39L23L40L27L22L22R30L30R35R38L40L50R8R9L20R29L27R9R2R16R32L4R49L44L13R17L47L29R46R22L27L7L37L17L7R2R3R24L47R50L17L17R31L23R19L6L42L42L43L5R42R36R47R13L7L42R22L2L5R31R49R43R35L19L29R11R3R29R34L41R45L28L39L14R31L4R23L35R40R32R39L36L6R13R37R23R21L14R37L35R12R50L35L5R25L45L8L8R14L24R25L29L20R3L36L16R22R2R19L23L8L3R43L22R27L31L48R21R2R7L27R36L5L15L5R8R41L46R28L26R45R42R9L38R35R38R22R18R13L40L11L5L44L27L28L23L37R8L40L13R35R48R18R29R7L9L10L45L12L45R21L28L36R49R18R40L41L8R2L40R9R10R42L23R19R12L27L33R42L30L25R12R5R36L14L14L4L24L39R14R37L1R16L28L44L12L45R21R7R5R1L7R48L38R1L49R15L26L12R36L7R46L24L28R39R7R33L49R34R37L34R40R18R44R26R48L31L50R48R33R15L48L2R36L46L12R38R10R20R48R38R25L9L23R39R28R50L47L47L49L39L46L8R15L19R27L48R48L25R46R27R1R15R15R46R41L50R25R38R33L41L18L43L35L43R18L29R8R7R35L43L46R32L17R31R39R30L32L20L10L34R25R11R10L49R31R45R1L18R30L15L48L21R8R22L35L49L7L6R23L4R31R42L7L20R41L24L40L46R2L45L40L26R41R10R34L25L20R10L34R44R2L16L8R30L2R47R31R47L32L41R33R3R39L30L24L47R12R23L40L9L22L28R30R24L25L22R47L18L21R41L40L9R23R32L16R6R36L17R45L38L10L30L11L31R28R6R8R43L8L45L45L10R21R26R32L9R6L13R29L25R16R24L5R34R18L28L16L21R8R9L33L13L47R29L17L45L12R38R46L43R42R26L41R5R34R1R48R38L29L2R48L32R16R48R14L8L13L32R4L49R46L45L40L30R23R44L24L6L3L29R29R7R19L14R10L44L22L4R27R27R46L8R46R46R18L32L30L14R50R42L38L3R32R20L50R44R40R39R18R18R12L8L31R17L10R31L45R14L15R49L31R37L20R17L43L43R18R10R38L30R13L35L22L30R3L46R7R14L23L1R6L27R25R17L7L23L39L45R45L40R7L21L7R36R32R4R49L20R38R35R44R35R26R50R46L24R2L6L46L9L43L27L34L38R36L23L6R12L28L50L8L50R20R31R24L14R13R21R43R17L17L42L43L29R1L26R43L46L47R20L36R34R49R11R21L33L42L35R37L32R8L17L43L10L27R41L29R12R28L44L9R47R12L25L43L18L7R4L5L9L13L25L37R14R11L3R6L17L1L41R10L33L44R50R43R6R38R48R2L15L31R40L40L42L14R23L14R9R47L44R12R26L21L17L20R46L30L29R3L14L6L47L27L18L16L9L23R4L1R34R35R10R23R37L2L8L25L26L34R17L5L3R25R20L50L4L46L10R5L17R23R30R15L39R44L8L19R43R19L15R14L25R19R50R33R15R9L46L47R34L5R38R42L22R43L46R47R24R11L40R14R47R5L28L1R1L45L20L25R40L44L21L49L17R45L34L3L2R13L30L37R35L36L33R18R34R14L25R14L25L3R13R12R50R16L20R8R49L23L4L3R29L16L19R34L8R15L5L38R38L8R7L18R44L29R19R21R25R23L42R49R6R19R48R37R32L2L14R22L24R28R50R5R10L45L24L12L48R16R47L26R1L38L48L12R6L35L31L3R13L26R7L1R19L47R15R29R2L16L24L7L49R26L44R12L30L25L32R43R48R12R9R4L43L32L22R22L6L18R44R42R39R11L26R37R42R12L11R10R14R44R4L47L3R25R4R50L36R3L4R36R5R38L35R4R37L35R23R43L47L33L1L2R19R14L33R26L1R27R45L32L29R5L28R10R50L1R14L4L31R47R2R27R39R18R50R50L45L15L17R21R40L19L15R14L9R44L45R28L17L19L41R35R27L6R43R16L34R4R28R12R45L33L44R40R36R36L23L25R35R24R1R30R1R50L23L18R36L33R15R2L10L5R41R10R39L15L33R19L37R12R33L6L20R48R24R38R13L29L32L41L27R27R15L18L22L1L7L18L33L33L4R22R12L35R38R40L43L40R45R7R50R4L29R26R7R42L34R2R39L28L41R33L35L40L31L4L40L25L30R44L45L40R22R13R50R4R5R36L21L29R24R10L6L45R15L40L26L10L10R18L22L29L46L6R33R31L44L42L28R49R29R39R45L18L20L34L38L16L1R50L21R25L15R16R22R33R43R34L32L23R33L26R6R16R31R1R30L35L28R4R1R19R25R40R8L46R1R45L28L16R25R44L44R37R26R11R7L7L33L2L8L31R46L31R33L45R31L19L4L30R8L16R20R24L43R41L6L20L43R15L30R35R45L18L35R23R5R25L35R21R48L13R3L18R34L27L13R47R18R10L4R28R37R8R28L16R43L4L8R19L34R9R40L47L32L10L38L34L25R34L27L26L34L32L45R29L12L36R14L42L39L25R15L23R45L36R32L7L22L42L46R40L17R30L33L33R12L48R19R24R36L38R41R22L24R4R15R7L30R2R5L11R22L25R25R9R45R4R10L22L15L6L41L33R5R21R16R21R21L23R40R21L29R43R35L9L50R1L25L40L41L12R22L33L47L15R21R3R47R2R16L8L20R43L48L13L46L38L45R20R37L21R7L5L8R4L35L17R23R34R19L22R25L9L37R39R21R22L30L38R48R17L18L21L31R9L3R20L14R25L4L33L10R16L26L10R31R37R17R36L18R27R31R24L36L38R46R23R24L5R39R11L19L39L25R10R32R2R43L7L5L12R50L25R13R27R19R26L12L40R3R13R30L48R7L37L1R41L14L13L14L13R14R48R16L41R48L24R6R50R29R24L44R19L12R50R5L40R7R22R27L24L18R14R37L9R36R12L36R20L41R14R43R12L41L34R45R23L5L27L9L14L43L29L8R23R13L50L2R36R1L31L48L12R9R45L26R28L1L29L29L8R29L7L39L24R23L46L1L9L6L22R46L10L32L50L16R38R46L9R15R40R12R41R25L47R29L34L37L49L35R12L25L12L22R9L46L27R43L11L3R15L33L49R24L33L34R21R20R11L16L22L50L26L15L6L39R12R30R30L7R29L45R23R34R7L2R50R33L21L39R15R8R24R50R34R7R50R44L17L16R24R47L26L17R35R32R15L13L13R25R12L42R33L42R6R47L50R1L8R8R48L41R33L27R29R8R3R35L3L14L15L19L13L46R42L5L11R25R25R41L30L1R14R40R47R41L48R13R4L21R16L50R37L20R15R6R33L27L13R11L27R50R7R46R3R35R38L19R41L5R6L22L18L8R2L33R1R20R5R27L23L23R14R1R50L3L41R22L14R35R43R46R30R32L34R14R43R39R39L26R16L42R50L12L36R50R28L35L1L40L35R41L6L26L34L21R49R42R35R40L4L15R46R13L30R35R22L48R17L43R13R21L49L8R42R38L23R44R38R12R31L28R50R25R2R12L32R7R17R8R36L31L28L22R12L25R14R27L44R7R11L11L17L48R6L8L40L22L1R39L39L5R8L29L22L44R41R5L38L21R2R34L44L1R6R9L3L11L1R16L30L14L44R10L48L35L2R45L23L19L31R1L41R19R10R7R12R6L15R2R22L34L14L33R19R43R16R12R36R18R22L17R3R7R9R7R15L48L8L35R46R20L30L2L48L29L8L23L2L7R33L27L15L31R39R19L44L34R28L9R43L13L12L33L18L49R29R18R20R46L20R37R15R9R13R37L20L41L14R17R46L4R26L34L1L29L17R46R4R11R35R26L31L10L14R39R17R46L29R30R50R9R43R48R14R46L33R34R44L21R42R3L28L40R29L36R11R5L26R4R21R3L14";
    public Day2022_22()
    {
        int maxLength = 0;
        TotalY = _input.Length;

        foreach (var l in _input)
        {
            if (l.Length > maxLength) maxLength = l.Length;
        }
        for (int i = 0; i < _input.Length; i++)
        {
            var l = _input[i];
            l = l.PadRight(maxLength);
            _input[i] = l;
        }
        foreach (var l in _input)
        {
            Debug.Assert(l.Length == maxLength);
        }
        TotalX = maxLength;
    }

    int TotalY = 0;
    int TotalX = 0;


    public override ValueTask<string> Solve_1()
    {
        var xStart = _input[0].IndexOf('.');
        IntPoint pos = new IntPoint(xStart, 0);
        Direction facing = Direction.Right;

        int instPtr = 0;
        while (instPtr < instructions.Length)
        {
            if (instructions[instPtr] == 'R')
            {
                facing = facing.TurnRight();
                instPtr++;
                continue;
            }
            else if (instructions[instPtr] == 'L')
            {
                facing = facing.TurnLeft();
                instPtr++;
                continue;
            }
            char[] seps = { 'L', 'R' };
            var next = instructions.IndexOfAny(seps, instPtr);
            if (next == -1)
                next = instructions.Length;
            var length = next - instPtr;
            int dist = 1;
            try
            {
                dist = int.Parse(instructions.Substring(instPtr, length));
            }
            catch (Exception e) { }
            instPtr += length;

            for (int i = 0; i < dist; i++)
            {
                //Try to move in this direction.
                var nextPos = pos.Move(facing, 1);
                bool isValid = false;
                char c = 'X';
                while (!isValid)
                {
                    isValid = true;
                    //Do we need to warp?
                    if (nextPos.X >= TotalX || nextPos.X < 0 || nextPos.Y < 0 || nextPos.Y >= TotalY)
                    {
                        isValid = false;
                        //Off the edge of the map, so wrap.
                        switch (facing)
                        {
                            case Direction.Right:
                                nextPos.X = 0;
                                break;
                            case Direction.Left:
                                nextPos.X = TotalX - 1;
                                break;
                            case Direction.Up:
                                nextPos.Y = TotalY - 1;
                                break;
                            case Direction.Down:
                                nextPos.Y = 0;
                                break;
                        }
                        continue;
                    }

                    Debug.Assert(nextPos.X < TotalX && nextPos.X >= 0 && nextPos.Y >= 0 && nextPos.Y < TotalY);
                    try
                    {
                        c = _input[nextPos.Y][nextPos.X];
                    }
                    catch (Exception) { }

                    if (c == ' ')
                    {
                        isValid = false;
                        //Off the edge of the map, so wrap.
                        switch (facing)
                        {
                            case Direction.Right:
                                nextPos.X++;
                                break;
                            case Direction.Left:
                                nextPos.X--;
                                break;
                            case Direction.Up:
                                nextPos.Y--;
                                break;
                            case Direction.Down:
                                nextPos.Y++;
                                break;
                        }
                        continue;
                    }
                }

                c = _input[nextPos.Y][nextPos.X];
                if (c == '.')
                    pos = nextPos;
                else if (c == '#')
                {
                    //We hit the wall and we don't need to continue this move.
                    break;
                }
                else
                {
                    //This should never happen
                    throw new Exception();
                }


            }
        }

        int col = pos.X + 1;
        int row = pos.Y + 1;
        int face = RangeHelpers.DirectionToInt(facing);
        int sum = (1000 * row) + (4 * col) + face;
        return new ValueTask<string>(sum.ToString());
    }

    char[,] A = new char[50, 50];
    char[,] B = new char[50, 50];
    char[,] C = new char[50, 50];
    char[,] D = new char[50, 50];
    char[,] E = new char[50, 50];
    char[,] F = new char[50, 50];

    List<char[,]> Cube = new();

    (int, int) AOffset = (50, 0);
    (int, int) BOffset = (100, 0);
    (int, int) COffset = (50, 50);
    (int, int) DOffset = (0, 100);
    (int, int) EOffset = (50, 100);
    (int, int) FOffset = (0, 150);

    (int, int) GetFaceOffsets(char face)
    {
        switch(face)
        {
            case 'A':
                return AOffset;
            case 'B':
                return BOffset;
            case 'C':
                return COffset;
            case 'D':
                return DOffset;
            case 'E':
                return EOffset;
            case 'F':
                return FOffset;
            default:
                throw new InvalidOperationException();
        }
    }
    void BuildFaces()
    {
        // AB
        // C
        //DE
        //F 
        Cube = new();
        foreach (var y in Enumerable.Range(0, 50))
        {
            foreach (var x in Enumerable.Range(50, 50))
            {
                A[x-AOffset.Item1, y-AOffset.Item2] = _input[y][x];
            }
        }

        foreach (var y in Enumerable.Range(0, 50))
        {
            foreach (var x in Enumerable.Range(100, 50))
            {
                B[x - BOffset.Item1, y - BOffset.Item2] = _input[y][x];
            }
        }

        foreach (var y in Enumerable.Range(50, 50))
        {
            foreach (var x in Enumerable.Range(50, 50))
            {
                C[x - COffset.Item1, y - COffset.Item2] = _input[y][x];
            }
        }

        foreach (var y in Enumerable.Range(100, 50))
        {
            foreach (var x in Enumerable.Range(0, 50))
            {
                D[x - DOffset.Item1, y - DOffset.Item2] = _input[y][x];
            }
        }

        foreach (var y in Enumerable.Range(100, 50))
        {
            foreach (var x in Enumerable.Range(50, 50))
            {
                E[x - EOffset.Item1, y - EOffset.Item2] = _input[y][x];
            }
        }

        foreach (var y in Enumerable.Range(150, 50))
        {
            foreach (var x in Enumerable.Range(0, 50))
            {
                F[x - FOffset.Item1, y - FOffset.Item2] = _input[y][x];
            }
        }
        Cube.Add(A);
        Cube.Add(B);
        Cube.Add(C);
        Cube.Add(D);
        Cube.Add(E);
        Cube.Add(F);
    }
    public override ValueTask<string> Solve_2()
    {
        BuildFaces();

        var CubeSides = new Dictionary<char, (char, int)[]>();
                                              // >         V         <         ^
        CubeSides.Add('A', new (char, int)[] { ('B', 0), ('C', 0), ('D', 2), ('F', 1) });
        CubeSides.Add('B', new (char, int)[] { ('E', 2), ('C', 1), ('A', 0), ('F', 0) });
        CubeSides.Add('C', new (char, int)[] { ('B', 3), ('E', 0), ('D', 3), ('A', 0) });
        CubeSides.Add('D', new (char, int)[] { ('E', 0), ('F', 0), ('A', 2), ('C', 1) });
        CubeSides.Add('E', new (char, int)[] { ('B', 2), ('F', 1), ('D', 0), ('C', 0) });
        CubeSides.Add('F', new (char, int)[] { ('E', 3), ('B', 0), ('A', 3), ('D', 0) });

        IntPoint pos = new IntPoint(0, 0);
        Direction facing = Direction.Right;
        char faceindex = 'A';

        int instPtr = 0;
        while (instPtr < instructions.Length)
        {
            if (instructions[instPtr] == 'R')
            {
                facing = facing.TurnRight();
                instPtr++;
                continue;
            }
            else if (instructions[instPtr] == 'L')
            {
                facing = facing.TurnLeft();
                instPtr++;
                continue;
            }
            char[] seps = { 'L', 'R' };
            var next = instructions.IndexOfAny(seps, instPtr);
            if (next == -1)
                next = instructions.Length;
            var length = next - instPtr;
            int dist = 1;
            try
            {
                dist = int.Parse(instructions.Substring(instPtr, length));
            }
            catch (Exception e) { }
            instPtr += length;

            for (int i = 0; i < dist; i++)
            {
                //Try to move in this direction.
                var nextPos = pos.Move(facing, 1);
                var nextFacing = facing;
                var nextFace = faceindex;

                bool isValid = false;
                char c = 'X';
                while (!isValid)
                {
                    isValid = true;
                    //Do we need to warp?
                    if (nextPos.X >= 50 || nextPos.X < 0 || nextPos.Y < 0 || nextPos.Y >= 50)
                    {
                        if (nextPos.X < 0)
                            nextPos.X += 50;
                        if(nextPos.Y < 0)
                            nextPos.Y += 50;
                        nextPos.X %= 50;
                        nextPos.Y %= 50;

                        isValid = false;
                        //Which Face do we need to go to.
                        var map = CubeSides[faceindex];
                        var facingIndex = RangeHelpers.DirectionToInt(facing);
                        nextFace = map[facingIndex].Item1;
                        int numRotations = map[facingIndex].Item2;

                        //What direction should we be?
                        // AB
                        // C
                        //DE
                        //F 

                        nextFacing = facing;
                        
                        for(int j = 0; j < numRotations; j++) 
                        { 
                            nextFacing = nextFacing.TurnRight(); 
                            nextPos = new IntPoint(50 - nextPos.Y - 1, nextPos.X);
                        }

                        continue;
                    }

                    Debug.Assert(nextPos.X < 50 && nextPos.X >= 0 && nextPos.Y >= 0 && nextPos.Y < 50);
                }
                int foo = nextFace - 'A';
                var minimap = Cube[foo];

                c = minimap[nextPos.X, nextPos.Y];
                if (c == '.')
                {
                    pos = nextPos;
                    facing= nextFacing;
                    faceindex = nextFace;
                }
                else if (c == '#')
                {
                    //We hit the wall and we don't need to continue this move.
                    break;
                }
                else
                {
                    //This should never happen
                    throw new Exception();
                }


            }
        }

        // AB
        // C
        //DE
        //F 

        //A-> B0 C0 D2 F1
        //B->E2 C1 A0 F0
        //C->B3 E0 D3 A0
        //D->E0 F0 A2 C1
        //E->B2 F1 D0 C0
        //F->E3 B0 A3 D0


        (int x, int y) offset = GetFaceOffsets(faceindex);
        int col = pos.X + 1 + offset.x;
        int row = pos.Y + 1 + offset.y;
        int face = RangeHelpers.DirectionToInt(facing);
        int sum = (1000 * row) + (4 * col) + face;
        return new ValueTask<string>(sum.ToString());
    }

}
