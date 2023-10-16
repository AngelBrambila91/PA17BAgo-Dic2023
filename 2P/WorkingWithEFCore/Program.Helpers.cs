partial class Program
{
    static void SectionTitle (string title)
    {
        ConsoleColor backgoundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Green;
        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");
        ForegroundColor = backgoundColor;
    }

    static void Fail (string message)
    {
        ConsoleColor backgoundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Red;
        WriteLine("*");
        WriteLine($"* {message}");
        WriteLine("*");
        ForegroundColor = backgoundColor;
    }

    static void Info(string message)
    {
        ConsoleColor backgoundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine($"Info > ({message})");
        ForegroundColor = backgoundColor;
    }
}