using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO.Pipelines;



class Fraction
{
    private int _top, _bot;

    public Fraction(int top, int bot)
    {
        
        _top = Set_top(top);
        _bot = Set_bot(bot);


    }


    public double Get_fraction_number(Fraction frac)
    {
        
        
        double t = frac._top;
        double b = frac._bot;
        return  t / b;

    }
    public string Get_fraction_string(Fraction frac)
    {

        var l = (frac._top).ToString();
        var k = (frac._bot).ToString();

        return l + "/" + k;

    }
    public int Get_top(Fraction frac)
    {
        return frac._top;

    }
    public int Get_bottom(Fraction frac)
    {
        return frac._bot;
    }


    public static int Set_top(int number)
    {
/*
        int p = 1;
        var loop = 0;

        while (loop == 0) {

            Console.WriteLine("Insert valid top number:");

            if (int.TryParse(Console.ReadLine(), out p))
            {
                loop = 1;
                
            }
        
        }
        
        return p;
    
  */



    return number;



    }

    public static int Set_bot(int number)
    {

/*
        int p = 1;
        var loop = 0;

        while (loop == 0) {

            Console.WriteLine("Insert valid bot number:");
            if (int.TryParse(Console.ReadLine(), out p))
            {
                loop = 1;

            }
        
        }
       

        return p;
*/

    return number;

    }

}