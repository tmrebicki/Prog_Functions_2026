using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
class Program
{

  
 

    static void Main(string[] args)
    {
        int x = 0;
        int end =0;
        int total = 0;
        int avg =0;
        int larg =0;
        int small =10^200;
        List<int> numbers = new List<int>();

        while (end == 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            Console.WriteLine("Enter a number:");
            string resp = Console.ReadLine();
    
            x = int.Parse(resp); 

            if (larg < x)
            {
                larg = x;
            }
           if (x > 0 && x < small)
            {
                small = x;
            }

             if (x == 0)
            {
            
                for (int i = 0; i < numbers.Count; i++)
                {
                    total += numbers[i];
                }

                avg = total / numbers.Count;
                numbers.Sort();

                Console.WriteLine("Sum: " + total);
                Console.WriteLine("average: " + avg);
                Console.WriteLine("Largest number: " + larg);
                Console.WriteLine("The smallest positive number: " + small);
                Console.WriteLine("sorted list");
                for (int i = 0; i < numbers.Count; i++)
                {
                Console.WriteLine(numbers[i]);
                }
                end = 1;



            }   
            else
            {
                numbers.Add(x);
            }
        }

    }   


}