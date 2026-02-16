Console.Write("Write a decimal value :");
double d = Convert.ToDouble(Console.ReadLine());
int integr = (int)d;
int r = (int)Math.Round(d);
String formatted = d.ToString("F3");
Console.WriteLine($"As integer (truncated): {integr}");
Console.WriteLine($"As rounded integer: {r}");
Console.WriteLine($"As string (3 decimals): {formatted}");

// Takes a decimal number from user
// Displays it as:
// Integer (truncated)
// Rounded integer (Math.Round)
// String with 3 decimal places