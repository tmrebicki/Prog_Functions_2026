using System;

public class Circle  : Shape
{

    private double _r;


    public Circle(ConsoleColor c, double r) : base(c)
    {
        

        _r = r;

    }

    public override double Get_area(){
        
        return (_r * _r) * 3.14;

    }


}