WriteLine($"There are {args.Length} arguments");

foreach (var argument in args)
{
    WriteLine(argument);
}

if(args.Length < 3)
{
    WriteLine("You must enter at least 2 colors and cursor size e.g: ");
    WriteLine("dotnet run red yellow 50");
    return; //stop Running
}
// first color
ForegroundColor = (ConsoleColor)Enum.Parse(
    enumType:typeof(ConsoleColor), 
    value:args[0],
    ignoreCase: true);
// second color
BackgroundColor = (ConsoleColor)Enum.Parse(
    enumType:typeof(ConsoleColor),
    value:args[1],
    ignoreCase: true);
// cursor size
try
{
    CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException)
{
    WriteLine("The current platform does not support changing the size of the cursor");
}