string correctPassword = "secret123";
int attempts = 3;

while (attempts > 0)
{
    Console.Write("Enter password: ");
    string input = Console.ReadLine();

    if (input == correctPassword)
    {
        Console.WriteLine("Access granted!");
        break;
    }
    else
    {
        attempts--;
        if (attempts > 0)
        {
            Console.WriteLine($"Incorrect! {attempts} attempts remaining.");
        }
        else
        {
            Console.WriteLine("Access denied! No attempts remaining.");
        }
    }
}