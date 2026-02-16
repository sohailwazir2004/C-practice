const double PI = 3.14159;

Console.Write("Enter radius: ");
var input = Console.ReadLine();
var radius = double.Parse(input);
var area = PI * radius * radius;

Console.WriteLine($"radius type: {radius.GetType().Name}");
Console.WriteLine($"area type: {area.GetType().Name}");
Console.WriteLine($"PI type: {PI.GetType().Name}");
Console.WriteLine($"Area of circle: {area:F2}");