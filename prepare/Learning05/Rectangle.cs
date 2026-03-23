using System;

public class Rectangle  : Shape
{

    private double _w, _h;


    public Rectangle(ConsoleColor c, double w, double h) : base(c)
    {
        

        _w = w;
        _h = h;


    }

    public override double Get_area()
    {
        
        return _w * _h;

    }


}