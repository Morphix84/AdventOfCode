namespace AdventOfCode;

class File
{
    public int Size { get; set; }
    public string Name { get; set; }
}
class Folder
{
    public string Name { get; set; }
    public List<Folder> Subfolders { get; set; }
    public List<File> Files { get; set; }
    public Folder Parent { get; set; }

    public int TotalSize
    {
        get
        {
            return Files.Sum(f => f.Size) + Subfolders.Sum(f => f.TotalSize);
        }
    }
    public Folder()
    {
        Subfolders = new List<Folder>();
        Files = new List<File>();
    }
}


public class Day2022_07 : BaseDay
{
    Folder root = new Folder();
    Folder current;
    public Day2022_07()
    {
        BuildFolders();
    }

    void BuildFolders()
    {
        foreach (var item in _input)
        {
            if (IsCommand(item))
            {
                var cmd = GetCommand(item);
                switch (cmd)
                {
                    case "ls":
                        break;
                    case "cd":
                        var path = item.Split(' ')[2];
                        if (path == "..")
                        {
                            current = current.Parent;

                        }
                        else if (path == "/")
                        {
                            if (root == null)
                            {
                                root = new Folder() { Name = "/" };
                            }
                            current = root;
                        }
                        else
                        {
                            current = current.Subfolders.Where(x => x.Name == path).FirstOrDefault();
                        }
                        break;
                    default: throw new NotImplementedException();
                }
            }
            else //Must be in ls
            {
                var path = item.Split(' ');
                bool IsFolder = path[0] == "dir";
                if (IsFolder)
                {
                    if(current.Subfolders.Where(x => x.Name == path[1]).Count() == 0)
                        current.Subfolders.Add(new Folder() { Name = path[1], Parent = current });
                }
                else
                {
                    if (current.Files.Where(x => x.Name == path[1]).Count() == 0)
                        current.Files.Add(new File() { Name = path[1], Size = int.Parse(path[0]) });
                }
            }

        }
        current = root;
    }

    bool IsCommand(string s)
    {
        return (s[0] == '$');
    }

    string GetCommand(string s)
    {
        return s.Split(' ')[1];
    }

    int SumTotalSizes(int limit)
    {
        Folder visitor = root;
        int total = 0;
        List<Folder> childrenToVisit = new List<Folder>();
        while(true)
        {
            var ts = visitor.TotalSize;
            total += ts <= limit ? ts : 0;
            childrenToVisit.AddRange(visitor.Subfolders);
            if (childrenToVisit.Count == 0)
                break;
            else
            {
                visitor = childrenToVisit[0];
                childrenToVisit.RemoveAt(0);
            }

        }

        return total;
    }

    public override ValueTask<string> Solve_1()
    {
        var answer = SumTotalSizes(100000);
        return new ValueTask<string>(answer.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        current = root;
        int diskSize = 70000000;
        int spaceNeeded = 30000000;
        int freeSpace = diskSize - root.TotalSize;
        int spaceToFree = spaceNeeded - freeSpace;

        List<Folder> childrenToVisit = new List<Folder>();
        int best = int.MaxValue;
        Folder visitor = root;
        while (true)
        {
            var ts = visitor.TotalSize;
            if (ts < best && ts > spaceToFree)
                best = ts;

            childrenToVisit.AddRange(visitor.Subfolders);
            if (childrenToVisit.Count == 0)
                break;
            else
            {
                visitor = childrenToVisit[0];
                childrenToVisit.RemoveAt(0);
            }

        }

        return new ValueTask<string>(best.ToString());
    }

}
