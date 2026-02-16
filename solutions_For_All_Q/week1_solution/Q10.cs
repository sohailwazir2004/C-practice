Console.Write("Enter first number :");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter second number :");
int num2 = Convert.ToInt32(Console.ReadLine());
int tem = num1;
num1 = num2;
num2 = tem;
Console.WriteLine($"The number are inter changed look for the input values , now look at the current values : {num1} is num1 and num2 is {num2}");

// Enter first number: 5
// Enter second number: 10
// Before swap: a = 5, b = 10
// After swap: a = 10, b = 5