public class Animal
{
    // nullable operator
    public string? Name;
    public DateTime Born;
    public byte Legs;
    public bool IsDomestic;
}

public class Pig : Animal
{
}

public class Cat : Animal
{
    public bool IsPoisonous;
}

public class Dog : Animal
{
    public uint Age;
}