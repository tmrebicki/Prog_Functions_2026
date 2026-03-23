using System;

public class Square : Shape
{

    private double _side;


    public Square(ConsoleColor c, double side) : base(c)
    {
        

        _side = side;


    }

    public override double Get_area()
    {
        
        return _side * _side;

    }


}