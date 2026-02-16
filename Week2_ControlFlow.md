# Week 2: Control Flow & Decision Making

## Learning Objectives
By the end of this week, you will be able to:
- Use if, else if, and else statements for decision making
- Apply comparison and logical operators
- Implement switch statements and switch expressions
- Create loops using for, while, do-while, and foreach
- Control loop execution with break and continue
- Solve problems requiring nested control structures

> **Official Reference**: [C# Statements](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)

---

## Activity 1: Comparison Operators

### Concept
Comparison operators return `bool` (true/false):

| Operator | Description | Example |
|----------|-------------|---------|
| `==` | Equal to | `5 == 5` → true |
| `!=` | Not equal to | `5 != 3` → true |
| `>` | Greater than | `5 > 3` → true |
| `<` | Less than | `5 < 3` → false |
| `>=` | Greater than or equal | `5 >= 5` → true |
| `<=` | Less than or equal | `3 <= 5` → true |

### Practice
```csharp
int a = 10, b = 20;
Console.WriteLine(a == b);  // False
Console.WriteLine(a != b);  // True
Console.WriteLine(a < b);   // True
Console.WriteLine(a >= 10); // True
```

---

## Activity 2: Logical Operators

### Concept
Combine multiple conditions:

| Operator | Description | Example |
|----------|-------------|---------|
| `&&` | AND (both must be true) | `true && false` → false |
| `\|\|` | OR (at least one true) | `true \|\| false` → true |
| `!` | NOT (reverses) | `!true` → false |

### Practice
```csharp
int age = 25;
bool hasLicense = true;

// AND - both conditions must be true
bool canDrive = age >= 18 && hasLicense;  // true

// OR - at least one must be true
bool canEnter = age >= 21 || hasLicense;  // true

// NOT - reverses the boolean
bool isMinor = !(age >= 18);  // false
```

---

## Activity 3: If-Else Statements

### Concept (From Microsoft Docs)
```csharp
if (condition)
{
    // executes if condition is true
}
else if (anotherCondition)
{
    // executes if first is false and this is true
}
else
{
    // executes if all conditions are false
}
```

---

## Questions

### Question 1: Positive or Negative
**Topic**: Simple if-else
**Difficulty**: Beginner

#### Problem Statement
Write a program that checks if a number is positive, negative, or zero.

#### Example Interaction
```
Enter a number: -5
The number is negative.
```

#### Solution
```csharp
Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());

if (number > 0)
{
    Console.WriteLine("The number is positive.");
}
else if (number < 0)
{
    Console.WriteLine("The number is negative.");
}
else
{
    Console.WriteLine("The number is zero.");
}
```

---

### Question 2: Even or Odd
**Topic**: Modulus operator with if-else
**Difficulty**: Beginner

#### Problem Statement
Write a program that determines if a number is even or odd.

#### Hint
A number is even if `number % 2 == 0`

#### Example Interaction
```
Enter a number: 7
7 is odd.
```

#### Solution
```csharp
Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());

if (number % 2 == 0)
{
    Console.WriteLine($"{number} is even.");
}
else
{
    Console.WriteLine($"{number} is odd.");
}
```

---

### Question 3: Grade Calculator
**Topic**: Multiple conditions (else if)
**Difficulty**: Beginner

#### Problem Statement
Write a program that converts a score to a letter grade:
- 90-100: A
- 80-89: B
- 70-79: C
- 60-69: D
- Below 60: F

#### Example Interaction
```
Enter your score: 85
Your grade is: B
```

#### Solution
```csharp
Console.Write("Enter your score: ");
int score = int.Parse(Console.ReadLine());

string grade;

if (score >= 90 && score <= 100)
{
    grade = "A";
}
else if (score >= 80)
{
    grade = "B";
}
else if (score >= 70)
{
    grade = "C";
}
else if (score >= 60)
{
    grade = "D";
}
else
{
    grade = "F";
}

Console.WriteLine($"Your grade is: {grade}");
```

---

### Question 4: Voting Eligibility
**Topic**: Logical AND operator
**Difficulty**: Beginner

#### Problem Statement
Check if a person can vote. Requirements:
- Must be 18 or older
- Must be a citizen

#### Example Interaction
```
Enter your age: 20
Are you a citizen? (yes/no): yes
You are eligible to vote!
```

#### Solution
```csharp
Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());

Console.Write("Are you a citizen? (yes/no): ");
string citizenInput = Console.ReadLine().ToLower();
bool isCitizen = citizenInput == "yes";

if (age >= 18 && isCitizen)
{
    Console.WriteLine("You are eligible to vote!");
}
else if (age < 18)
{
    Console.WriteLine("You are too young to vote.");
}
else
{
    Console.WriteLine("You must be a citizen to vote.");
}
```

---

### Question 5: Largest of Three Numbers
**Topic**: Nested if-else
**Difficulty**: Beginner

#### Problem Statement
Find the largest among three numbers entered by the user.

#### Example Interaction
```
Enter first number: 25
Enter second number: 67
Enter third number: 42
The largest number is: 67
```

#### Solution
```csharp
Console.Write("Enter first number: ");
int a = int.Parse(Console.ReadLine());

Console.Write("Enter second number: ");
int b = int.Parse(Console.ReadLine());

Console.Write("Enter third number: ");
int c = int.Parse(Console.ReadLine());

int largest;

if (a >= b && a >= c)
{
    largest = a;
}
else if (b >= a && b >= c)
{
    largest = b;
}
else
{
    largest = c;
}

Console.WriteLine($"The largest number is: {largest}");
```

---

### Question 6: Leap Year Checker
**Topic**: Complex logical conditions
**Difficulty**: Intermediate

#### Concept Activity
A year is a leap year if:
- Divisible by 4 AND
- (NOT divisible by 100 OR divisible by 400)

#### Problem Statement
Write a program to check if a year is a leap year.

#### Example Interaction
```
Enter a year: 2024
2024 is a leap year.
```

#### Solution
```csharp
Console.Write("Enter a year: ");
int year = int.Parse(Console.ReadLine());

bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

if (isLeapYear)
{
    Console.WriteLine($"{year} is a leap year.");
}
else
{
    Console.WriteLine($"{year} is not a leap year.");
}
```

---

### Question 7: Switch Statement - Day of Week
**Topic**: Switch statement
**Difficulty**: Beginner

#### Concept Activity
```csharp
switch (variable)
{
    case value1:
        // code
        break;
    case value2:
        // code
        break;
    default:
        // if no case matches
        break;
}
```

#### Problem Statement
Write a program that takes a number (1-7) and prints the day name.

#### Example Interaction
```
Enter day number (1-7): 3
Wednesday
```

#### Solution
```csharp
Console.Write("Enter day number (1-7): ");
int day = int.Parse(Console.ReadLine());

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    case 4:
        Console.WriteLine("Thursday");
        break;
    case 5:
        Console.WriteLine("Friday");
        break;
    case 6:
        Console.WriteLine("Saturday");
        break;
    case 7:
        Console.WriteLine("Sunday");
        break;
    default:
        Console.WriteLine("Invalid day number!");
        break;
}
```

---

### Question 8: Switch Expression - Calculator
**Topic**: Modern switch expression (C# 8+)
**Difficulty**: Intermediate

#### Concept Activity
Modern switch expression syntax:
```csharp
string result = variable switch
{
    value1 => "result1",
    value2 => "result2",
    _ => "default"  // _ is the discard pattern (default)
};
```

#### Problem Statement
Create a simple calculator using switch expression:
- Input: two numbers and an operator (+, -, *, /)
- Output: the result

#### Example Interaction
```
Enter first number: 10
Enter operator (+, -, *, /): *
Enter second number: 5
Result: 50
```

#### Solution
```csharp
Console.Write("Enter first number: ");
double num1 = double.Parse(Console.ReadLine());

Console.Write("Enter operator (+, -, *, /): ");
char op = Console.ReadLine()[0];

Console.Write("Enter second number: ");
double num2 = double.Parse(Console.ReadLine());

double result = op switch
{
    '+' => num1 + num2,
    '-' => num1 - num2,
    '*' => num1 * num2,
    '/' => num2 != 0 ? num1 / num2 : double.NaN,
    _ => double.NaN
};

if (double.IsNaN(result))
{
    Console.WriteLine("Invalid operation!");
}
else
{
    Console.WriteLine($"Result: {result}");
}
```

---

### Question 9: For Loop - Counting
**Topic**: Basic for loop
**Difficulty**: Beginner

#### Concept Activity
```csharp
for (initialization; condition; increment)
{
    // code to repeat
}

// Example: Print 1 to 5
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
```

#### Problem Statement
Print numbers from 1 to N, where N is entered by user.

#### Example Interaction
```
Enter N: 5
1
2
3
4
5
```

#### Solution
```csharp
Console.Write("Enter N: ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.WriteLine(i);
}
```

---

### Question 10: Sum of Numbers
**Topic**: Loop with accumulator
**Difficulty**: Beginner

#### Problem Statement
Calculate the sum of numbers from 1 to N.

#### Example Interaction
```
Enter N: 5
Sum of 1 to 5 = 15
```

#### Solution
```csharp
Console.Write("Enter N: ");
int n = int.Parse(Console.ReadLine());

int sum = 0;
for (int i = 1; i <= n; i++)
{
    sum += i;  // same as: sum = sum + i
}

Console.WriteLine($"Sum of 1 to {n} = {sum}");
```

---

### Question 11: Multiplication Table
**Topic**: For loop application
**Difficulty**: Beginner

#### Problem Statement
Print the multiplication table for a given number.

#### Example Interaction
```
Enter a number: 5
5 x 1 = 5
5 x 2 = 10
5 x 3 = 15
5 x 4 = 20
5 x 5 = 25
5 x 6 = 30
5 x 7 = 35
5 x 8 = 40
5 x 9 = 45
5 x 10 = 50
```

#### Solution
```csharp
Console.Write("Enter a number: ");
int num = int.Parse(Console.ReadLine());

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{num} x {i} = {num * i}");
}
```

---

### Question 12: While Loop - Password Validation
**Topic**: While loop
**Difficulty**: Intermediate

#### Concept Activity
```csharp
while (condition)
{
    // repeats while condition is true
}
```

#### Problem Statement
Create a password checker that keeps asking until correct password is entered.
- Correct password: "secret123"
- Maximum 3 attempts

#### Example Interaction
```
Enter password: wrong
Incorrect! 2 attempts remaining.
Enter password: secret123
Access granted!
```

#### Solution
```csharp
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
```

---

### Question 13: Do-While Loop - Menu System
**Topic**: Do-while loop
**Difficulty**: Intermediate

#### Concept Activity
Do-while executes at least once:
```csharp
do
{
    // code executes at least once
} while (condition);
```

#### Problem Statement
Create a menu that keeps showing until user chooses to exit:
1. Say Hello
2. Show Date
3. Exit

#### Example Interaction
```
=== MENU ===
1. Say Hello
2. Show Date
3. Exit
Choose option: 1
Hello, User!

=== MENU ===
1. Say Hello
2. Show Date
3. Exit
Choose option: 3
Goodbye!
```

#### Solution
```csharp
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
```

---

### Question 14: Factorial Calculator
**Topic**: Loop with multiplication
**Difficulty**: Intermediate

#### Problem Statement
Calculate factorial of N (N! = 1 × 2 × 3 × ... × N)

#### Example Interaction
```
Enter N: 5
5! = 120
```

#### Solution
```csharp
Console.Write("Enter N: ");
int n = int.Parse(Console.ReadLine());

long factorial = 1;
for (int i = 1; i <= n; i++)
{
    factorial *= i;
}

Console.WriteLine($"{n}! = {factorial}");
```

---

### Question 15: Prime Number Checker
**Topic**: Loop with break
**Difficulty**: Intermediate

#### Problem Statement
Check if a number is prime. A prime number is only divisible by 1 and itself.

#### Example Interaction
```
Enter a number: 17
17 is a prime number.
```

#### Solution
```csharp
Console.Write("Enter a number: ");
int num = int.Parse(Console.ReadLine());

bool isPrime = true;

if (num <= 1)
{
    isPrime = false;
}
else
{
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
        {
            isPrime = false;
            break;
        }
    }
}

if (isPrime)
{
    Console.WriteLine($"{num} is a prime number.");
}
else
{
    Console.WriteLine($"{num} is not a prime number.");
}
```

---

### Question 16: Fibonacci Sequence
**Topic**: Loop with previous values
**Difficulty**: Intermediate

#### Problem Statement
Print the first N numbers of Fibonacci sequence.
Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, ... (each number is sum of previous two)

#### Example Interaction
```
Enter N: 8
Fibonacci sequence: 0 1 1 2 3 5 8 13
```

#### Solution
```csharp
Console.Write("Enter N: ");
int n = int.Parse(Console.ReadLine());

int a = 0, b = 1;

Console.Write("Fibonacci sequence: ");

for (int i = 0; i < n; i++)
{
    Console.Write(a + " ");
    int temp = a;
    a = b;
    b = temp + b;
}
Console.WriteLine();
```

---

### Question 17: Pattern - Right Triangle
**Topic**: Nested loops
**Difficulty**: Intermediate

#### Problem Statement
Print a right triangle pattern of stars.

#### Example Interaction
```
Enter rows: 5
*
**
***
****
*****
```

#### Solution
```csharp
Console.Write("Enter rows: ");
int rows = int.Parse(Console.ReadLine());

for (int i = 1; i <= rows; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}
```

---

### Question 18: Pattern - Number Pyramid
**Topic**: Nested loops with numbers
**Difficulty**: Intermediate

#### Problem Statement
Print a number pyramid pattern.

#### Example Output (rows = 5)
```
    1
   12
  123
 1234
12345
```

#### Solution
```csharp
Console.Write("Enter rows: ");
int rows = int.Parse(Console.ReadLine());

for (int i = 1; i <= rows; i++)
{
    // Print spaces
    for (int j = 1; j <= rows - i; j++)
    {
        Console.Write(" ");
    }
    // Print numbers
    for (int k = 1; k <= i; k++)
    {
        Console.Write(k);
    }
    Console.WriteLine();
}
```

---

### Question 19: Number Guessing Game
**Topic**: Combining all concepts
**Difficulty**: Intermediate

#### Problem Statement
Create a number guessing game:
1. Computer picks a random number between 1 and 100
2. User tries to guess
3. Program says "Too high" or "Too low"
4. Count the attempts

#### Example Interaction
```
I'm thinking of a number between 1 and 100.
Enter your guess: 50
Too low!
Enter your guess: 75
Too high!
Enter your guess: 63
Correct! You guessed it in 3 attempts.
```

#### Solution
```csharp
Random random = new Random();
int secretNumber = random.Next(1, 101);  // 1 to 100
int attempts = 0;
int guess;

Console.WriteLine("I'm thinking of a number between 1 and 100.");

do
{
    Console.Write("Enter your guess: ");
    guess = int.Parse(Console.ReadLine());
    attempts++;

    if (guess < secretNumber)
    {
        Console.WriteLine("Too low!");
    }
    else if (guess > secretNumber)
    {
        Console.WriteLine("Too high!");
    }
    else
    {
        Console.WriteLine($"Correct! You guessed it in {attempts} attempts.");
    }
} while (guess != secretNumber);
```

---

### Question 20: Break and Continue
**Topic**: Loop control statements
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// break - exits the loop completely
for (int i = 1; i <= 10; i++)
{
    if (i == 5) break;  // stops at 5
    Console.WriteLine(i);  // prints 1, 2, 3, 4
}

// continue - skips to next iteration
for (int i = 1; i <= 5; i++)
{
    if (i == 3) continue;  // skips 3
    Console.WriteLine(i);  // prints 1, 2, 4, 5
}
```

#### Problem Statement
Print numbers 1 to 20 but:
- Skip multiples of 3 (use continue)
- Stop if number is greater than 15 (use break)

#### Expected Output
```
1 2 4 5 7 8 10 11 13 14
```

#### Solution
```csharp
for (int i = 1; i <= 20; i++)
{
    if (i > 15)
    {
        break;
    }

    if (i % 3 == 0)
    {
        continue;
    }

    Console.Write(i + " ");
}
Console.WriteLine();
```

---

## Challenge Questions

### Challenge 1: ATM Simulator
**Difficulty**: Advanced

#### Problem Statement
Create a simple ATM:
- Starting balance: $1000
- Menu: Check Balance, Deposit, Withdraw, Exit
- Validate withdrawal (can't withdraw more than balance)

#### Solution
```csharp
double balance = 1000.00;
int choice;

do
{
    Console.WriteLine("\n=== ATM MENU ===");
    Console.WriteLine("1. Check Balance");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Exit");
    Console.Write("Choose option: ");
    choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine($"Current balance: ${balance:F2}");
            break;
        case 2:
            Console.Write("Enter deposit amount: $");
            double deposit = double.Parse(Console.ReadLine());
            if (deposit > 0)
            {
                balance += deposit;
                Console.WriteLine($"Deposited ${deposit:F2}. New balance: ${balance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
            break;
        case 3:
            Console.Write("Enter withdrawal amount: $");
            double withdraw = double.Parse(Console.ReadLine());
            if (withdraw > 0 && withdraw <= balance)
            {
                balance -= withdraw;
                Console.WriteLine($"Withdrew ${withdraw:F2}. New balance: ${balance:F2}");
            }
            else if (withdraw > balance)
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
            break;
        case 4:
            Console.WriteLine("Thank you for using our ATM. Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
} while (choice != 4);
```

---

### Challenge 2: Diamond Pattern
**Difficulty**: Advanced

#### Problem Statement
Print a diamond pattern.

#### Example Output (rows = 5)
```
    *
   ***
  *****
 *******
*********
 *******
  *****
   ***
    *
```

#### Solution
```csharp
Console.Write("Enter rows: ");
int n = int.Parse(Console.ReadLine());

// Upper half
for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= n - i; j++)
        Console.Write(" ");
    for (int j = 1; j <= 2 * i - 1; j++)
        Console.Write("*");
    Console.WriteLine();
}

// Lower half
for (int i = n - 1; i >= 1; i--)
{
    for (int j = 1; j <= n - i; j++)
        Console.Write(" ");
    for (int j = 1; j <= 2 * i - 1; j++)
        Console.Write("*");
    Console.WriteLine();
}
```

---

## Week 2 Summary Checklist

- [ ] Can use comparison operators (==, !=, >, <, >=, <=)
- [ ] Can use logical operators (&&, ||, !)
- [ ] Can write if, else if, else statements
- [ ] Can use switch statements
- [ ] Can use modern switch expressions
- [ ] Can create for loops
- [ ] Can create while loops
- [ ] Can create do-while loops
- [ ] Can use break and continue
- [ ] Can create nested loops
- [ ] Can generate random numbers with Random class

---

## Next Week Preview
**Week 3: Arrays & Methods** - Arrays, foreach, methods, parameters, return values

---

*Questions: 20 | Challenges: 2 | Total: 22*
