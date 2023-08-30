using static System.Convert;
// Implicit Convertion
// Explicit Convertion

int a = 10;
double b = a;
WriteLine(b);

// Explicit
double c = 9.8;
int d = (int)c;
WriteLine(d);

long e = 10;
int f = (int)e;
WriteLine(f);
e = long.MaxValue;
f = (int) e;
WriteLine($"e is {e:N0} and f is {f:N0}");
e = 5_000_000_000;
f = (int) e;
WriteLine($"e is {e:N0} and f is {f:N0}");

// System.Convert
double g = 9.8;
int h = ToInt32(g);
WriteLine($"g is {g:N0} and h is {h:N0}");

int number = 12;
WriteLine(number.ToString());
bool boolean = true;
WriteLine(boolean.ToString());
DateTime today = DateTime.Now;
WriteLine(today.ToString());
object obj = new();
WriteLine(obj.ToString());
