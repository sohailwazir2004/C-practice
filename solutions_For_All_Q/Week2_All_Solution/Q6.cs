Console.Write("Enter a year: ");
int year = int.Parse(Console.ReadLine());

bool isLeapYear = (year % 4 == 0 && year % 100 == 0) || (year % 400 == 0);

if (isLeapYear)
{
    Console.WriteLine($"{year} is a leap year.");
}
else
{
    Console.WriteLine($"{year} is not a leap year.");
}