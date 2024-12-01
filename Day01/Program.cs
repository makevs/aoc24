using System.Text.RegularExpressions;

namespace Day01;

internal abstract partial class Program
{
    private static string FileContent => File.ReadAllText("day01.txt");
    private static readonly List<int> Right = [];
    private static readonly List<int> Left = [];
    private static double _distance = 0;
    private static double _similarity = 0;
    
    private static void Main()
    {
        NumbersToList();
        CalculateDistance();
        Console.WriteLine(_distance);
        SimilarityScore();
        Console.WriteLine(_similarity);
    }
    
    private static void NumbersToList()
    {
        FileContent.Split("\n").ToList().ForEach(var =>
        {
            var split = MyRegex().Split(var);
            Left.Add(int.Parse(split[0]));
            Right.Add(int.Parse(split[1]));
        });
        Left.Sort();
        Right.Sort();
    }
    
    private static void CalculateDistance()
    {
        for (int i = 0; i < Left.Count; i++)
        {
            _distance += Math.Abs(Left[i] - Right[i]);
        }
    }
    
    private static void SimilarityScore()
    {
        foreach (int i in Left)
        {
            _similarity += (i * Right.Count(x => x == i));
        }
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex MyRegex();
}