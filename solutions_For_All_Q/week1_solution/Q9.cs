Console.Write("Please enter the length for rectangle :");
double lenght = Convert.ToDouble(Console.ReadLine());
Console.Write("Please enter the width for rectangle :");
double width = Convert.ToDouble(Console.ReadLine());
double area = lenght*width;
double perimeter = 2*area ; 
Console.WriteLine();
Console.WriteLine($"The area is {area} , and the perimeter is {perimeter}");
// Asks for rectangle length and width
// Calculates and displays:
// Area (length × width)
// Perimeter (2 × (length + width))