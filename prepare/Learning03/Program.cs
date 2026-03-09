using System;


class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to Program");

        var loop = 20;


        while (loop > 0){
            
            var x = 5^10*9;

            Random randomGenerator = new Random();
            int top = randomGenerator.Next(0, x);

            Random random = new Random();
            int bot = randomGenerator.Next(0, x);

            var frac = new Fraction(top,bot);

            Console.WriteLine($"top: {frac.Get_top(frac)}, bot: {frac.Get_bottom(frac)}, string: {frac.Get_fraction_string(frac)}, result: {frac.Get_fraction_number(frac)} ");

            loop -=1;
        }





    }
}


