// Unary Operators
int a = 3;
a++;
a--;
++a;
--a;
// Binary Operators
decimal b = 11;
decimal c = 3;
WriteLine($"b + c = {b + c}");
WriteLine($"b - c = {b - c}");
WriteLine($"b * c = {b * c}");
WriteLine($"b / c = {b / c}");
WriteLine($"b % c = {b % c}");

// Assignment Operators
int d = 6;

WriteLine($"d += 3 = {d += 3}");
WriteLine($"d -= 3 = {d -= 3}");
WriteLine($"d *= 3 = {d *= 3}");
WriteLine($"d /= 3 = {d /= 3}");

// Logical Operators
// & |
bool e = true;
bool f = false;
WriteLine("AND e    |      f");
WriteLine($"e| {e & e,-5} | {e & f,-5}");
WriteLine($"f| {f & e,-5} | {f & f,-5}");
WriteLine();

WriteLine("OR TABLE");
WriteLine("OR e    |      f");
WriteLine($"e| {e | e,-5} | {e | f,-5}");
WriteLine($"f| {f | e,-5} | {f | f,-5}");

WriteLine("XOR TABLE");
WriteLine("XOR e    |      f");
WriteLine($"e| {e ^ e,-5} | {e ^ f,-5}");
WriteLine($"f| {f ^ e,-5} | {f ^ f,-5}");

// Conditional Operators
// && ||
static bool DoStuff()
{
    WriteLine("I'm working... wink wink");
    return true;
}

WriteLine($"e & DoStuff() = {e & DoStuff()}");
WriteLine($"f & DoStuff() = {f & DoStuff()}");
WriteLine($"e && DoStuff() = {e && DoStuff()}");
WriteLine($"f && DoStuff() = {f && DoStuff()}");

// Miscellaneous Operators
// sizeof(), nameof(), getType()
int age = 12;
char firstDigit = age.ToString()[0];
// () is the Invocation Operator
// [] is the Index Operator
// . is the Access Operator
// = is the Assignment Operator