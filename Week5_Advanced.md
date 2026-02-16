# Week 5: Advanced C# Concepts

## Learning Objectives
By the end of this week, you will be able to:
- Use generic collections (List, Dictionary, Queue, Stack)
- Handle exceptions with try-catch-finally
- Create custom exceptions
- Read and write files
- Use LINQ for data querying
- Write lambda expressions
- Understand delegates and events
- Use async/await for asynchronous programming

> **Official Reference**: [LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/linq/) | [Async](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)

---

## Activity 1: Generic Collections

### Concept (From Microsoft Docs)
Generic collections are type-safe and don't require boxing/unboxing.

```csharp
using System.Collections.Generic;

// List<T> - dynamic array
List<string> names = new List<string>();
names.Add("Ahmad");
names.Add("Sara");
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// Dictionary<TKey, TValue> - key-value pairs
Dictionary<string, int> ages = new Dictionary<string, int>();
ages["Ahmad"] = 25;
ages["Sara"] = 22;

// Queue<T> - First In First Out (FIFO)
Queue<string> queue = new Queue<string>();
queue.Enqueue("First");
queue.Enqueue("Second");
string first = queue.Dequeue();  // "First"

// Stack<T> - Last In First Out (LIFO)
Stack<string> stack = new Stack<string>();
stack.Push("First");
stack.Push("Second");
string top = stack.Pop();  // "Second"
```

---

## Activity 2: Exception Handling

### Concept
```csharp
try
{
    // Code that might throw an exception
    int result = 10 / 0;
}
catch (DivideByZeroException ex)
{
    // Handle specific exception
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
    // Handle any other exception
    Console.WriteLine($"General error: {ex.Message}");
}
finally
{
    // Always executes (cleanup code)
    Console.WriteLine("Cleanup completed.");
}
```

---

## Questions

### Question 1: List<T> Basics
**Topic**: Generic List
**Difficulty**: Beginner

#### Problem Statement
Create a program that:
1. Creates a List of student names
2. Adds 5 students
3. Displays all students
4. Removes one student
5. Searches for a student
6. Sorts the list alphabetically

#### Solution
```csharp
using System.Collections.Generic;

List<string> students = new List<string>();

// Add students
students.Add("Ahmad");
students.Add("Sara");
students.Add("Ali");
students.Add("Fatima");
students.Add("Hassan");

Console.WriteLine("All Students:");
foreach (string student in students)
{
    Console.WriteLine($"  - {student}");
}

// Remove a student
students.Remove("Ali");
Console.WriteLine($"\nAfter removing Ali: {students.Count} students");

// Search for a student
string searchName = "Sara";
bool found = students.Contains(searchName);
Console.WriteLine($"\nIs {searchName} in list? {found}");

// Sort alphabetically
students.Sort();
Console.WriteLine("\nSorted list:");
foreach (string student in students)
{
    Console.WriteLine($"  - {student}");
}
```

---

### Question 2: Dictionary<TKey, TValue>
**Topic**: Key-Value Collections
**Difficulty**: Beginner

#### Problem Statement
Create a phone book using Dictionary:
1. Add 5 contacts (name → phone number)
2. Look up a contact
3. Update a phone number
4. List all contacts
5. Check if a contact exists

#### Solution
```csharp
Dictionary<string, string> phoneBook = new Dictionary<string, string>();

// Add contacts
phoneBook["Ahmad"] = "0300-1234567";
phoneBook["Sara"] = "0301-2345678";
phoneBook["Ali"] = "0302-3456789";
phoneBook["Fatima"] = "0303-4567890";
phoneBook["Hassan"] = "0304-5678901";

// Look up a contact
string name = "Sara";
if (phoneBook.ContainsKey(name))
{
    Console.WriteLine($"{name}'s number: {phoneBook[name]}");
}

// Update a phone number
phoneBook["Ahmad"] = "0300-9999999";
Console.WriteLine($"\nUpdated Ahmad's number: {phoneBook["Ahmad"]}");

// List all contacts
Console.WriteLine("\nAll Contacts:");
foreach (KeyValuePair<string, string> contact in phoneBook)
{
    Console.WriteLine($"  {contact.Key}: {contact.Value}");
}

// Check if contact exists
string search = "Zain";
Console.WriteLine($"\nDoes {search} exist? {phoneBook.ContainsKey(search)}");

// Safe lookup with TryGetValue
if (phoneBook.TryGetValue("Ali", out string phoneNumber))
{
    Console.WriteLine($"Ali's number: {phoneNumber}");
}
```

---

### Question 3: Queue and Stack
**Topic**: FIFO and LIFO Collections
**Difficulty**: Intermediate

#### Problem Statement
Simulate a print queue (FIFO) and browser history (LIFO):
1. Print Queue: Add 3 documents, process them in order
2. Browser History: Visit 5 pages, go back 2 pages

#### Solution
```csharp
// Print Queue (FIFO)
Console.WriteLine("=== Print Queue ===");
Queue<string> printQueue = new Queue<string>();

printQueue.Enqueue("Document1.pdf");
printQueue.Enqueue("Report.docx");
printQueue.Enqueue("Image.png");

Console.WriteLine($"Documents in queue: {printQueue.Count}");

while (printQueue.Count > 0)
{
    string doc = printQueue.Dequeue();
    Console.WriteLine($"Printing: {doc}");
}

// Browser History (LIFO)
Console.WriteLine("\n=== Browser History ===");
Stack<string> history = new Stack<string>();

history.Push("google.com");
history.Push("youtube.com");
history.Push("github.com");
history.Push("stackoverflow.com");
history.Push("reddit.com");

Console.WriteLine($"Current page: {history.Peek()}");
Console.WriteLine($"History count: {history.Count}");

Console.WriteLine("\nGoing back...");
history.Pop();
Console.WriteLine($"Current page: {history.Peek()}");

history.Pop();
Console.WriteLine($"Current page: {history.Peek()}");
```

---

### Question 4: Try-Catch Basics
**Topic**: Exception Handling
**Difficulty**: Beginner

#### Problem Statement
Create a division calculator that handles:
- Division by zero
- Invalid input (non-numeric)
- Display appropriate error messages

#### Solution
```csharp
Console.WriteLine("=== Division Calculator ===");

try
{
    Console.Write("Enter first number: ");
    int num1 = int.Parse(Console.ReadLine());

    Console.Write("Enter second number: ");
    int num2 = int.Parse(Console.ReadLine());

    int result = num1 / num2;
    Console.WriteLine($"Result: {num1} / {num2} = {result}");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Error: Cannot divide by zero!");
}
catch (FormatException)
{
    Console.WriteLine("Error: Please enter valid numbers!");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
finally
{
    Console.WriteLine("Calculator finished.");
}
```

---

### Question 5: Multiple Exception Handling
**Topic**: Exception types
**Difficulty**: Intermediate

#### Problem Statement
Create an array access program that handles:
- IndexOutOfRangeException
- OverflowException
- ArgumentException

#### Solution
```csharp
int[] numbers = { 10, 20, 30, 40, 50 };

void AccessArray(int index, int multiplier)
{
    try
    {
        if (multiplier < 0)
        {
            throw new ArgumentException("Multiplier cannot be negative");
        }

        checked  // Enables overflow checking
        {
            int value = numbers[index];
            int result = value * multiplier;
            Console.WriteLine($"numbers[{index}] * {multiplier} = {result}");
        }
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine($"Error: Index {index} is out of range (0-{numbers.Length - 1})");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Error: Calculation resulted in overflow!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// Test cases
AccessArray(2, 5);         // Valid
AccessArray(10, 2);        // IndexOutOfRange
AccessArray(-1, 2);        // IndexOutOfRange
AccessArray(0, -5);        // ArgumentException
AccessArray(0, int.MaxValue);  // Might overflow
```

---

### Question 6: Custom Exception
**Topic**: Creating exception classes
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Custom exception class
class InsufficientFundsException : Exception
{
    public decimal Balance { get; }
    public decimal Amount { get; }

    public InsufficientFundsException(decimal balance, decimal amount)
        : base($"Insufficient funds. Balance: ${balance:F2}, Requested: ${amount:F2}")
    {
        Balance = balance;
        Amount = amount;
    }
}
```

#### Problem Statement
Create:
- Custom exception `InvalidAgeException`
- Use it in a `Person` class that validates age (must be 0-150)

#### Solution
```csharp
class InvalidAgeException : Exception
{
    public int ProvidedAge { get; }

    public InvalidAgeException(int age)
        : base($"Invalid age: {age}. Age must be between 0 and 150.")
    {
        ProvidedAge = age;
    }
}

class Person
{
    public string Name { get; set; }
    private int age;

    public int Age
    {
        get => age;
        set
        {
            if (value < 0 || value > 150)
            {
                throw new InvalidAgeException(value);
            }
            age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;  // Uses property setter with validation
    }
}

// Main code
try
{
    Person p1 = new Person("Ahmad", 25);
    Console.WriteLine($"Created: {p1.Name}, Age: {p1.Age}");

    Person p2 = new Person("Invalid", -5);  // Throws exception
}
catch (InvalidAgeException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine($"Provided age was: {ex.ProvidedAge}");
}
```

---

### Question 7: File Reading
**Topic**: File I/O
**Difficulty**: Intermediate

#### Concept Activity
```csharp
using System.IO;

// Read all text
string content = File.ReadAllText("file.txt");

// Read all lines
string[] lines = File.ReadAllLines("file.txt");

// Read line by line (memory efficient for large files)
foreach (string line in File.ReadLines("file.txt"))
{
    Console.WriteLine(line);
}

// Check if file exists
if (File.Exists("file.txt"))
{
    // File operations
}
```

#### Problem Statement
Create a program that:
1. Reads a text file
2. Counts total lines, words, and characters
3. Handles FileNotFoundException

#### Solution
```csharp
using System.IO;

void AnalyzeFile(string filePath)
{
    try
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        string[] lines = File.ReadAllLines(filePath);
        int lineCount = lines.Length;
        int wordCount = 0;
        int charCount = 0;

        foreach (string line in lines)
        {
            charCount += line.Length;
            wordCount += line.Split(new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        Console.WriteLine($"File: {filePath}");
        Console.WriteLine($"Lines: {lineCount}");
        Console.WriteLine($"Words: {wordCount}");
        Console.WriteLine($"Characters: {charCount}");
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"IO Error: {ex.Message}");
    }
}

// Create a test file first
File.WriteAllText("test.txt", "Hello World\nThis is a test file.\nIt has three lines.");
AnalyzeFile("test.txt");
```

---

### Question 8: File Writing
**Topic**: File I/O
**Difficulty**: Intermediate

#### Concept Activity
```csharp
using System.IO;

// Write all text (overwrites)
File.WriteAllText("file.txt", "Hello World");

// Write all lines
string[] lines = { "Line 1", "Line 2", "Line 3" };
File.WriteAllLines("file.txt", lines);

// Append text
File.AppendAllText("file.txt", "\nNew line");

// Using StreamWriter for more control
using (StreamWriter writer = new StreamWriter("file.txt"))
{
    writer.WriteLine("Line 1");
    writer.WriteLine("Line 2");
}
```

#### Problem Statement
Create a simple note-taking application:
1. Menu: Add Note, View Notes, Clear Notes, Exit
2. Notes are saved to "notes.txt"
3. Notes persist between program runs

#### Solution
```csharp
using System.IO;

string notesFile = "notes.txt";

void AddNote()
{
    Console.Write("Enter your note: ");
    string note = Console.ReadLine();
    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    File.AppendAllText(notesFile, $"[{timestamp}] {note}\n");
    Console.WriteLine("Note saved!");
}

void ViewNotes()
{
    Console.WriteLine("\n=== Your Notes ===");
    if (File.Exists(notesFile))
    {
        string content = File.ReadAllText(notesFile);
        if (string.IsNullOrWhiteSpace(content))
        {
            Console.WriteLine("No notes yet.");
        }
        else
        {
            Console.WriteLine(content);
        }
    }
    else
    {
        Console.WriteLine("No notes yet.");
    }
}

void ClearNotes()
{
    Console.Write("Are you sure? (yes/no): ");
    if (Console.ReadLine().ToLower() == "yes")
    {
        File.WriteAllText(notesFile, "");
        Console.WriteLine("All notes cleared!");
    }
}

// Main loop
int choice;
do
{
    Console.WriteLine("\n=== Note Taking App ===");
    Console.WriteLine("1. Add Note");
    Console.WriteLine("2. View Notes");
    Console.WriteLine("3. Clear Notes");
    Console.WriteLine("4. Exit");
    Console.Write("Choose option: ");

    choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1: AddNote(); break;
        case 2: ViewNotes(); break;
        case 3: ClearNotes(); break;
        case 4: Console.WriteLine("Goodbye!"); break;
        default: Console.WriteLine("Invalid option"); break;
    }
} while (choice != 4);
```

---

### Question 9: LINQ Basics - Query Syntax
**Topic**: Language Integrated Query
**Difficulty**: Intermediate

#### Concept Activity
```csharp
using System.Linq;

int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Query syntax
var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;

// Method syntax (equivalent)
var evenNumbers2 = numbers.Where(n => n % 2 == 0);

// Common LINQ methods
numbers.Where(n => n > 5);           // Filter
numbers.Select(n => n * 2);          // Transform
numbers.OrderBy(n => n);             // Sort ascending
numbers.OrderByDescending(n => n);   // Sort descending
numbers.First();                      // First element
numbers.Last();                       // Last element
numbers.Count();                      // Count elements
numbers.Sum();                        // Sum
numbers.Average();                    // Average
numbers.Min();                        // Minimum
numbers.Max();                        // Maximum
```

#### Problem Statement
Given a list of numbers, use LINQ to:
1. Find all even numbers
2. Find numbers greater than 50
3. Calculate sum, average, min, max
4. Get top 5 numbers sorted descending

#### Solution
```csharp
using System.Linq;

List<int> numbers = new List<int> { 23, 67, 12, 89, 45, 78, 34, 91, 56, 10 };

Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");

// 1. Even numbers
var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;
Console.WriteLine($"\nEven numbers: {string.Join(", ", evenNumbers)}");

// 2. Numbers > 50
var greaterThan50 = numbers.Where(n => n > 50);
Console.WriteLine($"Greater than 50: {string.Join(", ", greaterThan50)}");

// 3. Statistics
Console.WriteLine($"\nSum: {numbers.Sum()}");
Console.WriteLine($"Average: {numbers.Average():F2}");
Console.WriteLine($"Min: {numbers.Min()}");
Console.WriteLine($"Max: {numbers.Max()}");

// 4. Top 5 descending
var top5 = numbers.OrderByDescending(n => n).Take(5);
Console.WriteLine($"\nTop 5: {string.Join(", ", top5)}");
```

---

### Question 10: LINQ with Objects
**Topic**: LINQ on collections of objects
**Difficulty**: Intermediate

#### Problem Statement
Create a Student class and use LINQ to:
1. Find students with GPA > 3.5
2. Sort students by name
3. Group students by department
4. Calculate average GPA by department

#### Solution
```csharp
using System.Linq;

class Student
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double GPA { get; set; }
}

List<Student> students = new List<Student>
{
    new Student { Name = "Ahmad", Department = "CS", GPA = 3.8 },
    new Student { Name = "Sara", Department = "Engineering", GPA = 3.5 },
    new Student { Name = "Ali", Department = "CS", GPA = 3.2 },
    new Student { Name = "Fatima", Department = "Engineering", GPA = 3.9 },
    new Student { Name = "Hassan", Department = "CS", GPA = 3.6 },
    new Student { Name = "Zainab", Department = "Math", GPA = 3.7 }
};

// 1. Students with GPA > 3.5
Console.WriteLine("=== Honor Students (GPA > 3.5) ===");
var honorStudents = students.Where(s => s.GPA > 3.5);
foreach (var s in honorStudents)
{
    Console.WriteLine($"{s.Name}: {s.GPA}");
}

// 2. Sort by name
Console.WriteLine("\n=== Sorted by Name ===");
var sorted = students.OrderBy(s => s.Name);
foreach (var s in sorted)
{
    Console.WriteLine($"{s.Name} ({s.Department})");
}

// 3. Group by department
Console.WriteLine("\n=== Grouped by Department ===");
var grouped = students.GroupBy(s => s.Department);
foreach (var group in grouped)
{
    Console.WriteLine($"\n{group.Key}:");
    foreach (var s in group)
    {
        Console.WriteLine($"  - {s.Name}: {s.GPA}");
    }
}

// 4. Average GPA by department
Console.WriteLine("\n=== Average GPA by Department ===");
var avgByDept = students
    .GroupBy(s => s.Department)
    .Select(g => new { Dept = g.Key, AvgGPA = g.Average(s => s.GPA) });

foreach (var item in avgByDept)
{
    Console.WriteLine($"{item.Dept}: {item.AvgGPA:F2}");
}
```

---

### Question 11: Lambda Expressions
**Topic**: Anonymous functions
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Lambda syntax: (parameters) => expression

// Single parameter
Func<int, int> square = x => x * x;
Console.WriteLine(square(5));  // 25

// Multiple parameters
Func<int, int, int> add = (a, b) => a + b;
Console.WriteLine(add(3, 4));  // 7

// No parameters
Action greet = () => Console.WriteLine("Hello!");
greet();

// Multiple statements (use braces)
Func<int, int> factorial = n =>
{
    int result = 1;
    for (int i = 1; i <= n; i++)
        result *= i;
    return result;
};
```

#### Problem Statement
Create lambda expressions for:
1. Check if number is even
2. Calculate area of rectangle
3. Convert temperature (Celsius to Fahrenheit)
4. Filter words longer than 5 characters

#### Solution
```csharp
// 1. Check if even
Func<int, bool> isEven = n => n % 2 == 0;
Console.WriteLine($"Is 4 even? {isEven(4)}");
Console.WriteLine($"Is 7 even? {isEven(7)}");

// 2. Rectangle area
Func<double, double, double> rectangleArea = (length, width) => length * width;
Console.WriteLine($"\nRectangle (5x3) area: {rectangleArea(5, 3)}");

// 3. Celsius to Fahrenheit
Func<double, double> celsiusToFahrenheit = c => (c * 9.0 / 5) + 32;
Console.WriteLine($"\n25°C = {celsiusToFahrenheit(25)}°F");

// 4. Filter long words
Func<string[], IEnumerable<string>> filterLongWords =
    words => words.Where(w => w.Length > 5);

string[] wordList = { "cat", "elephant", "dog", "programming", "hi", "computer" };
var longWords = filterLongWords(wordList);
Console.WriteLine($"\nWords longer than 5 chars: {string.Join(", ", longWords)}");
```

---

### Question 12: Delegates
**Topic**: Type-safe function pointers
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Delegate declaration
delegate int MathOperation(int a, int b);

// Methods matching the delegate signature
int Add(int a, int b) => a + b;
int Subtract(int a, int b) => a - b;
int Multiply(int a, int b) => a * b;

// Using delegates
MathOperation operation = Add;
Console.WriteLine(operation(5, 3));  // 8

operation = Multiply;
Console.WriteLine(operation(5, 3));  // 15

// Built-in delegates
Func<int, int, int> func;    // Returns value
Action<string> action;        // No return (void)
Predicate<int> predicate;     // Returns bool
```

#### Problem Statement
Create a calculator that uses delegates for operations:
1. Define delegate for math operations
2. Create Add, Subtract, Multiply, Divide methods
3. Create a Calculate method that accepts delegate

#### Solution
```csharp
delegate double MathOperation(double a, double b);

double Add(double a, double b) => a + b;
double Subtract(double a, double b) => a - b;
double Multiply(double a, double b) => a * b;
double Divide(double a, double b) => b != 0 ? a / b : double.NaN;

void Calculate(double a, double b, MathOperation operation, string opName)
{
    double result = operation(a, b);
    Console.WriteLine($"{a} {opName} {b} = {result}");
}

// Test
double num1 = 10, num2 = 3;

Calculate(num1, num2, Add, "+");
Calculate(num1, num2, Subtract, "-");
Calculate(num1, num2, Multiply, "*");
Calculate(num1, num2, Divide, "/");

// Using lambda
Calculate(num1, num2, (a, b) => Math.Pow(a, b), "^");
```

---

### Question 13: Events
**Topic**: Event-driven programming
**Difficulty**: Advanced

#### Concept Activity
```csharp
// Event pattern
class Button
{
    // 1. Declare event using EventHandler
    public event EventHandler Clicked;

    // 2. Method to raise the event
    public void Click()
    {
        Console.WriteLine("Button clicked!");
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}

// 3. Subscribe to event
Button btn = new Button();
btn.Clicked += (sender, e) => Console.WriteLine("Handler 1 executed");
btn.Clicked += (sender, e) => Console.WriteLine("Handler 2 executed");

btn.Click();
```

#### Problem Statement
Create a temperature monitor that:
1. Raises event when temperature exceeds threshold
2. Has multiple event handlers (alert, log, notify)

#### Solution
```csharp
class TemperatureEventArgs : EventArgs
{
    public double Temperature { get; set; }
    public DateTime Time { get; set; }
}

class TemperatureMonitor
{
    private double threshold;

    public event EventHandler<TemperatureEventArgs> TemperatureExceeded;

    public TemperatureMonitor(double threshold)
    {
        this.threshold = threshold;
    }

    public void CheckTemperature(double temperature)
    {
        Console.WriteLine($"Current temperature: {temperature}°C");

        if (temperature > threshold)
        {
            TemperatureExceeded?.Invoke(this, new TemperatureEventArgs
            {
                Temperature = temperature,
                Time = DateTime.Now
            });
        }
    }
}

// Main code
TemperatureMonitor monitor = new TemperatureMonitor(30);

// Subscribe handlers
monitor.TemperatureExceeded += (sender, e) =>
{
    Console.WriteLine($"  ALERT: Temperature is {e.Temperature}°C!");
};

monitor.TemperatureExceeded += (sender, e) =>
{
    Console.WriteLine($"  LOG: High temp recorded at {e.Time}");
};

monitor.TemperatureExceeded += (sender, e) =>
{
    Console.WriteLine($"  NOTIFY: Sending notification...");
};

// Test
Console.WriteLine("=== Temperature Monitoring ===\n");
monitor.CheckTemperature(25);
Console.WriteLine();
monitor.CheckTemperature(35);
Console.WriteLine();
monitor.CheckTemperature(28);
```

---

### Question 14: Async/Await Basics
**Topic**: Asynchronous programming
**Difficulty**: Advanced

#### Concept Activity
```csharp
using System.Threading.Tasks;

// async method returns Task or Task<T>
async Task<string> FetchDataAsync()
{
    // await pauses execution until task completes
    await Task.Delay(2000);  // Simulate delay
    return "Data fetched!";
}

// Calling async method
async Task Main()
{
    Console.WriteLine("Starting...");
    string result = await FetchDataAsync();
    Console.WriteLine(result);
    Console.WriteLine("Done!");
}
```

#### Problem Statement
Create an async program that:
1. Simulates downloading 3 files
2. Each download takes different time
3. Shows progress and total time

#### Solution
```csharp
using System.Threading.Tasks;
using System.Diagnostics;

async Task<string> DownloadFileAsync(string fileName, int milliseconds)
{
    Console.WriteLine($"Starting download: {fileName}");
    await Task.Delay(milliseconds);
    Console.WriteLine($"Completed: {fileName} ({milliseconds}ms)");
    return fileName;
}

async Task DownloadAllFilesAsync()
{
    Stopwatch sw = Stopwatch.StartNew();

    // Sequential downloads
    Console.WriteLine("=== Sequential Downloads ===");
    await DownloadFileAsync("file1.txt", 1000);
    await DownloadFileAsync("file2.txt", 1500);
    await DownloadFileAsync("file3.txt", 800);
    Console.WriteLine($"Total time: {sw.ElapsedMilliseconds}ms\n");

    // Parallel downloads
    sw.Restart();
    Console.WriteLine("=== Parallel Downloads ===");

    Task<string> task1 = DownloadFileAsync("doc1.pdf", 1000);
    Task<string> task2 = DownloadFileAsync("doc2.pdf", 1500);
    Task<string> task3 = DownloadFileAsync("doc3.pdf", 800);

    string[] results = await Task.WhenAll(task1, task2, task3);

    Console.WriteLine($"Total time: {sw.ElapsedMilliseconds}ms");
    Console.WriteLine($"Downloaded: {string.Join(", ", results)}");
}

// Run
await DownloadAllFilesAsync();
```

---

### Question 15: Async File Operations
**Topic**: Async I/O
**Difficulty**: Advanced

#### Problem Statement
Create an async program that:
1. Reads multiple text files asynchronously
2. Combines their contents
3. Writes to a new file

#### Solution
```csharp
using System.IO;
using System.Threading.Tasks;

async Task<string> ReadFileAsync(string path)
{
    Console.WriteLine($"Reading: {path}");
    return await File.ReadAllTextAsync(path);
}

async Task WriteFileAsync(string path, string content)
{
    Console.WriteLine($"Writing: {path}");
    await File.WriteAllTextAsync(path, content);
}

async Task CombineFilesAsync()
{
    // Create test files
    await WriteFileAsync("part1.txt", "This is part 1.\n");
    await WriteFileAsync("part2.txt", "This is part 2.\n");
    await WriteFileAsync("part3.txt", "This is part 3.\n");

    Console.WriteLine("\n=== Combining Files ===");

    // Read all files in parallel
    Task<string>[] readTasks = {
        ReadFileAsync("part1.txt"),
        ReadFileAsync("part2.txt"),
        ReadFileAsync("part3.txt")
    };

    string[] contents = await Task.WhenAll(readTasks);

    // Combine and write
    string combined = string.Join("", contents);
    await WriteFileAsync("combined.txt", combined);

    Console.WriteLine("\n=== Combined Content ===");
    Console.WriteLine(await ReadFileAsync("combined.txt"));

    // Cleanup
    File.Delete("part1.txt");
    File.Delete("part2.txt");
    File.Delete("part3.txt");
    File.Delete("combined.txt");
}

await CombineFilesAsync();
```

---

### Question 16: Extension Methods
**Topic**: Adding methods to existing types
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Extension methods must be in static class
static class StringExtensions
{
    // 'this' keyword makes it an extension method
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '\t', '\n' },
            StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string Reverse(this string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}

// Usage
string text = "Hello World";
int count = text.WordCount();  // 2
string reversed = text.Reverse();  // "dlroW olleH"
```

#### Problem Statement
Create extension methods for:
1. int: IsEven(), IsPrime()
2. string: ToTitleCase(), Truncate(maxLength)
3. List<int>: Average(), Median()

#### Solution
```csharp
static class Extensions
{
    // int extensions
    public static bool IsEven(this int number) => number % 2 == 0;

    public static bool IsPrime(this int number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    // string extensions
    public static string ToTitleCase(this string str)
    {
        return System.Globalization.CultureInfo.CurrentCulture
            .TextInfo.ToTitleCase(str.ToLower());
    }

    public static string Truncate(this string str, int maxLength)
    {
        if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
            return str;
        return str.Substring(0, maxLength) + "...";
    }

    // List<int> extensions
    public static double Median(this List<int> list)
    {
        var sorted = list.OrderBy(n => n).ToList();
        int count = sorted.Count;

        if (count == 0) return 0;

        if (count % 2 == 0)
            return (sorted[count / 2 - 1] + sorted[count / 2]) / 2.0;
        else
            return sorted[count / 2];
    }
}

// Test
Console.WriteLine($"10.IsEven(): {10.IsEven()}");
Console.WriteLine($"7.IsPrime(): {7.IsPrime()}");
Console.WriteLine($"\"hello world\".ToTitleCase(): {"hello world".ToTitleCase()}");
Console.WriteLine($"\"This is a long text\".Truncate(10): {"This is a long text".Truncate(10)}");

List<int> numbers = new List<int> { 1, 3, 5, 7, 9 };
Console.WriteLine($"Median of {string.Join(", ", numbers)}: {numbers.Median()}");
```

---

## Challenge Questions

### Challenge 1: Task Manager Application
**Difficulty**: Advanced

#### Problem Statement
Create a complete task manager with:
- Task class with properties (Title, Description, DueDate, Priority, IsCompleted)
- File persistence (JSON or text)
- LINQ queries for filtering
- Menu-driven interface

#### Solution
```csharp
using System.Text.Json;

enum Priority { Low, Medium, High }

class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public bool IsCompleted { get; set; }

    public override string ToString()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        return $"{status} {Id}. {Title} (Due: {DueDate:yyyy-MM-dd}, Priority: {Priority})";
    }
}

class TaskManager
{
    private List<TaskItem> tasks = new List<TaskItem>();
    private string filePath = "tasks.json";
    private int nextId = 1;

    public TaskManager()
    {
        LoadTasks();
    }

    public void AddTask(string title, string description, DateTime dueDate, Priority priority)
    {
        tasks.Add(new TaskItem
        {
            Id = nextId++,
            Title = title,
            Description = description,
            DueDate = dueDate,
            Priority = priority,
            IsCompleted = false
        });
        SaveTasks();
        Console.WriteLine("Task added successfully!");
    }

    public void CompleteTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            SaveTasks();
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void ListTasks(string filter = "all")
    {
        IEnumerable<TaskItem> filtered = filter switch
        {
            "pending" => tasks.Where(t => !t.IsCompleted),
            "completed" => tasks.Where(t => t.IsCompleted),
            "today" => tasks.Where(t => t.DueDate.Date == DateTime.Today),
            "high" => tasks.Where(t => t.Priority == Priority.High),
            _ => tasks
        };

        Console.WriteLine($"\n=== Tasks ({filter}) ===");
        foreach (var task in filtered.OrderBy(t => t.DueDate))
        {
            Console.WriteLine(task);
        }
    }

    private void SaveTasks()
    {
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);
    }

    private void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            nextId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
        }
    }
}

// Main code
TaskManager manager = new TaskManager();

manager.AddTask("Learn LINQ", "Complete LINQ exercises", DateTime.Today.AddDays(1), Priority.High);
manager.AddTask("Read book", "Finish C# book chapter 10", DateTime.Today.AddDays(7), Priority.Medium);
manager.AddTask("Exercise", "30 minute workout", DateTime.Today, Priority.Low);

manager.ListTasks("all");
manager.ListTasks("pending");
manager.CompleteTask(3);
manager.ListTasks("completed");
```

---

### Challenge 2: Async Web Scraper Simulation
**Difficulty**: Advanced

#### Problem Statement
Create an async web scraper simulation that:
- Simulates fetching data from multiple URLs
- Processes data in parallel
- Shows progress and handles errors
- Combines results

#### Solution
```csharp
using System.Threading.Tasks;

class WebPage
{
    public string Url { get; set; }
    public string Content { get; set; }
    public bool Success { get; set; }
    public string Error { get; set; }
}

class WebScraper
{
    private Random random = new Random();

    public async Task<WebPage> FetchPageAsync(string url)
    {
        Console.WriteLine($"Fetching: {url}");

        // Simulate network delay
        int delay = random.Next(500, 2000);
        await Task.Delay(delay);

        // Simulate occasional failures
        if (random.Next(10) < 2)  // 20% failure rate
        {
            Console.WriteLine($"Failed: {url}");
            return new WebPage
            {
                Url = url,
                Success = false,
                Error = "Connection timeout"
            };
        }

        Console.WriteLine($"Completed: {url} ({delay}ms)");
        return new WebPage
        {
            Url = url,
            Content = $"Content from {url} (fetched in {delay}ms)",
            Success = true
        };
    }

    public async Task<List<WebPage>> ScrapeAllAsync(string[] urls)
    {
        Console.WriteLine($"Starting to scrape {urls.Length} pages...\n");

        var tasks = urls.Select(url => FetchPageAsync(url));
        WebPage[] results = await Task.WhenAll(tasks);

        return results.ToList();
    }

    public void DisplayResults(List<WebPage> pages)
    {
        Console.WriteLine("\n=== Scraping Results ===");

        var successful = pages.Where(p => p.Success).ToList();
        var failed = pages.Where(p => !p.Success).ToList();

        Console.WriteLine($"\nSuccessful ({successful.Count}):");
        foreach (var page in successful)
        {
            Console.WriteLine($"  - {page.Content}");
        }

        if (failed.Any())
        {
            Console.WriteLine($"\nFailed ({failed.Count}):");
            foreach (var page in failed)
            {
                Console.WriteLine($"  - {page.Url}: {page.Error}");
            }
        }

        double successRate = (double)successful.Count / pages.Count * 100;
        Console.WriteLine($"\nSuccess rate: {successRate:F1}%");
    }
}

// Main code
var scraper = new WebScraper();

string[] urls = {
    "https://example.com/page1",
    "https://example.com/page2",
    "https://example.com/page3",
    "https://example.com/page4",
    "https://example.com/page5"
};

var results = await scraper.ScrapeAllAsync(urls);
scraper.DisplayResults(results);
```

---

## Week 5 Summary Checklist

- [ ] Can use List<T> (Add, Remove, Contains, Sort)
- [ ] Can use Dictionary<K,V> (Add, TryGetValue, ContainsKey)
- [ ] Understand Queue (FIFO) and Stack (LIFO)
- [ ] Can handle exceptions with try-catch-finally
- [ ] Can create custom exception classes
- [ ] Can read and write files (File class)
- [ ] Can use basic LINQ queries (Where, Select, OrderBy)
- [ ] Can use LINQ aggregations (Sum, Average, Count, Min, Max)
- [ ] Can group data with LINQ
- [ ] Can write lambda expressions
- [ ] Understand delegates (Func, Action, Predicate)
- [ ] Can work with events
- [ ] Can write async methods with async/await
- [ ] Can run tasks in parallel with Task.WhenAll
- [ ] Can create extension methods

---

## Congratulations!

You have completed the 5-week C# learning journey!

### What You've Learned
- **Week 1**: Fundamentals, variables, I/O, operators
- **Week 2**: Control flow, loops, decision making
- **Week 3**: Arrays, methods, recursion
- **Week 4**: OOP (classes, inheritance, polymorphism, interfaces)
- **Week 5**: Advanced (collections, LINQ, async, file I/O)

### Next Steps
1. Build real projects to solidify your knowledge
2. Explore ASP.NET Core for web development
3. Learn Entity Framework for database operations
4. Study design patterns
5. Consider the Microsoft C# Certification

### Resources
- [Microsoft C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [freeCodeCamp C# Certification](https://www.freecodecamp.org/learn/foundational-c-sharp-with-microsoft/)
- [C# Corner](https://www.c-sharpcorner.com/)

---

*Questions: 16 | Challenges: 2 | Total: 18*
*Grand Total for All Weeks: 97 Questions & Challenges*
