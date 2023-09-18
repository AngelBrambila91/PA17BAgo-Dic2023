using PA17B.Shared;

Person kaleb = new();
WriteLine($"Kaleb is : {kaleb.ToString()} ");

kaleb.Name = "Kaleb";
kaleb.DateOfBirth = new DateTime(2005, 12, 21);
WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}",
arg0:kaleb.Name,
arg1:kaleb.DateOfBirth);