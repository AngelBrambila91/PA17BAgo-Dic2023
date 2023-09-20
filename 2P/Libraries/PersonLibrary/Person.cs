namespace PA17B.Shared;
using System.Collections.Generic;

public class Person
{
    // Composition
    // Let the same Object take care of the initialization
    // of the FUCKING fields
    public Person()
    {

    }
    public Person(string Name, DateTime dateOfBirth, FavoriteFood favoriteFood, bool wantChildren)
    {
        this.Name = Name;
        this.DateOfBirth = dateOfBirth;
        this.favoriteFood = favoriteFood;
        if(wantChildren)
        {
            Children = new();
        }
    }
    /*
     Constructor:  its called whe
     new () is executed, instance

     Member : data inside the class
     public int number = 0;
     public int getNumber () { return this.number };
     public void setNumber (int number)
     {
        thisk.number = number;
     }

     Property: Still data on the class
     string Name {get; set;}
     Simple Property
     Full Property

     Index : []

     Operators : + - & ^ | =>
    */

    //fields
    public string? Name;
    public DateTime DateOfBirth;

    public FavoriteFood favoriteFood;
    // feature : add children to person
    public List<Person>? Children;
    public BankAccount bankAccount = new();
}
