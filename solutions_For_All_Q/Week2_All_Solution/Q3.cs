Console.Write("Please enter your marks here! :");
double number = Convert.ToDouble(Console.ReadLine());
if(number >=90 && number <= 100)
{
    Console.WriteLine("Grade is A !");

}else if(number >=80 && number <= 89)
{
    Console.WriteLine("Grade is B");

}else if(number >=70 && number <= 79)
{
    Console.WriteLine("Grade is C!");
}else if(number >=60 && number <= 69)
{
    Console.WriteLine("Grade is D!");
}
else
{
    Console.WriteLine("You are fail! ");

}

// Write a program that converts a score to a letter grade:

// 90-100: A
// 80-89: B
// 70-79: C
// 60-69: D
// Below 60: F