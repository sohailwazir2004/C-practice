Console.Write("Enter a number: ");
int num = int.Parse(Console.ReadLine());

bool isPrime = true;

if (num <= 1)
{
    isPrime = false;
}
else
{
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
        {
            isPrime = false;
            break;
        }
    }
}

if (isPrime)
{
    Console.WriteLine($"{num} is a prime number.");
}
else
{
    Console.WriteLine($"{num} is not a prime number.");
}