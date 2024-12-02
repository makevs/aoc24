using System.Text.RegularExpressions;
using CommonUtils;

namespace Day02;

class Program
{
    private static string FileContent => File.ReadAllText("day02.txt");
    private static readonly Regex R = RegexHelper.RemoveWhitespaces();
    private static int _safe = 0;

    static void Main(string[] args)
    {
        FileContent.Split("\n").ToList().ForEach(var =>
        {
            var line = R.Split(var);
            var lineSet = new HashSet<int>(line.Select(int.Parse));
            var lineSorted = line.ToList();
            if (lineSet.Count == lineSorted.Count) CheckSafes(lineSet);
        });
        Console.WriteLine(_safe);
    }

    private static void CheckSafes(HashSet<int> line)
    {
        int prev = line.First();
        bool ascending = line.Skip(1).First() > prev;
        foreach (var i in line.Skip(1))
        {
            var tmp = i - prev;
            if (Math.Abs(tmp) > 3) return;
            prev = i;
            if (tmp < 0 && ascending) return;
            if (!ascending && tmp > 0) return;
        }
        _safe++;
    }
}