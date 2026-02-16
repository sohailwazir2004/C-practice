double pi = Math.PI;

Console.Write("Please enter the raduis here: ");
double r = Convert.ToDouble(Console.ReadLine());
double area = (pi)*(r*r);
double cercumference = 2*pi*r;
Console.WriteLine($"the area is {area} , and the circumeference is {cercumference}");

// Asks for circle radius
// Calculates and displays:
// Area (π × r²)
// Circumference (2 × π × r)