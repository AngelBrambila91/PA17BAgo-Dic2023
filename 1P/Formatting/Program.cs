using static System.Console;

// Margins
// { index [,alignment] numeric [: format String]}
string strawberryText = "Strawberry";
int strawberryCount = 1234;
string mangoText = "Mango";
int mangoCount = 43000;
// Headers
WriteLine("{0,-10} {1,6}",
arg0: "Name",
arg1: "Count");
// 1st Row
WriteLine("{0,-10} {1,6:N0}",
arg0: strawberryText,
arg1: strawberryCount);
// 2nd Row
WriteLine("{0,-10} {1,6:N0}",
arg0: mangoText,
arg1: mangoCount);

#region Getting Input from User
    Write("Type your first name and press Enter: ");
    string firstName = ReadLine();
    Write("Type your age and press Enter: ");
    string age = ReadLine();
    WriteLine($"You look good to for {age}");
#endregion

#region Infer Types
    // Pros : Can transfer data quickly
    // Cons : Do not infer the methods and properties
    object objectNumber = 13;
    WriteLine(objectNumber.GetType());

    // Pros : Allocates memory on CPU
    // Cons : Don't deallocate the memory
    dynamic nameCaps = "MAURICIOOOOOOO";
    
    // Pros : Until definition and usage, allocates memory on RAM
    // Cons : Really complex types can confuse var
    var  nameLower = "diego";
#endregion