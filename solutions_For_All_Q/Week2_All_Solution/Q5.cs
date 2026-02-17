Console.Write("Enter First number ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter second number ");
int b = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter third number ");
int c = Convert.ToInt32(Console.ReadLine());

int largest;

if (a >= b && a >= c)
{
    largest = a;
}
else if (b >= a && b >= c)
{
    largest = b;
}
else
{
    largest = c;
}

Console.WriteLine($"The largest number is: {largest}");

// Find the largest among three numbers entered by the user.

// Example Interaction
// Enter first number: 25
// Enter second number: 67
// Enter third number: 42
// The largest number is: 67-