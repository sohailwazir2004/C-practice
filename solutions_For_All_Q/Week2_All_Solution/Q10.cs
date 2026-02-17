Console.Write("Enter N: ");
int n = int.Parse(Console.ReadLine());

int sum = 0;
for (int i = 1; i <= n; i++)
{
    sum += i;  // same as: sum = sum + i
}

Console.WriteLine($"Sum of 1 to {n} = {sum}");