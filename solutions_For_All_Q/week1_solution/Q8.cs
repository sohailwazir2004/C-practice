Console.Write("Please enter the temp in Celcius");
double celcius = Convert.ToDouble(Console.ReadLine());
double fahrenheit = (celsius * 9.0 / 5) + 32;
Console.WriteLine($"{celsius}°C = {fahrenheit}°F");
