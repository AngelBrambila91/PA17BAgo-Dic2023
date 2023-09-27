partial class Program
{
    /// <summary>
    /// This is a helper to color a title
    /// </summary>
    /// <param name="title"></param>
    static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");
        ForegroundColor = previousColor;
    }
}