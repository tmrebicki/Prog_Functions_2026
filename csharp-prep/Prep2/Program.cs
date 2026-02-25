using System;

class Program
{
    static void Main(string[] args)
    {
        int x;
        string grade;
        int GG;
        string strch;
        Console.WriteLine("What was your grade? (in percentage)");

        string resp = Console.ReadLine();
    
        x = int.Parse(resp); 

    


        if (x >= 90)
        {
            
            grade = "A";

        }else if (x >= 80)
        {
            
            grade = "B";

        }else if (x >= 70)
        {
            
            grade = "C";

        }else if (x>= 60)
        {

            grade = "D";

        }
        else
        {
            
            grade = "F";

        }

        Console.WriteLine("Your grade is:" + grade);


    }
}