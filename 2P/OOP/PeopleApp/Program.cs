using PA17B.Shared;
using System.Collections.Generic;
using static PA17B.Shared.Person;

Person kaleb = new(Name: "Kaleb", 
dateOfBirth: new DateTime(2005, 12, 21), 
favoriteFood: FavoriteFood.Tacos, 
wantChildren: true);
WriteLine($"Kaleb is : {kaleb.ToString()} ");

WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}",
arg0:kaleb.Name,
arg1:kaleb.DateOfBirth);
kaleb.Children.Add(
    new Person {
        Name = "Kaleb Jr",
        DateOfBirth = new DateTime(2023, 09, 18)
    }
);

// Iterate through collection Children
// foreach , only applicable on collection that has NEXT pointer
// int[] arr = new int[] { 1, 2, 3, 4, 5, 9 };
// foreach (item iterator in COLLECTION)
foreach (var children in kaleb.Children)
{
    WriteLine($"A children of {kaleb.Name} is {children.Name}");
}

Person perla = new Person(Name: "Perla", 
dateOfBirth: new DateTime(2004, 06, 04), 
favoriteFood: FavoriteFood.Pozole,
wantChildren: false);

BankAccount.InterestRate = 0.012M;
perla.bankAccount.AccountName = "Retiro a los 40";
perla.bankAccount.Balance = 1600M;
WriteLine($"Perla has invested {perla.bankAccount.Balance * BankAccount.InterestRate}");

// Dictionaries
// Can have multiple keys, and duplicated keys
// Can have multiples values and duplicated ones

// Generics usually are collections
//<TKey, TValue>
Dictionary<int, string> lookUpIntString = new();// Tuple
lookUpIntString.Add(0, "Alpha");
lookUpIntString.Add(2, "Delta");
lookUpIntString.Add(3, "Gamma");
lookUpIntString.Add(4, "Tetha");
// Rule N1 : Generic Types need the key to be the SAME type
//lookUpIntString.Add(perla, "Alpha"); // so ... this shit is an error
// specifically cannot convert from Person to int

foreach (var key in lookUpIntString.Keys)
{
    WriteLine($"Key is : {key} has value of : {lookUpIntString[key]}");
}

// Delegates
// Anonymous calls
// Is a Pointer that has a reference of a function
// is a Variable that calls a method
Person Jared = new();
Jared.Name = "Jared";
int answer = Jared.MethodIWantToCall("Jared");
WriteLine(answer);

// Using a delegate
DelegateWithMatchingSignature d = new(Jared.MethodIWantToCall);
int answer2 = d("Perla");

// Using 3rd example of delegates , assign and trigger
// assign the delegate to the method i want to execute
Jared.Shout = Jared_Shout;
// Trigger
Jared.Poke();
Jared.Poke();
Jared.Poke();
Jared.Poke();
Jared.Poke();
