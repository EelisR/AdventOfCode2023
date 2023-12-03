using Interfaces;

var challenge = args.ElementAtOrDefault(0) ?? "1";

var className = $"Day{challenge}";
var inputFileName = $"Data/Day{challenge}.txt";

var type = Type.GetType($"Challenges.{className}");
if (type == null)
{
    Console.WriteLine($"Challenge {challenge} not implemented");
    Environment.Exit(1);
}

try
{
    var input = File.ReadAllLines(inputFileName);
    var instance = Activator.CreateInstance(type);
    if (instance is IChallenge challengeInstance)
    {
        challengeInstance.Run(input);
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Input file {inputFileName} not found");
    Environment.Exit(1);
}
