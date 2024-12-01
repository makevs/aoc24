using System.Text.RegularExpressions;

namespace Day01;

internal partial class Program
{
    protected static string FileContent => File.ReadAllText("day01.txt");
    private static List<int> _right = new List<int>();
    private static List<int> _left = new List<int>();
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
            _left.Add(int.Parse(split[0]));
            _right.Add(int.Parse(split[1]));
        });
        _left.Sort();
        _right.Sort();
    }
    
    private static void CalculateDistance()
    {
        for (int i = 0; i < _left.Count; i++)
        {
            _distance += Math.Abs(_left[i] - _right[i]);
        }
    }
    
    private static void SimilarityScore()
    {
        foreach (int i in _left)
        {
            _similarity += (i * _right.Count(x => x == i));
        }
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex MyRegex();
}