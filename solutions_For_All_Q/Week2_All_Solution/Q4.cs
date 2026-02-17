Console.Write("Please enter your age :");
int age =  Convert.ToInt32(Console.ReadLine());
Console.Write("Are you a citizen ?");
String citinInput = Console.ReadLine().ToLower();
bool isCitizen = citinInput == "yes";
if (age >= 18 && isCitizen)
{
    Console.WriteLine("You are eligible to vote!");
}
else if (age < 18)
{
    Console.WriteLine("You are too young to vote.");
}