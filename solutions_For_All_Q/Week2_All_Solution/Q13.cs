int choice;

do
{
    Console.WriteLine("\n=== MENU ===");
    Console.WriteLine("1. Say Hello");
    Console.WriteLine("2. Show Date");
    Console.WriteLine("3. Exit");
    Console.Write("Choose option: ");
    choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Hello, User!");
            break;
        case 2:
            Console.WriteLine($"Today is: {DateTime.Now:yyyy-MM-dd}");
            break;
        case 3:
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
} while (choice != 3);