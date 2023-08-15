using static System.Console; // System Console = new System();
#region Native Types
// native types
int number = 1;
float number2 = 2.3F;
double number3 = 3.9;
decimal number4 = 5.3M;
char character = 'A';
#endregion


// complex types
string Name = "Gaby";
DateTime today = DateTime.Now;

// Print by position or parameter
// ALL coming or going to the terminal IS TEXT (String)
WriteLine("Hello {0} it's a really nice day and i have a number , its {1}", arg0: Name, arg1: number2);

// By Interpolation
WriteLine($"Hello {Name}, today is : {today} and my number is {number3}");

#region SizeOf
// sizeof()
WriteLine($"Size of Int is : {sizeof(int)}Bytes, Min Value is {int.MinValue} and Max Value is : {int.MaxValue} and Min Values is : {int.MinValue}");
WriteLine($"Size of Float is : {sizeof(float)}Bytes, Min Value is {float.MinValue} and Max Value is : {float.MaxValue}");
WriteLine($"Size of Double is : {sizeof(double)}Bytes, Min Value is {double.MinValue:N0} and Max Value is : {double.MaxValue:N0}");
WriteLine($"Size of Decimal is : {sizeof(decimal)}Bytes, Min Value is {decimal.MinValue} and Max Value is : {decimal.MaxValue}");
WriteLine($"Size of Char is : {sizeof(char)}Bytes, Min Value is {char.MinValue} and Max Value is : {char.MaxValue}");
WriteLine($"Size of Long is : {sizeof(long)}Bytes, Min Value is {long.MinValue} and Max Value is : {long.MaxValue}");
#endregion