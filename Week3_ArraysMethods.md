# Week 3: Arrays & Methods

## Learning Objectives
By the end of this week, you will be able to:
- Declare and initialize arrays
- Access and modify array elements
- Use foreach loops with arrays
- Work with multi-dimensional and jagged arrays
- Create and call methods with parameters
- Understand return types and value/reference passing
- Implement method overloading
- Write recursive methods

> **Official Reference**: [Arrays](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/) | [Methods](https://learn.microsoft.com/en-us/dotnet/csharp/methods)

---

## Activity 1: Understanding Arrays

### Concept
An array stores multiple values of the same type in a single variable.

```csharp
// Declaration and initialization
int[] numbers = new int[5];           // Creates array of 5 integers (all 0)
int[] scores = { 90, 85, 78, 92, 88 }; // Initialize with values
int[] values = new int[] { 1, 2, 3 }; // Alternative syntax

// Modern C# 12+ Collection Expression
int[] modern = [1, 2, 3, 4, 5];

// Accessing elements (0-based index)
int first = scores[0];   // 90
int last = scores[4];    // 88
scores[2] = 80;          // Change value at index 2

// Array length
int length = scores.Length;  // 5
```

### Key Points
- Arrays are **zero-indexed** (first element is at index 0)
- Array size is **fixed** after creation
- `.Length` property gives the number of elements
- `IndexOutOfRangeException` if accessing invalid index

---

## Activity 2: Understanding Methods

### Concept
Methods are reusable blocks of code that perform specific tasks.

```csharp
// Method structure
returnType MethodName(parameters)
{
    // code
    return value;  // if return type is not void
}

// Examples
void SayHello()  // void = no return value
{
    Console.WriteLine("Hello!");
}

int Add(int a, int b)  // returns int
{
    return a + b;
}

// Expression-bodied method (C# 6+)
int Multiply(int a, int b) => a * b;
```

---

## Questions

### Question 1: Array Declaration and Access
**Topic**: Basic arrays
**Difficulty**: Beginner

#### Problem Statement
Create an array of 5 integers, assign values, and print each element with its index.

#### Expected Output
```
Index 0: 10
Index 1: 20
Index 2: 30
Index 3: 40
Index 4: 50
```

#### Solution
```csharp
int[] numbers = { 10, 20, 30, 40, 50 };

for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine($"Index {i}: {numbers[i]}");
}
```

---

### Question 2: Array Sum and Average
**Topic**: Array iteration
**Difficulty**: Beginner

#### Problem Statement
Create an array of 5 numbers entered by the user. Calculate and display the sum and average.

#### Example Interaction
```
Enter 5 numbers:
Number 1: 10
Number 2: 20
Number 3: 30
Number 4: 40
Number 5: 50
Sum: 150
Average: 30
```

#### Solution
```csharp
int[] numbers = new int[5];

Console.WriteLine("Enter 5 numbers:");
for (int i = 0; i < 5; i++)
{
    Console.Write($"Number {i + 1}: ");
    numbers[i] = int.Parse(Console.ReadLine());
}

int sum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    sum += numbers[i];
}

double average = (double)sum / numbers.Length;

Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Average: {average}");
```

---

### Question 3: Foreach Loop
**Topic**: Foreach iteration
**Difficulty**: Beginner

#### Concept Activity
```csharp
// foreach - read-only iteration
int[] numbers = { 1, 2, 3, 4, 5 };

foreach (int num in numbers)
{
    Console.WriteLine(num);
}

// Note: Cannot modify elements with foreach
// foreach (int num in numbers)
// {
//     num = num * 2;  // ERROR!
// }
```

#### Problem Statement
Use `foreach` to print all elements of a string array containing weekday names.

#### Expected Output
```
Monday
Tuesday
Wednesday
Thursday
Friday
```

#### Solution
```csharp
string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

foreach (string day in weekdays)
{
    Console.WriteLine(day);
}
```

---

### Question 4: Find Maximum and Minimum
**Topic**: Array searching
**Difficulty**: Beginner

#### Problem Statement
Find the maximum and minimum values in an array of integers.

#### Example
```
Array: 45, 12, 78, 34, 89, 23
Maximum: 89
Minimum: 12
```

#### Solution
```csharp
int[] numbers = { 45, 12, 78, 34, 89, 23 };

int max = numbers[0];
int min = numbers[0];

foreach (int num in numbers)
{
    if (num > max) max = num;
    if (num < min) min = num;
}

Console.WriteLine($"Array: {string.Join(", ", numbers)}");
Console.WriteLine($"Maximum: {max}");
Console.WriteLine($"Minimum: {min}");
```

---

### Question 5: Reverse an Array
**Topic**: Array manipulation
**Difficulty**: Intermediate

#### Problem Statement
Reverse an array without using built-in methods.

#### Example
```
Original: 1, 2, 3, 4, 5
Reversed: 5, 4, 3, 2, 1
```

#### Solution
```csharp
int[] numbers = { 1, 2, 3, 4, 5 };

Console.WriteLine($"Original: {string.Join(", ", numbers)}");

// Reverse manually
int left = 0;
int right = numbers.Length - 1;

while (left < right)
{
    // Swap
    int temp = numbers[left];
    numbers[left] = numbers[right];
    numbers[right] = temp;

    left++;
    right--;
}

Console.WriteLine($"Reversed: {string.Join(", ", numbers)}");
```

---

### Question 6: Array Methods (Built-in)
**Topic**: Array class methods
**Difficulty**: Intermediate

#### Concept Activity
```csharp
int[] arr = { 5, 2, 8, 1, 9 };

Array.Sort(arr);           // Sorts: 1, 2, 5, 8, 9
Array.Reverse(arr);        // Reverses: 9, 8, 5, 2, 1
int index = Array.IndexOf(arr, 5);  // Finds index of 5
Array.Clear(arr, 0, 2);    // Sets first 2 elements to 0
bool exists = Array.Exists(arr, x => x > 5);  // True if any > 5
```

#### Problem Statement
Create an array of 6 numbers. Use built-in methods to:
1. Sort in ascending order
2. Find if number 50 exists
3. Find the index of a specific number

#### Solution
```csharp
int[] numbers = { 34, 12, 50, 78, 23, 50 };

Console.WriteLine($"Original: {string.Join(", ", numbers)}");

// Sort ascending
Array.Sort(numbers);
Console.WriteLine($"Sorted: {string.Join(", ", numbers)}");

// Check if 50 exists
bool exists = Array.Exists(numbers, x => x == 50);
Console.WriteLine($"Does 50 exist? {exists}");

// Find index of 50
int index = Array.IndexOf(numbers, 50);
Console.WriteLine($"First index of 50: {index}");

// Reverse
Array.Reverse(numbers);
Console.WriteLine($"Reversed: {string.Join(", ", numbers)}");
```

---

### Question 7: 2D Array - Matrix
**Topic**: Multi-dimensional arrays
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// 2D Array declaration
int[,] matrix = new int[3, 3];  // 3x3 matrix

// Initialize with values
int[,] grid = {
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

// Access element
int value = grid[1, 2];  // Row 1, Column 2 = 6

// Get dimensions
int rows = grid.GetLength(0);     // 3
int columns = grid.GetLength(1);  // 3
```

#### Problem Statement
Create a 3x3 matrix and print it in table format. Also calculate the sum of all elements.

#### Expected Output
```
1  2  3
4  5  6
7  8  9
Sum of all elements: 45
```

#### Solution
```csharp
int[,] matrix = {
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

int sum = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]}  ");
        sum += matrix[i, j];
    }
    Console.WriteLine();
}

Console.WriteLine($"Sum of all elements: {sum}");
```

---

### Question 8: Jagged Array
**Topic**: Array of arrays
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Jagged array - array of arrays (can have different lengths)
int[][] jagged = new int[3][];
jagged[0] = new int[] { 1, 2 };
jagged[1] = new int[] { 3, 4, 5 };
jagged[2] = new int[] { 6 };

// Or initialize directly
int[][] jagged2 = {
    new int[] { 1, 2 },
    new int[] { 3, 4, 5 },
    new int[] { 6, 7, 8, 9 }
};
```

#### Problem Statement
Create a jagged array representing student scores (different number of tests per student). Print each student's scores and average.

#### Expected Output
```
Student 1 scores: 85, 90, 78 (Average: 84.33)
Student 2 scores: 92, 88 (Average: 90.00)
Student 3 scores: 76, 85, 90, 95 (Average: 86.50)
```

#### Solution
```csharp
int[][] studentScores = {
    new int[] { 85, 90, 78 },
    new int[] { 92, 88 },
    new int[] { 76, 85, 90, 95 }
};

for (int i = 0; i < studentScores.Length; i++)
{
    int sum = 0;
    foreach (int score in studentScores[i])
    {
        sum += score;
    }
    double average = (double)sum / studentScores[i].Length;

    Console.WriteLine($"Student {i + 1} scores: {string.Join(", ", studentScores[i])} (Average: {average:F2})");
}
```

---

### Question 9: Simple Method - Greet
**Topic**: Void methods
**Difficulty**: Beginner

#### Problem Statement
Create a method `Greet` that takes a name and prints a greeting.

#### Expected Output
```
Hello, Ahmad! Welcome to C#.
Hello, Sara! Welcome to C#.
```

#### Solution
```csharp
// Method definition
void Greet(string name)
{
    Console.WriteLine($"Hello, {name}! Welcome to C#.");
}

// Method calls
Greet("Ahmad");
Greet("Sara");
```

---

### Question 10: Method with Return Value
**Topic**: Return types
**Difficulty**: Beginner

#### Problem Statement
Create a method `Add` that takes two integers and returns their sum.

#### Expected Output
```
5 + 3 = 8
10 + 20 = 30
```

#### Solution
```csharp
int Add(int a, int b)
{
    return a + b;
}

// Using the method
int result1 = Add(5, 3);
int result2 = Add(10, 20);

Console.WriteLine($"5 + 3 = {result1}");
Console.WriteLine($"10 + 20 = {result2}");
```

---

### Question 11: Method - Calculate Area
**Topic**: Methods with different shapes
**Difficulty**: Beginner

#### Problem Statement
Create methods to calculate area of:
- Rectangle (length × width)
- Circle (π × r²)
- Triangle (0.5 × base × height)

#### Solution
```csharp
double RectangleArea(double length, double width)
{
    return length * width;
}

double CircleArea(double radius)
{
    return Math.PI * radius * radius;
}

double TriangleArea(double baseLength, double height)
{
    return 0.5 * baseLength * height;
}

// Test the methods
Console.WriteLine($"Rectangle (5x3): {RectangleArea(5, 3)}");
Console.WriteLine($"Circle (r=4): {CircleArea(4):F2}");
Console.WriteLine($"Triangle (b=6, h=4): {TriangleArea(6, 4)}");
```

---

### Question 12: Method Overloading
**Topic**: Same name, different parameters
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Method overloading - same name, different signatures
int Add(int a, int b) => a + b;
double Add(double a, double b) => a + b;
int Add(int a, int b, int c) => a + b + c;

// Compiler chooses based on arguments
Add(5, 3);       // Calls int version
Add(5.5, 3.3);   // Calls double version
Add(1, 2, 3);    // Calls 3-parameter version
```

#### Problem Statement
Create overloaded `Multiply` methods for:
- Two integers
- Three integers
- Two doubles

#### Solution
```csharp
int Multiply(int a, int b)
{
    return a * b;
}

int Multiply(int a, int b, int c)
{
    return a * b * c;
}

double Multiply(double a, double b)
{
    return a * b;
}

Console.WriteLine($"Multiply(5, 3) = {Multiply(5, 3)}");
Console.WriteLine($"Multiply(2, 3, 4) = {Multiply(2, 3, 4)}");
Console.WriteLine($"Multiply(2.5, 4.0) = {Multiply(2.5, 4.0)}");
```

---

### Question 13: Default Parameters
**Topic**: Optional parameters
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Default parameter values
void Greet(string name, string greeting = "Hello")
{
    Console.WriteLine($"{greeting}, {name}!");
}

Greet("Ali");              // Hello, Ali!
Greet("Ali", "Welcome");   // Welcome, Ali!
```

#### Problem Statement
Create a method `PrintInfo` with:
- Required: name
- Optional: age (default 0), city (default "Unknown")

#### Solution
```csharp
void PrintInfo(string name, int age = 0, string city = "Unknown")
{
    Console.WriteLine($"Name: {name}");
    Console.WriteLine($"Age: {(age > 0 ? age.ToString() : "Not specified")}");
    Console.WriteLine($"City: {city}");
    Console.WriteLine();
}

PrintInfo("Ahmad");
PrintInfo("Sara", 25);
PrintInfo("Ali", 30, "Karachi");
```

---

### Question 14: Ref and Out Parameters
**Topic**: Pass by reference
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// ref - variable must be initialized before passing
void Double(ref int x)
{
    x = x * 2;
}

int num = 5;
Double(ref num);  // num is now 10

// out - variable is assigned inside the method
void GetValues(out int a, out int b)
{
    a = 10;
    b = 20;
}

GetValues(out int x, out int y);  // x=10, y=20
```

#### Problem Statement
Create a method `Divide` that returns both quotient and remainder using `out` parameters.

#### Example
```
10 ÷ 3 = 3 remainder 1
```

#### Solution
```csharp
void Divide(int dividend, int divisor, out int quotient, out int remainder)
{
    quotient = dividend / divisor;
    remainder = dividend % divisor;
}

int num1 = 10, num2 = 3;
Divide(num1, num2, out int q, out int r);

Console.WriteLine($"{num1} ÷ {num2} = {q} remainder {r}");
```

---

### Question 15: Params Keyword
**Topic**: Variable number of arguments
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// params allows variable number of arguments
int Sum(params int[] numbers)
{
    int total = 0;
    foreach (int n in numbers)
    {
        total += n;
    }
    return total;
}

Sum(1, 2);           // 3
Sum(1, 2, 3, 4, 5);  // 15
```

#### Problem Statement
Create a method `Average` that takes any number of integers and returns their average.

#### Solution
```csharp
double Average(params int[] numbers)
{
    if (numbers.Length == 0) return 0;

    int sum = 0;
    foreach (int n in numbers)
    {
        sum += n;
    }
    return (double)sum / numbers.Length;
}

Console.WriteLine($"Average(10, 20): {Average(10, 20)}");
Console.WriteLine($"Average(1, 2, 3, 4, 5): {Average(1, 2, 3, 4, 5)}");
Console.WriteLine($"Average(100): {Average(100)}");
```

---

### Question 16: Array as Method Parameter
**Topic**: Passing arrays to methods
**Difficulty**: Intermediate

#### Problem Statement
Create methods to:
1. Print all elements of an array
2. Calculate sum of array elements
3. Find the largest element

#### Solution
```csharp
void PrintArray(int[] arr)
{
    Console.WriteLine($"Array: [{string.Join(", ", arr)}]");
}

int SumArray(int[] arr)
{
    int sum = 0;
    foreach (int n in arr)
    {
        sum += n;
    }
    return sum;
}

int FindMax(int[] arr)
{
    int max = arr[0];
    foreach (int n in arr)
    {
        if (n > max) max = n;
    }
    return max;
}

// Test
int[] numbers = { 10, 45, 23, 67, 12, 89, 34 };

PrintArray(numbers);
Console.WriteLine($"Sum: {SumArray(numbers)}");
Console.WriteLine($"Maximum: {FindMax(numbers)}");
```

---

### Question 17: Recursive Method - Factorial
**Topic**: Recursion basics
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Recursion - method calls itself
// Must have:
// 1. Base case (stopping condition)
// 2. Recursive case (calls itself with smaller problem)

int Factorial(int n)
{
    if (n <= 1) return 1;        // Base case
    return n * Factorial(n - 1);  // Recursive case
}

// Factorial(5) = 5 * Factorial(4)
//              = 5 * 4 * Factorial(3)
//              = 5 * 4 * 3 * Factorial(2)
//              = 5 * 4 * 3 * 2 * Factorial(1)
//              = 5 * 4 * 3 * 2 * 1 = 120
```

#### Problem Statement
Implement factorial using recursion. Test with values 0, 1, 5, and 10.

#### Solution
```csharp
long Factorial(int n)
{
    if (n <= 1) return 1;
    return n * Factorial(n - 1);
}

Console.WriteLine($"0! = {Factorial(0)}");
Console.WriteLine($"1! = {Factorial(1)}");
Console.WriteLine($"5! = {Factorial(5)}");
Console.WriteLine($"10! = {Factorial(10)}");
```

---

### Question 18: Recursive Method - Fibonacci
**Topic**: Recursion with multiple calls
**Difficulty**: Intermediate

#### Problem Statement
Implement Fibonacci sequence using recursion.
F(n) = F(n-1) + F(n-2), where F(0)=0, F(1)=1

#### Expected Output
```
F(0) = 0
F(1) = 1
F(5) = 5
F(10) = 55
```

#### Solution
```csharp
int Fibonacci(int n)
{
    if (n <= 0) return 0;
    if (n == 1) return 1;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

Console.WriteLine($"F(0) = {Fibonacci(0)}");
Console.WriteLine($"F(1) = {Fibonacci(1)}");
Console.WriteLine($"F(5) = {Fibonacci(5)}");
Console.WriteLine($"F(10) = {Fibonacci(10)}");
```

---

### Question 19: Expression-Bodied Methods
**Topic**: Modern C# syntax
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Traditional method
int Add(int a, int b)
{
    return a + b;
}

// Expression-bodied (C# 6+) - for single expressions
int Add(int a, int b) => a + b;

// Works with void too
void PrintHello() => Console.WriteLine("Hello!");
```

#### Problem Statement
Rewrite these methods using expression-bodied syntax:
1. Square of a number
2. Is number even
3. Get full name from first and last name

#### Solution
```csharp
int Square(int n) => n * n;

bool IsEven(int n) => n % 2 == 0;

string FullName(string first, string last) => $"{first} {last}";

// Test
Console.WriteLine($"Square(5) = {Square(5)}");
Console.WriteLine($"IsEven(4) = {IsEven(4)}");
Console.WriteLine($"IsEven(7) = {IsEven(7)}");
Console.WriteLine($"FullName(\"Ahmad\", \"Khan\") = {FullName("Ahmad", "Khan")}");
```

---

### Question 20: Local Functions
**Topic**: Functions inside functions (C# 7+)
**Difficulty**: Intermediate

#### Concept Activity
```csharp
void OuterMethod()
{
    // Local function - only accessible within OuterMethod
    int LocalAdd(int a, int b)
    {
        return a + b;
    }

    Console.WriteLine(LocalAdd(5, 3));
}
```

#### Problem Statement
Create a method that calculates factorial using a local recursive function.

#### Solution
```csharp
long CalculateFactorial(int n)
{
    // Local function for recursion
    long Factorial(int num)
    {
        if (num <= 1) return 1;
        return num * Factorial(num - 1);
    }

    // Validate input
    if (n < 0)
    {
        Console.WriteLine("Error: Negative numbers not allowed");
        return -1;
    }

    return Factorial(n);
}

Console.WriteLine($"5! = {CalculateFactorial(5)}");
Console.WriteLine($"10! = {CalculateFactorial(10)}");
```

---

## Challenge Questions

### Challenge 1: Matrix Addition
**Difficulty**: Advanced

#### Problem Statement
Add two 3x3 matrices and display the result.

#### Solution
```csharp
int[,] AddMatrices(int[,] a, int[,] b)
{
    int rows = a.GetLength(0);
    int cols = a.GetLength(1);
    int[,] result = new int[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            result[i, j] = a[i, j] + b[i, j];
        }
    }
    return result;
}

void PrintMatrix(int[,] matrix, string name)
{
    Console.WriteLine($"{name}:");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],4}");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

// Test
int[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
int[,] matrix2 = { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

PrintMatrix(matrix1, "Matrix A");
PrintMatrix(matrix2, "Matrix B");
PrintMatrix(AddMatrices(matrix1, matrix2), "A + B");
```

---

### Challenge 2: Binary Search
**Difficulty**: Advanced

#### Problem Statement
Implement binary search algorithm to find an element in a sorted array.

#### Solution
```csharp
int BinarySearch(int[] arr, int target)
{
    int left = 0;
    int right = arr.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (arr[mid] == target)
        {
            return mid;  // Found
        }
        else if (arr[mid] < target)
        {
            left = mid + 1;  // Search right half
        }
        else
        {
            right = mid - 1;  // Search left half
        }
    }

    return -1;  // Not found
}

// Test
int[] sortedArray = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };

Console.WriteLine($"Array: [{string.Join(", ", sortedArray)}]");

int target = 23;
int result = BinarySearch(sortedArray, target);
Console.WriteLine($"Search for {target}: {(result >= 0 ? $"Found at index {result}" : "Not found")}");

target = 50;
result = BinarySearch(sortedArray, target);
Console.WriteLine($"Search for {target}: {(result >= 0 ? $"Found at index {result}" : "Not found")}");
```

---

### Challenge 3: Bubble Sort
**Difficulty**: Advanced

#### Problem Statement
Implement bubble sort algorithm to sort an array.

#### Solution
```csharp
void BubbleSort(int[] arr)
{
    int n = arr.Length;

    for (int i = 0; i < n - 1; i++)
    {
        bool swapped = false;

        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                // Swap
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
                swapped = true;
            }
        }

        // If no swaps, array is sorted
        if (!swapped) break;
    }
}

// Test
int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

Console.WriteLine($"Original: [{string.Join(", ", numbers)}]");
BubbleSort(numbers);
Console.WriteLine($"Sorted:   [{string.Join(", ", numbers)}]");
```

---

## Week 3 Summary Checklist

- [ ] Can declare and initialize arrays
- [ ] Can access and modify array elements
- [ ] Can iterate arrays with for and foreach
- [ ] Can find min, max, sum, average of arrays
- [ ] Can use Array class methods (Sort, Reverse, IndexOf)
- [ ] Understand 2D arrays and jagged arrays
- [ ] Can create void methods
- [ ] Can create methods with return values
- [ ] Can use method overloading
- [ ] Understand ref, out, and params keywords
- [ ] Can write recursive methods
- [ ] Can use expression-bodied methods

---

## Next Week Preview
**Week 4: Object-Oriented Programming** - Classes, objects, constructors, properties, inheritance, polymorphism

---

*Questions: 20 | Challenges: 3 | Total: 23*
