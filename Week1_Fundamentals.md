# Week 1: C# Fundamentals & Basics

## Learning Objectives
By the end of this week, you will be able to:
- Write and run your first C# program
- Understand program structure and namespaces
- Declare and use variables with different data types
- Perform input/output operations
- Use arithmetic and string operators
- Convert between different data types

> **Official Reference**: [Tour of C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/overview)

---

## Activity 1: Setting Up Your Environment

### Concept
Before writing C# code, you need the .NET SDK installed.

### Task
1. Download .NET SDK from https://dotnet.microsoft.com/download
2. Open terminal/command prompt
3. Run: `dotnet --version`
4. Create your first project:
```bash
mkdir CSharpPractice
cd CSharpPractice
dotnet new console -n Week1
cd Week1
```

### Verify
Run `dotnet run` - you should see "Hello, World!"

---

## Activity 2: Understanding Program Structure

### Concept (From Microsoft Docs)
C# programs can use **top-level statements** (modern, simple) or **traditional structure** (explicit).

**Top-Level Statements (C# 9+)**:
```csharp
// Program.cs - This is a complete program!
Console.WriteLine("Hello, World!");
```

**Traditional Structure**:
```csharp
using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

### Key Points
- `using System;` - imports the System namespace
- `namespace` - organizes code into logical groups
- `class` - blueprint for objects
- `static void Main` - entry point of the program
- `Console.WriteLine()` - prints text to console

---

## Questions

### Question 1: Hello World
**Topic**: Console Output
**Difficulty**: Beginner

#### Problem Statement
Write a program that prints "Hello, World!" to the console.

#### Requirements
1. Use `Console.WriteLine()`
2. The output must be exactly: `Hello, World!`

#### Expected Output
```
Hello, World!
```

#### Solution
```csharp
Console.WriteLine("Hello, World!");
```

#### Explanation
`Console.WriteLine()` is a method from the System namespace that outputs text followed by a new line.

---

### Question 2: Personal Introduction
**Topic**: Multiple Console Outputs
**Difficulty**: Beginner

#### Problem Statement
Write a program that prints your name, age, and favorite programming language on separate lines.

#### Requirements
1. Print 3 separate lines
2. Use `Console.WriteLine()` for each line

#### Example Output
```
My name is Ahmed
I am 25 years old
My favorite language is C#
```

#### Solution
```csharp
Console.WriteLine("My name is Ahmed");
Console.WriteLine("I am 25 years old");
Console.WriteLine("My favorite language is C#");
```

#### Explanation
Each `Console.WriteLine()` creates a new line. Use `Console.Write()` if you don't want a new line.

---

### Question 3: Variables and Data Types
**Topic**: Variable Declaration
**Difficulty**: Beginner

#### Concept Activity
Before solving, study these data types:

| Type | Description | Example |
|------|-------------|---------|
| `int` | Whole numbers | `int age = 25;` |
| `double` | Decimal numbers | `double price = 19.99;` |
| `string` | Text | `string name = "Ali";` |
| `char` | Single character | `char grade = 'A';` |
| `bool` | True/False | `bool isActive = true;` |
| `decimal` | Precise decimals | `decimal money = 100.50m;` |

#### Problem Statement
Declare variables to store:
- A person's name (string)
- Their age (int)
- Their height in meters (double)
- Whether they are a student (bool)
- Their grade (char)

Print all values.

#### Expected Output
```
Name: Sara
Age: 22
Height: 1.65 meters
Is Student: True
Grade: A
```

#### Solution
```csharp
string name = "Sara";
int age = 22;
double height = 1.65;
bool isStudent = true;
char grade = 'A';

Console.WriteLine("Name: " + name);
Console.WriteLine("Age: " + age);
Console.WriteLine("Height: " + height + " meters");
Console.WriteLine("Is Student: " + isStudent);
Console.WriteLine("Grade: " + grade);
```

---

### Question 4: User Input - Name
**Topic**: Console.ReadLine()
**Difficulty**: Beginner

#### Concept Activity
`Console.ReadLine()` reads user input as a **string**.

```csharp
Console.Write("Enter your name: ");  // Write doesn't add new line
string name = Console.ReadLine();     // Reads input
Console.WriteLine("Hello, " + name);
```

#### Problem Statement
Write a program that:
1. Asks the user for their name
2. Greets them with "Welcome, [name]!"

#### Example Interaction
```
Enter your name: Ahmad
Welcome, Ahmad!
```

#### Solution
```csharp
Console.Write("Enter your name: ");
string name = Console.ReadLine();
Console.WriteLine("Welcome, " + name + "!");
```

---

### Question 5: User Input - Age
**Topic**: Type Conversion (string to int)
**Difficulty**: Beginner

#### Concept Activity
`Console.ReadLine()` always returns a string. To use it as a number, you must convert it:

```csharp
string input = Console.ReadLine();
int number = int.Parse(input);        // Method 1
int number2 = Convert.ToInt32(input); // Method 2
```

#### Problem Statement
Write a program that:
1. Asks the user for their birth year
2. Calculates and displays their age

#### Example Interaction
```
Enter your birth year: 2000
You are 26 years old.
```

#### Solution
```csharp
Console.Write("Enter your birth year: ");
string input = Console.ReadLine();
int birthYear = int.Parse(input);
int currentYear = 2026;
int age = currentYear - birthYear;
Console.WriteLine("You are " + age + " years old.");
```

---

### Question 6: Arithmetic Operations
**Topic**: Math Operators
**Difficulty**: Beginner

#### Concept Activity
C# arithmetic operators:

| Operator | Description | Example |
|----------|-------------|---------|
| `+` | Addition | `5 + 3 = 8` |
| `-` | Subtraction | `5 - 3 = 2` |
| `*` | Multiplication | `5 * 3 = 15` |
| `/` | Division | `6 / 3 = 2` |
| `%` | Modulus (remainder) | `7 % 3 = 1` |

#### Problem Statement
Write a program that takes two numbers from the user and displays:
- Their sum
- Their difference
- Their product
- Their quotient
- The remainder when first is divided by second

#### Example Interaction
```
Enter first number: 10
Enter second number: 3
Sum: 13
Difference: 7
Product: 30
Quotient: 3
Remainder: 1
```

#### Solution
```csharp
Console.Write("Enter first number: ");
int num1 = int.Parse(Console.ReadLine());

Console.Write("Enter second number: ");
int num2 = int.Parse(Console.ReadLine());

Console.WriteLine("Sum: " + (num1 + num2));
Console.WriteLine("Difference: " + (num1 - num2));
Console.WriteLine("Product: " + (num1 * num2));
Console.WriteLine("Quotient: " + (num1 / num2));
Console.WriteLine("Remainder: " + (num1 % num2));
```

---

### Question 7: String Interpolation
**Topic**: String Formatting
**Difficulty**: Beginner

#### Concept Activity
Three ways to combine strings and variables:

```csharp
string name = "Ali";
int age = 25;

// Method 1: Concatenation (+)
Console.WriteLine("Name: " + name + ", Age: " + age);

// Method 2: String Interpolation ($) - RECOMMENDED
Console.WriteLine($"Name: {name}, Age: {age}");

// Method 3: String.Format
Console.WriteLine(String.Format("Name: {0}, Age: {1}", name, age));
```

#### Problem Statement
Create a program that stores:
- Product name
- Price
- Quantity

Use **string interpolation** to display: "You bought [quantity] [product] for $[total]"

#### Example Output
```
You bought 3 Apple for $7.50
```

#### Solution
```csharp
string product = "Apple";
double price = 2.50;
int quantity = 3;
double total = price * quantity;

Console.WriteLine($"You bought {quantity} {product} for ${total}");
```

---

### Question 8: Temperature Converter
**Topic**: Mathematical Formulas
**Difficulty**: Beginner

#### Concept Activity
Formula: `Fahrenheit = (Celsius * 9/5) + 32`

Note: When dividing integers, use `9.0/5` to get decimal result.

#### Problem Statement
Write a program that:
1. Asks user for temperature in Celsius
2. Converts it to Fahrenheit
3. Displays the result

#### Example Interaction
```
Enter temperature in Celsius: 25
25°C = 77°F
```

#### Solution
```csharp
Console.Write("Enter temperature in Celsius: ");
double celsius = double.Parse(Console.ReadLine());
double fahrenheit = (celsius * 9.0 / 5) + 32;
Console.WriteLine($"{celsius}°C = {fahrenheit}°F");
```

---

### Question 9: Rectangle Calculator
**Topic**: Multiple Calculations
**Difficulty**: Beginner

#### Problem Statement
Write a program that:
1. Asks for rectangle length and width
2. Calculates and displays:
   - Area (length × width)
   - Perimeter (2 × (length + width))

#### Example Interaction
```
Enter length: 5
Enter width: 3
Area: 15
Perimeter: 16
```

#### Solution
```csharp
Console.Write("Enter length: ");
double length = double.Parse(Console.ReadLine());

Console.Write("Enter width: ");
double width = double.Parse(Console.ReadLine());

double area = length * width;
double perimeter = 2 * (length + width);

Console.WriteLine($"Area: {area}");
Console.WriteLine($"Perimeter: {perimeter}");
```

---

### Question 10: Swap Two Numbers
**Topic**: Variable Manipulation
**Difficulty**: Beginner

#### Problem Statement
Write a program that:
1. Takes two numbers from user
2. Swaps their values
3. Displays the swapped values

#### Example Interaction
```
Enter first number: 5
Enter second number: 10
Before swap: a = 5, b = 10
After swap: a = 10, b = 5
```

#### Solution
```csharp
Console.Write("Enter first number: ");
int a = int.Parse(Console.ReadLine());

Console.Write("Enter second number: ");
int b = int.Parse(Console.ReadLine());

Console.WriteLine($"Before swap: a = {a}, b = {b}");

// Swap using temporary variable
int temp = a;
a = b;
b = temp;

Console.WriteLine($"After swap: a = {a}, b = {b}");
```

---

### Question 11: Circle Calculator
**Topic**: Using Math.PI
**Difficulty**: Beginner

#### Concept Activity
C# provides `Math.PI` constant (3.14159265358979...)

```csharp
double pi = Math.PI;
Console.WriteLine(pi); // 3.141592653589793
```

#### Problem Statement
Write a program that:
1. Asks for circle radius
2. Calculates and displays:
   - Area (π × r²)
   - Circumference (2 × π × r)

#### Example Interaction
```
Enter radius: 5
Area: 78.54
Circumference: 31.42
```

#### Solution
```csharp
Console.Write("Enter radius: ");
double radius = double.Parse(Console.ReadLine());

double area = Math.PI * radius * radius;
double circumference = 2 * Math.PI * radius;

Console.WriteLine($"Area: {area:F2}");
Console.WriteLine($"Circumference: {circumference:F2}");
```

#### Note
`:F2` formats the number to 2 decimal places.

---

### Question 12: BMI Calculator
**Topic**: Real-world Application
**Difficulty**: Intermediate

#### Concept Activity
BMI Formula: `BMI = weight(kg) / height(m)²`

#### Problem Statement
Write a program that:
1. Asks for weight in kg
2. Asks for height in meters
3. Calculates and displays BMI rounded to 2 decimal places

#### Example Interaction
```
Enter weight (kg): 70
Enter height (m): 1.75
Your BMI is: 22.86
```

#### Solution
```csharp
Console.Write("Enter weight (kg): ");
double weight = double.Parse(Console.ReadLine());

Console.Write("Enter height (m): ");
double height = double.Parse(Console.ReadLine());

double bmi = weight / (height * height);

Console.WriteLine($"Your BMI is: {bmi:F2}");
```

---

### Question 13: Simple Interest Calculator
**Topic**: Financial Calculation
**Difficulty**: Intermediate

#### Concept Activity
Simple Interest Formula: `SI = (Principal × Rate × Time) / 100`

#### Problem Statement
Write a program that calculates simple interest:
1. Input: Principal amount, Rate of interest, Time in years
2. Output: Simple Interest and Total Amount

#### Example Interaction
```
Enter principal amount: 1000
Enter rate of interest: 5
Enter time (years): 2
Simple Interest: 100
Total Amount: 1100
```

#### Solution
```csharp
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
```

---

### Question 14: Type Conversion Practice
**Topic**: Explicit and Implicit Conversion
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Implicit conversion (automatic, no data loss)
int num = 10;
double d = num;  // int to double - OK

// Explicit conversion (casting, possible data loss)
double price = 19.99;
int rounded = (int)price;  // 19 (decimals lost)

// Parse methods
string s = "123";
int i = int.Parse(s);
double d2 = double.Parse("45.67");

// Convert class
int x = Convert.ToInt32("100");
double y = Convert.ToDouble("99.99");
```

#### Problem Statement
Write a program that:
1. Takes a decimal number from user
2. Displays it as:
   - Integer (truncated)
   - Rounded integer (Math.Round)
   - String with 3 decimal places

#### Example Interaction
```
Enter a decimal number: 123.456789
As integer (truncated): 123
As rounded integer: 123
As string (3 decimals): 123.457
```

#### Solution
```csharp
Console.Write("Enter a decimal number: ");
double number = double.Parse(Console.ReadLine());

int truncated = (int)number;
int rounded = (int)Math.Round(number);
string formatted = number.ToString("F3");

Console.WriteLine($"As integer (truncated): {truncated}");
Console.WriteLine($"As rounded integer: {rounded}");
Console.WriteLine($"As string (3 decimals): {formatted}");
```

---

### Question 15: Constants and var Keyword
**Topic**: const, readonly, var
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// const - compile-time constant, cannot change
const double PI = 3.14159;

// var - compiler infers the type
var name = "Ali";      // inferred as string
var age = 25;          // inferred as int
var price = 19.99;     // inferred as double

// You cannot use var without initialization
// var x;  // ERROR!
```

#### Problem Statement
Create a program that calculates the area of a circle using:
1. A constant for PI
2. var for other variables
3. Display the type of each variable using `.GetType().Name`

#### Example Output
```
Enter radius: 5
radius type: Double
area type: Double
PI type: Double
Area of circle: 78.54
```

#### Solution
```csharp
const double PI = 3.14159;

Console.Write("Enter radius: ");
var input = Console.ReadLine();
var radius = double.Parse(input);
var area = PI * radius * radius;

Console.WriteLine($"radius type: {radius.GetType().Name}");
Console.WriteLine($"area type: {area.GetType().Name}");
Console.WriteLine($"PI type: {PI.GetType().Name}");
Console.WriteLine($"Area of circle: {area:F2}");
```

---

## Challenge Questions

### Challenge 1: Bill Splitter
**Difficulty**: Intermediate

#### Problem Statement
Create a restaurant bill splitter:
1. Input: Total bill amount, number of people, tip percentage
2. Output: Tip amount, total with tip, amount per person

#### Example Interaction
```
Enter total bill: 120
Enter number of people: 4
Enter tip percentage: 15
Tip amount: $18.00
Total with tip: $138.00
Each person pays: $34.50
```

#### Solution
```csharp
Console.Write("Enter total bill: ");
double bill = double.Parse(Console.ReadLine());

Console.Write("Enter number of people: ");
int people = int.Parse(Console.ReadLine());

Console.Write("Enter tip percentage: ");
double tipPercent = double.Parse(Console.ReadLine());

double tip = bill * (tipPercent / 100);
double totalWithTip = bill + tip;
double perPerson = totalWithTip / people;

Console.WriteLine($"Tip amount: ${tip:F2}");
Console.WriteLine($"Total with tip: ${totalWithTip:F2}");
Console.WriteLine($"Each person pays: ${perPerson:F2}");
```

---

### Challenge 2: Time Converter
**Difficulty**: Intermediate

#### Problem Statement
Convert seconds to hours, minutes, and remaining seconds.

#### Example Interaction
```
Enter total seconds: 3665
3665 seconds = 1 hour(s), 1 minute(s), 5 second(s)
```

#### Hint
Use integer division `/` and modulus `%`

#### Solution
```csharp
Console.Write("Enter total seconds: ");
int totalSeconds = int.Parse(Console.ReadLine());

int hours = totalSeconds / 3600;
int remainingAfterHours = totalSeconds % 3600;
int minutes = remainingAfterHours / 60;
int seconds = remainingAfterHours % 60;

Console.WriteLine($"{totalSeconds} seconds = {hours} hour(s), {minutes} minute(s), {seconds} second(s)");
```

---

## Week 1 Summary Checklist

- [ ] Can write and run a basic C# program
- [ ] Understand top-level statements vs traditional structure
- [ ] Can declare variables of different types (int, double, string, bool, char)
- [ ] Can read user input with Console.ReadLine()
- [ ] Can convert strings to numbers (int.Parse, double.Parse)
- [ ] Can perform arithmetic operations (+, -, *, /, %)
- [ ] Can use string interpolation ($"...")
- [ ] Can format numbers to decimal places ({value:F2})
- [ ] Understand const and var keywords
- [ ] Can use Math.PI and Math.Round

---

## Next Week Preview
**Week 2: Control Flow** - if/else, switch, loops (for, while, foreach)

---

*Questions: 15 | Challenges: 2 | Total: 17*
