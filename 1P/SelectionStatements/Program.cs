// if (expression)
// {
//     here if true
// }
// else if (epxression)
// {

// }
// else
// {
//     if no one was true
// }
string password = "GossipGirl";
if(password.Length < 10)
{
    WriteLine("Your password is too short. Use at least 10 characters");
}
else
{
    WriteLine("You password is strong");
}

// pattern matching with if
object o = "3";
int j = 4;
if (o is int i/*reference out*/)
{
    WriteLine($"i * j = {i} * {j}");
}
else
{
    WriteLine("o is not the correct type of data");
}

// switch
int number = Random.Shared.Next(1,7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break;
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3:
    case 4:
        WriteLine("Three or Four");
        goto case 2;
    case 5:
        goto A_Label;
    default:
    WriteLine("Default");
    break;
}
WriteLine("After the switch");
A_Label:
WriteLine("After A_Label");

//pattern match switch
Animal?[] animals = new Animal?[]
{
    new Cat {
        Name = "Pancha",
        Born = new(year: 2011, month: 1, day:21),
        IsDomestic = true,
        IsPoisonous = false,
        Legs = 4
    },
    new Pig {
        Name = "Oreo",
        Born = new (year:2012, month:4, day:23),
        IsDomestic = true,
        Legs = 4
    },
    new Dog {
        Name = "Pato",
        Born = new (year:1999, month:4, day:12),
        IsDomestic = true,
        Legs = 3
    }
};

foreach(Animal? animal in animals)
{
    // pattern matching switch
    string message = String.Empty;
    #region Old Switch
    switch (animal)
    {
        case Cat fourLegCat when fourLegCat.Legs == 4:
            message = $"The cat named {fourLegCat.Name} has four legs.";
            break;
        case Pig oreo when oreo.Name== "oreo":
            message = $"The pig is named {oreo.Name} and is CUTE AF";
            break;
        case Dog pato when pato.Age == 10 && pato.Legs == 3:
            message = $"You should say goodbye to {pato.Name}";
            break;
        case Cat cat when !cat.IsPoisonous:
            message = $"Do not bother that michi";
            break;
        case null:
            message = "Do not have info of that animal";
            break;
    }
    #endregion
    
    #region Simplified switch
    message = animal switch 
    {
        Cat threeLegedCat when threeLegedCat.Legs == 3 
        => $"The cat {threeLegedCat.Name} has three legs.",
        Pig chanchito when chanchito.IsDomestic
        => $"You have a wild boar there mate",
        null => "That animal is null",
        _ => "I couldn't find that animal"
    };
    #endregion
    WriteLine(message);
}



