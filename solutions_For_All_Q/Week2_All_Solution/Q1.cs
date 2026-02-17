Console.Write("Enter a number :");
int num = Convert.ToInt32(Console.ReadLine());
if (num > 0)
{
    Console.WriteLine($"the {num} is greater then 0!");
}
else if (num < 0 )
{
    Console.Write($"The {num} is smaller then 0!");
}
else
{
    Console.Write("The numeber is 0!");
}

// Enter a number: -5
// The number is negative.