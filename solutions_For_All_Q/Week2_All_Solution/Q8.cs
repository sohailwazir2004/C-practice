Console.Write("Enter the first number :");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter operator (+, -, *, /): ");
char op = Console.ReadLine()[0];

Console.Write("Enter the second number :");
int b = Convert.ToInt32(Console.ReadLine());
int result = op switch 
{
    '+' => a+b,
    '-' => a-b,
    '*' => a*b,
    '/' => b != 0 ? a/b:double.NaN,
    _ => double.NaN 

    
};
if (double.IsNaN(result))
{
    Console.WriteLine("Invalid operation!");
}
else
{
    Console.WriteLine($"Result: {result}");
}