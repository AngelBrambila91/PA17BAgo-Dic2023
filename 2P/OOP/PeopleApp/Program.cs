using PA17B.Shared;
using System.Collections.Generic;

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
