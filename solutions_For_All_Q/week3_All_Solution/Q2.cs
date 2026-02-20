int[] ar = new int[5];
for(int i = 0; i<ar.Length ; i++)
{
    Console.Write($"Enter value {i} :");
    ar[i] = Convert.ToInt32(Console.ReadLine());

}
int sum =0;

for (int j = 0 ; j < ar.Length ; j++)
{
    sum +=ar[j];
}

double ave = (double)sum/ar.Length;
Console.Write($" Sum of all values is : {sum} , Average is : {ave}");

// Create an array of 5 numbers entered by the user. Calculate and display the sum and average.