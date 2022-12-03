using System.Text.RegularExpressions;

namespace AdventOfCode;

record Coord(int X, int Y, int Z)
{
    public int Distance(Coord other) => Math.Abs(other.X - X) + Math.Abs(other.Y - Y) + Math.Abs(other.Z - Z);

    public Coord Vector(Coord other) => new(other.X - X, other.Y - Y, other.Z - Z);

    internal Coord Translate(Coord translation) => new(X + translation.X, Y + translation.Y, Z + translation.Z);
}
public class Day2021_19 : BaseDay
{
    private Dictionary<int, HashSet<Coord>> _readings;
    private HashSet<Coord> _beaconMap;
    private Dictionary<int, Coord> _scanners;
    public Day2021_19()
    {
        ParseInput();
    }

    private void ParseInput()
    {
        _readings = new();
        HashSet<Coord> scannerReadings = null;

        for (int i = 0; i < _input.Length; i++)
        {
            string line = _input[i];
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            else if (line.StartsWith("--- "))
            {
                int scannerId = int.Parse(Regex.Matches(line, @"(\d+)")[0].ToString());
                scannerReadings = new HashSet<Coord>();
                _readings.Add(scannerId, scannerReadings);
            }
            else if (scannerReadings != null)
            {
                string[] parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                scannerReadings.Add(new Coord(
                    int.Parse(parts[0].ToString()),
                    int.Parse(parts[1].ToString()),
                    int.Parse(parts[2].ToString())));
            }
        }

        _beaconMap = new HashSet<Coord>(_readings[0]);
        _scanners = new()
        {
            [0] = new Coord(0, 0, 0)
        };
    }
    private void MapSpace()
    {
        Dictionary<Coord, Coord> vectors = ReadVectors(_beaconMap);

        Queue<int> scannersToCheck = new();
        for (int i = 1; i < _readings.Count; i++)
        {
            scannersToCheck.Enqueue(i);
        }

        while (scannersToCheck.Count > 0)
        {
            int scanner = scannersToCheck.Dequeue();
            var readings = _readings[scanner];

            Func<Coord, Coord> scannerRotation = null;
            Coord translation = null;
            foreach (var rotation in GetRotations())
            {
                if (TestRotation(vectors, readings, rotation, out translation))
                {
                    scannerRotation = rotation;
                    break;
                }
            }

            if (scannerRotation != null)
            {
                var rotated = RotateScannerReadings(readings, scannerRotation);
                var translated = TranslateScannerReadings(rotated, translation);

                foreach (Coord beacon in translated)
                {
                    _beaconMap.Add(beacon);
                }

                vectors = ReadVectors(_beaconMap);

                _scanners.Add(scanner, translation);
            }
            else
            {
                scannersToCheck.Enqueue(scanner);
            }
        }
    }

    private static Dictionary<Coord, Coord> ReadVectors(HashSet<Coord> beaconMap)
    {
        Dictionary<Coord, Coord> vectors = new();
        foreach (var p1 in beaconMap)
        {
            foreach (var p2 in beaconMap)
            {
                if (p1 == p2) continue;
                Coord vector = p2.Vector(p1);
                if (!vectors.ContainsKey(vector))
                {
                    vectors.Add(vector, p2);
                }
            }
        }
        return vectors;
    }

    private static bool TestRotation(Dictionary<Coord, Coord> masterVectors, HashSet<Coord> beacons, Func<Coord, Coord> rotation, out Coord translation)
    {
        int matchCount = 0;
        foreach (var p1 in beacons)
        {
            Coord p1Rotated = rotation(p1);
            foreach (var p2 in beacons)
            {
                if (p1 == p2) continue;

                Coord p2Rotated = rotation(p2);
                Coord vector = p1Rotated.Vector(p2Rotated);

                if (masterVectors.ContainsKey(vector) && ++matchCount == 11)
                {
                    translation = p1Rotated.Vector(masterVectors[vector]);
                    return true;
                }
            }
        }

        translation = null;
        return false;
    }

    private static HashSet<Coord> RotateScannerReadings(HashSet<Coord> beacons, Func<Coord, Coord> scannerRotation)
    {
        HashSet<Coord> rotatedBeacons = new();
        foreach (Coord beacon in beacons)
        {
            rotatedBeacons.Add(scannerRotation(beacon));
        }
        return rotatedBeacons;
    }

    private static HashSet<Coord> TranslateScannerReadings(HashSet<Coord> beacons, Coord translation)
    {
        HashSet<Coord> translatedBeacons = new();
        foreach (Coord beacon in beacons)
        {
            translatedBeacons.Add(beacon.Translate(translation));
        }
        return translatedBeacons;
    }

    private static IEnumerable<Func<Coord, Coord>> GetRotations()
    {
        yield return v => new(v.X, -v.Z, v.Y);
        yield return v => new(v.X, -v.Y, -v.Z);
        yield return v => new(v.X, v.Z, -v.Y);

        yield return v => new(-v.Y, v.X, v.Z);
        yield return v => new(v.Z, v.X, v.Y);
        yield return v => new(v.Y, v.X, -v.Z);
        yield return v => new(-v.Z, v.X, -v.Y);

        yield return v => new(-v.X, -v.Y, v.Z);
        yield return v => new(-v.X, -v.Z, -v.Y);
        yield return v => new(-v.X, v.Y, -v.Z);
        yield return v => new(-v.X, v.Z, v.Y);

        yield return v => new(v.Y, -v.X, v.Z);
        yield return v => new(v.Z, -v.X, -v.Y);
        yield return v => new(-v.Y, -v.X, -v.Z);
        yield return v => new(-v.Z, -v.X, v.Y);

        yield return v => new(-v.Z, v.Y, v.X);
        yield return v => new(v.Y, v.Z, v.X);
        yield return v => new(v.Z, -v.Y, v.X);
        yield return v => new(-v.Y, -v.Z, v.X);

        yield return v => new(-v.Z, -v.Y, -v.X);
        yield return v => new(-v.Y, v.Z, -v.X);
        yield return v => new(v.Z, v.Y, -v.X);
        yield return v => new(v.Y, -v.Z, -v.X);
    }
    public override ValueTask<string> Solve_1()
    {
        MapSpace();
        return new ValueTask<string>(_beaconMap.Count.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        ParseInput();
        MapSpace();

        HashSet<(int, int)> tested = new();
        int maxDistance = 0;

        foreach ((int scannerId, Coord scannerFrom) in _scanners)
        {
            foreach ((int scannerToId, Coord scannerTo) in _scanners)
            {
                if (scannerId == scannerToId)
                {
                    continue;
                }

                var key1 = (scannerId, scannerToId);
                var key2 = (scannerToId, scannerId);

                if (tested.Contains(key1) || tested.Contains(key2))
                {
                    continue;
                }

                int distance = scannerFrom.Distance(scannerTo);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }

                tested.Add(key1);
            }
        }
        return new ValueTask<string>(maxDistance.ToString());
    }
}
