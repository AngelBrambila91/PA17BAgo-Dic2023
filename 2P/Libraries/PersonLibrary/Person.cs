namespace PA17B.Shared;
using System.Collections.Generic;
using System.Xml.Serialization; // [xmlAttributes]

public class Person
{
    // Composition
    // Let the same Object take care of the initialization
    // of the FUCKING fields
    public Person()
    {

    }
    // public Person(string Name, DateTime dateOfBirth, FavoriteFood favoriteFood, bool wantChildren)
    // {
    //     this.Name = Name;
    //     this.DateOfBirth = dateOfBirth;
    //     this.favoriteFood = favoriteFood;
    //     if(wantChildren)
    //     {
    //         Children = new();
    //     }
    // }

    public Person(decimal initialValue)
    {
        Salary = initialValue;
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
    [XmlAttribute("fname")]
    public string? Name { get; set; }
    [XmlAttribute("lname")]
    public string? LastName { get; set; }
    [XmlAttribute("dob")]
    public DateTime DateOfBirth { get; set; }
    protected decimal Salary { get; set; }
    //public FavoriteFood favoriteFood;
    // feature : add children to person
    public HashSet<Person>? Children { get; set; }
    public BankAccount bankAccount = new();

    // 1st Step of delegates
    // Create the method to call
    public int MethodIWantToCall(string input)
    {
        return input.Length;
    }

    // 2nd example of delegate using a primitive delegate
    // Rule N1 of delegates : ALL DELEGATES, check the signature of the method
    // Signature: Return type, Parameters
    public delegate int DelegateWithMatchingSignature (string s);

    // 3rd example , using delegates as Events
    //public delegate void EventHandler(object? sender, EventArgs e);

    // delegate field
    // public EventHandler? Shout;
    // // data field
    // public int AngerLevel;
    // // Method that triggers everything
    // public void Poke()
    // {
    //     AngerLevel++;
    //     if(AngerLevel >= 3)
    //     {
    //         // if something is listening
    //         if(Shout != null)
    //         {
    //             // call the messenger, call the delegate
    //             Shout(this, EventArgs.Empty);
    //         }
    //     }
    // }
}
