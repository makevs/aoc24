namespace Day02;

class Program
{
    private static string FileContent => File.ReadAllText("day02.txt");
    private static int _safe = 0;

    static void Main(string[] args)
    {
        FileContent.Split("\n").ToList().ForEach(line =>
        {
            var lineIntArray = line.Split(' ').Select(int.Parse).ToArray();
            CheckSafesPart2(lineIntArray);
        });
        Console.WriteLine(_safe);
    }

    private static void CheckSafesPart2(int[] lineIntArray)
    {
        // First check if the report is already safe
        if (CheckSafes(lineIntArray))
        {
            _safe++;
            return;
        }
            
        for (var i = 0; i < lineIntArray.Length; i++)
        {
            var dampenerArray = lineIntArray.Where((val, idx) => idx != i).ToArray();
            if (!CheckSafes(dampenerArray)) continue;
            _safe++;
            return;
        }
    }

    private static bool CheckSafes(int[] levels)
    {
        var ascending = true;
        var descending = true;

        for (var i = 1; i < levels.Length; i++)
        {
            var diff = levels[i] - levels[i - 1];
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3) return false;
            
            descending = diff > 0? descending : false;
            ascending = diff < 0? ascending : false;
            if (!ascending && !descending) return false;
        }
        return true;
    }
}