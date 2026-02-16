Console.Write("Please enter your weight is kg :");
double w = Convert.ToDouble(Console.ReadLine());
Console.Write("Please enter your height :");
double h = Convert.ToDouble(Console.ReadLine());
double bmi = w/(h*h) ; 
Console.WriteLine($"BMI value is : {bmi:F2}");
// Asks for weight in kg
// Asks for height in meters
// Calculates and displays BMI rounded to 2 decimal places