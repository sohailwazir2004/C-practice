Console.Write("Enter principal amount: ");
double principal = double.Parse(Console.ReadLine());

Console.Write("Enter rate of interest: ");
double rate = double.Parse(Console.ReadLine());

Console.Write("Enter time (years): ");
double time = double.Parse(Console.ReadLine());

double interest = (principal * rate * time) / 100;
double totalAmount = principal + interest;

Console.WriteLine($"Simple Interest: {interest}");
Console.WriteLine($"Total Amount: {totalAmount}");