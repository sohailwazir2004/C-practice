int[] numbers = { 45, 12, 78, 34, 89, 23 };

int max = numbers[0];
int min = numbers[0];

foreach (int num in numbers)
{
    if (num > max) max = num;
    if (num < min) min = num;
}

Console.WriteLine($"Array: {string.Join(", ", numbers)}");
Console.WriteLine($"Maximum: {max}");
Console.WriteLine($"Minimum: {min}");