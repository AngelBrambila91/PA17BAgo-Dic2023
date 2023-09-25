// partial classes
using PA17B.Shared;
partial class Program
{
    // method so the delegate have someone to call
    static void Jared_Shout(object? sender, EventArgs e)
    {
        if(sender is null) return;
        Person? p = sender as Person;
        if(p is null) return;
        WriteLine($"{p.Name} is this Anger {p.AngerLevel}.");
    }
}