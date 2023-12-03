using Interfaces;

namespace Challenges;

public class Day1 : IChallenge
{
    private static readonly List<(string, char)> digitStrings =
    [
        ("one", '1'),
        ("two", '2'),
        ("three", '3'),
        ("four", '4'),
        ("five", '5'),
        ("six", '6'),
        ("seven", '7'),
        ("eight", '8'),
        ("nine", '9'),
    ];

    public void Run1(IEnumerable<string> input)
    {
        var sum = input.Sum(row =>
        {
            var firstDigit = row.First(char.IsAsciiDigit);
            var lastDigit = row.Last(char.IsAsciiDigit);
            var numberString = $"{firstDigit}{lastDigit}";
            return int.Parse(numberString);
        });
        Console.WriteLine($"The answer is {sum} :)");
    }

    public void Run2(IEnumerable<string> input)
    {
        var sum = input.Sum(row =>
        {
            var firstDigit = row.First(char.IsAsciiDigit);
            var lastDigit = row.Last(char.IsAsciiDigit);

            var firstDigitIndex = row.IndexOf(firstDigit);
            var lastDigitIndex = row.LastIndexOf(lastDigit);
            var head = row[..firstDigitIndex];
            var tail = row[lastDigitIndex..];

            var headStringDigitMatches = digitStrings.Where(s => head.Contains(s.Item1));
            var tailStringDigitMatches = digitStrings.Where(s => tail.Contains(s.Item1));

            if (headStringDigitMatches.Any())
            {
                var ordered = headStringDigitMatches.OrderBy(d => head.IndexOf(d.Item1));

                firstDigit = ordered.First().Item2;
            }

            if (tailStringDigitMatches.Any())
            {
                // Fix the tail thingy here as well somehow
                var ordered = tailStringDigitMatches.OrderByDescending(
                    d => tail.LastIndexOf(d.Item1)
                );

                lastDigit = ordered.First().Item2;
            }

            var numberString = $"{firstDigit}{lastDigit}";
            return int.Parse(numberString);
        });
        Console.WriteLine($"The sum is {sum}");
    }
}
