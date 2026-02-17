Console.Write("Enter N: ");
int n = int.Parse(Console.ReadLine());

long factorial = 1;
for (int i = 1; i <= n; i++)
{
    factorial *= i;
}

Console.WriteLine($"{n}! = {factorial}");