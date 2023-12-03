using Interfaces;

var challengeNumber = args.ElementAtOrDefault(0) ?? "1";
var part = args.ElementAtOrDefault(1) ?? "1";

var className = $"Day{challengeNumber}";
var inputFileName = $"Data/Day{challengeNumber}.txt";

var type = Type.GetType($"Challenges.{className}");
if (type == null)
{
    Console.WriteLine($"Challenge {challengeNumber} not implemented");
    Environment.Exit(1);
}

try
{
    var input = File.ReadAllLines(inputFileName);
    var instance = Activator.CreateInstance(type);
    if (instance is IChallenge challengeInstance)
    {
        switch (part)
        {
            case "1":
                challengeInstance.Run1(input);
                break;
            case "2":
                challengeInstance.Run2(input);
                break;
            default:
                Console.WriteLine($"No part with number {part}");
                break;
        }
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Input file {inputFileName} not found");
    Environment.Exit(1);
}
