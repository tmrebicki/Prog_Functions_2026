using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
       

        Random randomGenerator = new Random();
        int magik = randomGenerator.Next(1, 100);
        int x = 0;
        int attempts = 0;
        int win = 0;

        
        while (win == 0) {
            
            Console.WriteLine("What is the magical number?");
            x = int.Parse(Console.ReadLine()); 
            
            if (x == magik)
            {
                
                win = 1;
                Console.WriteLine("Congrats!" + " Guesses: " + attempts + ". Do you want to play again? (yes/no)");
                string i = Console.ReadLine();

                     if (i == "yes")
                      {
                        win = 0;
                        i = "no";
                        attempts =0;
                        magik = randomGenerator.Next(1, 12);

                     }       


            }else if (x < magik)
            {
                Console.WriteLine("HIgher");
                attempts++;
            }
            else
            {
                Console.WriteLine("Lower");
                attempts++;

            }


        }

       


       
    }
}