# Week 4: Object-Oriented Programming (OOP)

## Learning Objectives
By the end of this week, you will be able to:
- Create classes and instantiate objects
- Implement constructors (default, parameterized)
- Use properties with getters and setters
- Apply access modifiers for encapsulation
- Implement inheritance with base and derived classes
- Use polymorphism with virtual and override
- Create abstract classes and interfaces
- Understand static members and methods

> **Official Reference**: [Object-Oriented Programming](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/)

---

## Activity 1: Understanding Classes and Objects

### Concept (From Microsoft Docs)
A **class** is a blueprint that defines data (fields) and behavior (methods).
An **object** is an instance of a class.

```csharp
// Class definition
class Car
{
    // Fields (data)
    public string Brand;
    public string Model;
    public int Year;

    // Method (behavior)
    public void DisplayInfo()
    {
        Console.WriteLine($"{Year} {Brand} {Model}");
    }
}

// Creating objects
Car myCar = new Car();
myCar.Brand = "Toyota";
myCar.Model = "Camry";
myCar.Year = 2023;
myCar.DisplayInfo();  // Output: 2023 Toyota Camry
```

### Key Points
- `class` keyword defines a class
- `new` keyword creates an object (instance)
- Objects have their own copy of fields
- Methods define what objects can do

---

## Activity 2: Understanding Access Modifiers

### Concept
Access modifiers control visibility of class members:

| Modifier | Accessible From |
|----------|-----------------|
| `public` | Anywhere |
| `private` | Same class only (default for members) |
| `protected` | Same class and derived classes |
| `internal` | Same assembly (project) |
| `protected internal` | Same assembly OR derived classes |

```csharp
class Person
{
    public string Name;       // Accessible anywhere
    private int age;          // Only within Person class
    protected string Id;      // Person and derived classes
}
```

---

## Questions

### Question 1: Simple Class - Person
**Topic**: Class basics
**Difficulty**: Beginner

#### Problem Statement
Create a `Person` class with:
- Fields: Name, Age
- Method: `Introduce()` that prints "Hi, I'm [Name] and I'm [Age] years old."

Create two Person objects and call their Introduce methods.

#### Expected Output
```
Hi, I'm Ahmad and I'm 25 years old.
Hi, I'm Sara and I'm 22 years old.
```

#### Solution
```csharp
class Person
{
    public string Name;
    public int Age;

    public void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
    }
}

// Main code
Person person1 = new Person();
person1.Name = "Ahmad";
person1.Age = 25;

Person person2 = new Person();
person2.Name = "Sara";
person2.Age = 22;

person1.Introduce();
person2.Introduce();
```

---

### Question 2: Constructor
**Topic**: Parameterized constructor
**Difficulty**: Beginner

#### Concept Activity
```csharp
class Car
{
    public string Brand;
    public string Model;

    // Default constructor (no parameters)
    public Car()
    {
        Brand = "Unknown";
        Model = "Unknown";
    }

    // Parameterized constructor
    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }
}

Car car1 = new Car();                    // Uses default constructor
Car car2 = new Car("Honda", "Civic");    // Uses parameterized constructor
```

#### Problem Statement
Create a `Book` class with:
- Fields: Title, Author, Year
- Parameterized constructor
- Method: `GetInfo()` returns formatted string

#### Expected Output
```
"The Great Gatsby" by F. Scott Fitzgerald (1925)
"1984" by George Orwell (1949)
```

#### Solution
```csharp
class Book
{
    public string Title;
    public string Author;
    public int Year;

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public string GetInfo()
    {
        return $"\"{Title}\" by {Author} ({Year})";
    }
}

// Main code
Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925);
Book book2 = new Book("1984", "George Orwell", 1949);

Console.WriteLine(book1.GetInfo());
Console.WriteLine(book2.GetInfo());
```

---

### Question 3: Properties
**Topic**: Getters and setters
**Difficulty**: Beginner

#### Concept Activity
```csharp
class Person
{
    // Auto-implemented property
    public string Name { get; set; }

    // Property with backing field
    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value <= 150)
                age = value;
        }
    }

    // Read-only property
    public bool IsAdult => Age >= 18;

    // Expression-bodied property (C# 6+)
    public string Greeting => $"Hello, {Name}!";
}
```

#### Problem Statement
Create a `BankAccount` class with:
- Property: AccountNumber (read-only, set in constructor)
- Property: Balance (private set, with validation - no negative)
- Method: `Deposit(amount)` and `Withdraw(amount)`

#### Solution
```csharp
class BankAccount
{
    public string AccountNumber { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountNumber, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance >= 0 ? initialBalance : 0;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${Balance:F2}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${Balance:F2}");
            return true;
        }
        Console.WriteLine("Insufficient funds or invalid amount.");
        return false;
    }
}

// Main code
BankAccount account = new BankAccount("ACC001", 1000);
Console.WriteLine($"Account: {account.AccountNumber}");
Console.WriteLine($"Initial Balance: ${account.Balance:F2}");

account.Deposit(500);
account.Withdraw(200);
account.Withdraw(2000);  // Should fail
```

---

### Question 4: Constructor Chaining
**Topic**: this() constructor
**Difficulty**: Intermediate

#### Concept Activity
```csharp
class Employee
{
    public string Name;
    public string Department;
    public double Salary;

    // Main constructor
    public Employee(string name, string department, double salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }

    // Chained constructor - calls the main constructor
    public Employee(string name) : this(name, "General", 30000)
    {
    }

    // Another chained constructor
    public Employee() : this("Unknown")
    {
    }
}
```

#### Problem Statement
Create a `Product` class with constructor chaining:
- Full constructor: Name, Price, Quantity
- Constructor with Name and Price (Quantity defaults to 0)
- Constructor with Name only (Price defaults to 0, Quantity defaults to 0)

#### Solution
```csharp
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // Full constructor
    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Chained constructors
    public Product(string name, decimal price) : this(name, price, 0) { }

    public Product(string name) : this(name, 0, 0) { }

    public void Display()
    {
        Console.WriteLine($"Product: {Name}, Price: ${Price:F2}, Qty: {Quantity}");
    }
}

// Main code
Product p1 = new Product("Laptop", 999.99m, 10);
Product p2 = new Product("Mouse", 29.99m);
Product p3 = new Product("Keyboard");

p1.Display();
p2.Display();
p3.Display();
```

---

### Question 5: Encapsulation
**Topic**: Private fields with public properties
**Difficulty**: Intermediate

#### Problem Statement
Create a `Student` class that encapsulates:
- Name (required, cannot be empty)
- Grade (must be between 0 and 100)
- Computed property: Status (Pass if grade >= 60, else Fail)

#### Solution
```csharp
class Student
{
    private string name;
    private int grade;

    public string Name
    {
        get => name;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                throw new ArgumentException("Name cannot be empty");
        }
    }

    public int Grade
    {
        get => grade;
        set
        {
            if (value >= 0 && value <= 100)
                grade = value;
            else
                Console.WriteLine("Grade must be between 0 and 100");
        }
    }

    public string Status => Grade >= 60 ? "Pass" : "Fail";

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Student: {Name}, Grade: {Grade}, Status: {Status}");
    }
}

// Main code
Student s1 = new Student("Ahmad", 85);
Student s2 = new Student("Sara", 55);

s1.DisplayInfo();
s2.DisplayInfo();

s1.Grade = 150;  // Should show error message
s1.DisplayInfo();
```

---

### Question 6: Static Members
**Topic**: Static fields and methods
**Difficulty**: Intermediate

#### Concept Activity
```csharp
class Counter
{
    // Static field - shared by all instances
    public static int TotalCount = 0;

    // Instance field - each object has its own
    public int Id;

    public Counter()
    {
        TotalCount++;
        Id = TotalCount;
    }

    // Static method - called on class, not instance
    public static void DisplayTotal()
    {
        Console.WriteLine($"Total objects created: {TotalCount}");
    }
}

Counter c1 = new Counter();  // TotalCount = 1
Counter c2 = new Counter();  // TotalCount = 2
Counter.DisplayTotal();      // "Total objects created: 2"
```

#### Problem Statement
Create a `Employee` class that:
- Tracks total number of employees (static)
- Auto-generates employee ID (EMP001, EMP002, etc.)
- Has static method to get total employee count

#### Solution
```csharp
class Employee
{
    private static int employeeCount = 0;

    public string EmployeeId { get; }
    public string Name { get; set; }
    public string Department { get; set; }

    public Employee(string name, string department)
    {
        employeeCount++;
        EmployeeId = $"EMP{employeeCount:D3}";
        Name = name;
        Department = department;
    }

    public static int GetTotalEmployees() => employeeCount;

    public void Display()
    {
        Console.WriteLine($"{EmployeeId}: {Name} ({Department})");
    }
}

// Main code
Employee e1 = new Employee("Ahmad", "IT");
Employee e2 = new Employee("Sara", "HR");
Employee e3 = new Employee("Ali", "Finance");

e1.Display();
e2.Display();
e3.Display();

Console.WriteLine($"\nTotal Employees: {Employee.GetTotalEmployees()}");
```

---

### Question 7: Inheritance
**Topic**: Base and derived classes
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Base class
class Animal
{
    public string Name { get; set; }

    public void Eat()
    {
        Console.WriteLine($"{Name} is eating.");
    }
}

// Derived class
class Dog : Animal  // Dog inherits from Animal
{
    public string Breed { get; set; }

    public void Bark()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

Dog dog = new Dog();
dog.Name = "Buddy";    // Inherited from Animal
dog.Breed = "Labrador";
dog.Eat();             // Inherited method
dog.Bark();            // Dog's own method
```

#### Problem Statement
Create:
- Base class `Vehicle` with: Brand, Model, Year, `DisplayInfo()`
- Derived class `Car` with: NumberOfDoors, `Honk()`
- Derived class `Motorcycle` with: HasSidecar, `Wheelie()`

#### Solution
```csharp
class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Year} {Brand} {Model}");
    }
}

class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    public Car(string brand, string model, int year, int doors)
        : base(brand, model, year)
    {
        NumberOfDoors = doors;
    }

    public void Honk()
    {
        Console.WriteLine($"{Brand} {Model} says: Beep beep!");
    }
}

class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public Motorcycle(string brand, string model, int year, bool hasSidecar)
        : base(brand, model, year)
    {
        HasSidecar = hasSidecar;
    }

    public void Wheelie()
    {
        Console.WriteLine($"{Brand} {Model} does a wheelie!");
    }
}

// Main code
Car car = new Car("Toyota", "Camry", 2023, 4);
Motorcycle bike = new Motorcycle("Harley", "Sportster", 2022, false);

car.DisplayInfo();
car.Honk();
Console.WriteLine($"Doors: {car.NumberOfDoors}\n");

bike.DisplayInfo();
bike.Wheelie();
Console.WriteLine($"Has Sidecar: {bike.HasSidecar}");
```

---

### Question 8: Method Overriding (Polymorphism)
**Topic**: virtual and override
**Difficulty**: Intermediate

#### Concept Activity
```csharp
class Animal
{
    public string Name { get; set; }

    // virtual - can be overridden
    public virtual void MakeSound()
    {
        Console.WriteLine("Some generic sound");
    }
}

class Dog : Animal
{
    // override - provides new implementation
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }
}

// Polymorphism in action
Animal myAnimal = new Dog { Name = "Buddy" };
myAnimal.MakeSound();  // "Buddy says: Woof!"
```

#### Problem Statement
Create a `Shape` base class with virtual `CalculateArea()` method.
Create derived classes: `Rectangle`, `Circle`, `Triangle` that override the area calculation.

#### Solution
```csharp
class Shape
{
    public string Name { get; set; }

    public virtual double CalculateArea()
    {
        return 0;
    }

    public void DisplayArea()
    {
        Console.WriteLine($"{Name} Area: {CalculateArea():F2}");
    }
}

class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Name = "Rectangle";
        Length = length;
        Width = width;
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Name = "Circle";
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double baseLength, double height)
    {
        Name = "Triangle";
        Base = baseLength;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }
}

// Main code - Polymorphism
Shape[] shapes = {
    new Rectangle(5, 3),
    new Circle(4),
    new Triangle(6, 4)
};

foreach (Shape shape in shapes)
{
    shape.DisplayArea();
}
```

---

### Question 9: Abstract Classes
**Topic**: Abstract classes and methods
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Abstract class - cannot be instantiated
abstract class Animal
{
    public string Name { get; set; }

    // Abstract method - MUST be overridden
    public abstract void MakeSound();

    // Regular method - optional to override
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping...");
    }
}

class Dog : Animal
{
    public override void MakeSound()  // Required
    {
        Console.WriteLine("Woof!");
    }
}

// Animal a = new Animal();  // ERROR! Cannot instantiate abstract class
Animal dog = new Dog();      // OK - using derived class
```

#### Problem Statement
Create an abstract `Employee` class with:
- Properties: Name, BaseSalary
- Abstract method: `CalculateSalary()`
- Regular method: `DisplayInfo()`

Create derived classes:
- `FullTimeEmployee`: salary = BaseSalary + bonus
- `PartTimeEmployee`: salary = hours × hourlyRate

#### Solution
```csharp
abstract class Employee
{
    public string Name { get; set; }
    public decimal BaseSalary { get; set; }

    public Employee(string name, decimal baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    public abstract decimal CalculateSalary();

    public void DisplayInfo()
    {
        Console.WriteLine($"Employee: {Name}");
        Console.WriteLine($"Salary: ${CalculateSalary():F2}");
        Console.WriteLine();
    }
}

class FullTimeEmployee : Employee
{
    public decimal Bonus { get; set; }

    public FullTimeEmployee(string name, decimal baseSalary, decimal bonus)
        : base(name, baseSalary)
    {
        Bonus = bonus;
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + Bonus;
    }
}

class PartTimeEmployee : Employee
{
    public int HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }

    public PartTimeEmployee(string name, int hours, decimal hourlyRate)
        : base(name, 0)
    {
        HoursWorked = hours;
        HourlyRate = hourlyRate;
    }

    public override decimal CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }
}

// Main code
Employee[] employees = {
    new FullTimeEmployee("Ahmad", 5000, 1000),
    new PartTimeEmployee("Sara", 80, 25)
};

foreach (Employee emp in employees)
{
    emp.DisplayInfo();
}
```

---

### Question 10: Interfaces
**Topic**: Interface definition and implementation
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Interface - defines a contract
interface IPlayable
{
    void Play();
    void Pause();
    void Stop();
}

// Class implements interface - MUST provide all methods
class MusicPlayer : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Playing music...");
    }

    public void Pause()
    {
        Console.WriteLine("Music paused.");
    }

    public void Stop()
    {
        Console.WriteLine("Music stopped.");
    }
}

// Multiple interfaces
interface IRecordable
{
    void Record();
}

class VideoPlayer : IPlayable, IRecordable
{
    public void Play() => Console.WriteLine("Playing video...");
    public void Pause() => Console.WriteLine("Video paused.");
    public void Stop() => Console.WriteLine("Video stopped.");
    public void Record() => Console.WriteLine("Recording...");
}
```

#### Problem Statement
Create:
- Interface `IShape` with: `double CalculateArea()`, `double CalculatePerimeter()`
- Classes `Rectangle` and `Circle` implementing `IShape`

#### Solution
```csharp
interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
    void DisplayInfo();
}

class Rectangle : IShape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double CalculateArea() => Length * Width;

    public double CalculatePerimeter() => 2 * (Length + Width);

    public void DisplayInfo()
    {
        Console.WriteLine($"Rectangle ({Length} x {Width})");
        Console.WriteLine($"  Area: {CalculateArea():F2}");
        Console.WriteLine($"  Perimeter: {CalculatePerimeter():F2}");
    }
}

class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea() => Math.PI * Radius * Radius;

    public double CalculatePerimeter() => 2 * Math.PI * Radius;

    public void DisplayInfo()
    {
        Console.WriteLine($"Circle (radius: {Radius})");
        Console.WriteLine($"  Area: {CalculateArea():F2}");
        Console.WriteLine($"  Perimeter: {CalculatePerimeter():F2}");
    }
}

// Main code
IShape[] shapes = {
    new Rectangle(5, 3),
    new Circle(4)
};

foreach (IShape shape in shapes)
{
    shape.DisplayInfo();
    Console.WriteLine();
}
```

---

### Question 11: Sealed Classes
**Topic**: Preventing inheritance
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// sealed - cannot be inherited
sealed class FinalClass
{
    public void DoSomething()
    {
        Console.WriteLine("This class cannot be inherited.");
    }
}

// class ChildClass : FinalClass { }  // ERROR!

// sealed method - prevents further overriding
class Animal
{
    public virtual void MakeSound() { }
}

class Dog : Animal
{
    public sealed override void MakeSound()  // Can't be overridden further
    {
        Console.WriteLine("Woof!");
    }
}
```

#### Problem Statement
Create a `Configuration` sealed class with:
- Static readonly properties for app settings
- Static method to display all settings

#### Solution
```csharp
sealed class Configuration
{
    public static string AppName { get; } = "MyApp";
    public static string Version { get; } = "1.0.0";
    public static int MaxConnections { get; } = 100;
    public static bool DebugMode { get; } = true;

    public static void DisplaySettings()
    {
        Console.WriteLine("=== Application Configuration ===");
        Console.WriteLine($"App Name: {AppName}");
        Console.WriteLine($"Version: {Version}");
        Console.WriteLine($"Max Connections: {MaxConnections}");
        Console.WriteLine($"Debug Mode: {DebugMode}");
    }
}

// Main code
Configuration.DisplaySettings();
```

---

### Question 12: Enums
**Topic**: Enumeration types
**Difficulty**: Beginner

#### Concept Activity
```csharp
// Enum - set of named constants
enum DayOfWeek
{
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

DayOfWeek today = DayOfWeek.Wednesday;
Console.WriteLine(today);        // Wednesday
Console.WriteLine((int)today);   // 3
```

#### Problem Statement
Create:
- Enum `OrderStatus` with: Pending, Processing, Shipped, Delivered, Cancelled
- Class `Order` that uses the enum
- Method to display order with status

#### Solution
```csharp
enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

class Order
{
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public OrderStatus Status { get; set; }

    public Order(int id, string product)
    {
        OrderId = id;
        ProductName = product;
        Status = OrderStatus.Pending;
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Order {OrderId} status updated to: {Status}");
    }

    public void Display()
    {
        Console.WriteLine($"Order #{OrderId}: {ProductName} - {Status}");
    }
}

// Main code
Order order = new Order(1001, "Laptop");
order.Display();

order.UpdateStatus(OrderStatus.Processing);
order.UpdateStatus(OrderStatus.Shipped);
order.Display();
```

---

### Question 13: Structs
**Topic**: Value types
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Struct - value type (copied, not referenced)
struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}

Point p1 = new Point(3, 4);
Point p2 = p1;   // Creates a copy
p2.X = 10;       // Only affects p2
Console.WriteLine(p1.X);  // Still 3
```

#### Problem Statement
Create a `Color` struct with:
- Properties: Red, Green, Blue (0-255)
- Method: `ToHex()` returns hex color code
- Static predefined colors (Red, Green, Blue, White, Black)

#### Solution
```csharp
struct Color
{
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }

    public Color(byte red, byte green, byte blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public string ToHex()
    {
        return $"#{Red:X2}{Green:X2}{Blue:X2}";
    }

    public override string ToString()
    {
        return $"RGB({Red}, {Green}, {Blue}) = {ToHex()}";
    }

    // Static predefined colors
    public static Color RedColor => new Color(255, 0, 0);
    public static Color GreenColor => new Color(0, 255, 0);
    public static Color BlueColor => new Color(0, 0, 255);
    public static Color White => new Color(255, 255, 255);
    public static Color Black => new Color(0, 0, 0);
}

// Main code
Console.WriteLine(Color.RedColor);
Console.WriteLine(Color.GreenColor);
Console.WriteLine(Color.BlueColor);
Console.WriteLine(Color.White);
Console.WriteLine(Color.Black);

Color custom = new Color(128, 64, 192);
Console.WriteLine(custom);
```

---

### Question 14: Records (C# 9+)
**Topic**: Immutable data types
**Difficulty**: Intermediate

#### Concept Activity
```csharp
// Record - immutable reference type with value equality
record Person(string Name, int Age);

// Creating instances
Person p1 = new Person("Ahmad", 25);
Person p2 = new Person("Ahmad", 25);

Console.WriteLine(p1 == p2);  // True (value equality)

// With expression - creates copy with changes
Person p3 = p1 with { Age = 26 };
Console.WriteLine(p3);  // Person { Name = Ahmad, Age = 26 }
```

#### Problem Statement
Create a `Student` record with:
- Properties: Name, StudentId, Major, GPA
- Display student information

#### Solution
```csharp
record Student(string Name, string StudentId, string Major, double GPA)
{
    public string Status => GPA >= 3.0 ? "Good Standing" : "Academic Probation";
}

// Main code
Student s1 = new Student("Ahmad Khan", "STU001", "Computer Science", 3.5);
Student s2 = new Student("Sara Ali", "STU002", "Engineering", 2.8);

Console.WriteLine(s1);
Console.WriteLine($"Status: {s1.Status}\n");

Console.WriteLine(s2);
Console.WriteLine($"Status: {s2.Status}\n");

// With expression
Student s3 = s1 with { GPA = 3.8 };
Console.WriteLine($"Updated: {s3}");

// Value equality
Student s4 = new Student("Ahmad Khan", "STU001", "Computer Science", 3.5);
Console.WriteLine($"s1 == s4: {s1 == s4}");  // True
```

---

### Question 15: Composition
**Topic**: Has-a relationship
**Difficulty**: Intermediate

#### Problem Statement
Create a system where:
- `Address` class with: Street, City, Country
- `Person` class that HAS an `Address`
- `Company` class that HAS a list of `Person` objects

#### Solution
```csharp
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string country)
    {
        Street = street;
        City = city;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {Country}";
    }
}

class Person
{
    public string Name { get; set; }
    public Address HomeAddress { get; set; }  // Composition

    public Person(string name, Address address)
    {
        Name = name;
        HomeAddress = address;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Address: {HomeAddress}");
    }
}

class Company
{
    public string CompanyName { get; set; }
    public List<Person> Employees { get; set; }  // Composition

    public Company(string name)
    {
        CompanyName = name;
        Employees = new List<Person>();
    }

    public void AddEmployee(Person employee)
    {
        Employees.Add(employee);
    }

    public void DisplayEmployees()
    {
        Console.WriteLine($"\n=== {CompanyName} Employees ===");
        foreach (Person emp in Employees)
        {
            emp.DisplayInfo();
            Console.WriteLine();
        }
    }
}

// Main code
Address addr1 = new Address("123 Main St", "Karachi", "Pakistan");
Address addr2 = new Address("456 Oak Ave", "Lahore", "Pakistan");

Person p1 = new Person("Ahmad", addr1);
Person p2 = new Person("Sara", addr2);

Company company = new Company("Tech Corp");
company.AddEmployee(p1);
company.AddEmployee(p2);

company.DisplayEmployees();
```

---

## Challenge Questions

### Challenge 1: Complete Library System
**Difficulty**: Advanced

#### Problem Statement
Create a library management system with:
- Abstract class `LibraryItem` with: Title, ItemId, IsAvailable, abstract `GetInfo()`
- Derived classes: `Book` (Author, Pages), `DVD` (Director, Duration), `Magazine` (Issue)
- `Library` class that manages items (add, remove, search, borrow, return)

#### Solution
```csharp
abstract class LibraryItem
{
    public string ItemId { get; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; } = true;

    private static int itemCount = 0;

    public LibraryItem(string title)
    {
        itemCount++;
        ItemId = $"LIB{itemCount:D4}";
        Title = title;
    }

    public abstract string GetInfo();

    public void Borrow()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"'{Title}' has been borrowed.");
        }
        else
        {
            Console.WriteLine($"'{Title}' is not available.");
        }
    }

    public void Return()
    {
        IsAvailable = true;
        Console.WriteLine($"'{Title}' has been returned.");
    }
}

class Book : LibraryItem
{
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book(string title, string author, int pages) : base(title)
    {
        Author = author;
        Pages = pages;
    }

    public override string GetInfo()
    {
        return $"[{ItemId}] Book: '{Title}' by {Author}, {Pages} pages - {(IsAvailable ? "Available" : "Borrowed")}";
    }
}

class DVD : LibraryItem
{
    public string Director { get; set; }
    public int DurationMinutes { get; set; }

    public DVD(string title, string director, int duration) : base(title)
    {
        Director = director;
        DurationMinutes = duration;
    }

    public override string GetInfo()
    {
        return $"[{ItemId}] DVD: '{Title}' directed by {Director}, {DurationMinutes} min - {(IsAvailable ? "Available" : "Borrowed")}";
    }
}

class Library
{
    public string Name { get; set; }
    private List<LibraryItem> items = new List<LibraryItem>();

    public Library(string name)
    {
        Name = name;
    }

    public void AddItem(LibraryItem item)
    {
        items.Add(item);
        Console.WriteLine($"Added: {item.Title}");
    }

    public LibraryItem SearchByTitle(string title)
    {
        return items.Find(i => i.Title.ToLower().Contains(title.ToLower()));
    }

    public void DisplayAllItems()
    {
        Console.WriteLine($"\n=== {Name} Catalog ===");
        foreach (var item in items)
        {
            Console.WriteLine(item.GetInfo());
        }
    }
}

// Main code
Library library = new Library("City Public Library");

library.AddItem(new Book("The Great Gatsby", "F. Scott Fitzgerald", 180));
library.AddItem(new Book("1984", "George Orwell", 328));
library.AddItem(new DVD("Inception", "Christopher Nolan", 148));

library.DisplayAllItems();

Console.WriteLine("\n--- Borrowing ---");
var book = library.SearchByTitle("gatsby");
book?.Borrow();

library.DisplayAllItems();
```

---

### Challenge 2: Bank Account System with Inheritance
**Difficulty**: Advanced

#### Problem Statement
Create a banking system with:
- Base class `Account` with: AccountNumber, Balance, Deposit(), Withdraw()
- `SavingsAccount`: adds interest rate, `AddInterest()` method
- `CheckingAccount`: adds overdraft limit
- `AccountManager` to manage multiple accounts

#### Solution
```csharp
abstract class Account
{
    public string AccountNumber { get; }
    public string OwnerName { get; set; }
    public decimal Balance { get; protected set; }

    private static int accountCount = 0;

    public Account(string ownerName, decimal initialBalance)
    {
        accountCount++;
        AccountNumber = $"ACC{accountCount:D6}";
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${Balance:F2}");
        }
    }

    public abstract bool Withdraw(decimal amount);

    public abstract string GetAccountType();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{GetAccountType()} - {AccountNumber}");
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Balance: ${Balance:F2}");
    }
}

class SavingsAccount : Account
{
    public decimal InterestRate { get; set; }

    public SavingsAccount(string ownerName, decimal initialBalance, decimal interestRate)
        : base(ownerName, initialBalance)
    {
        InterestRate = interestRate;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${Balance:F2}");
            return true;
        }
        Console.WriteLine("Insufficient funds!");
        return false;
    }

    public void AddInterest()
    {
        decimal interest = Balance * (InterestRate / 100);
        Balance += interest;
        Console.WriteLine($"Interest added: ${interest:F2}. New balance: ${Balance:F2}");
    }

    public override string GetAccountType() => "Savings Account";

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Interest Rate: {InterestRate}%");
    }
}

class CheckingAccount : Account
{
    public decimal OverdraftLimit { get; set; }

    public CheckingAccount(string ownerName, decimal initialBalance, decimal overdraftLimit)
        : base(ownerName, initialBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance + OverdraftLimit)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${Balance:F2}");
            return true;
        }
        Console.WriteLine("Exceeds overdraft limit!");
        return false;
    }

    public override string GetAccountType() => "Checking Account";

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Overdraft Limit: ${OverdraftLimit:F2}");
    }
}

// Main code
Console.WriteLine("=== Banking System ===\n");

SavingsAccount savings = new SavingsAccount("Ahmad", 1000, 5);
CheckingAccount checking = new CheckingAccount("Sara", 500, 200);

savings.DisplayInfo();
Console.WriteLine();

savings.Deposit(500);
savings.AddInterest();
Console.WriteLine();

checking.DisplayInfo();
Console.WriteLine();

checking.Withdraw(600);  // Uses overdraft
checking.Withdraw(200);  // Should fail
```

---

## Week 4 Summary Checklist

- [ ] Can create classes with fields and methods
- [ ] Can create and use constructors
- [ ] Can use properties with validation
- [ ] Understand access modifiers (public, private, protected)
- [ ] Can use static members and methods
- [ ] Can implement inheritance with base/derived classes
- [ ] Can use virtual/override for polymorphism
- [ ] Can create and use abstract classes
- [ ] Can define and implement interfaces
- [ ] Understand sealed classes
- [ ] Can use enums
- [ ] Know difference between class and struct
- [ ] Can use records for immutable data (C# 9+)
- [ ] Understand composition (has-a relationship)

---

## Next Week Preview
**Week 5: Advanced C#** - Generic collections, LINQ, exception handling, file I/O, async/await

---

*Questions: 15 | Challenges: 2 | Total: 17*
