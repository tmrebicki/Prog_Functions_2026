using System;

public abstract class Shape
{

    private ConsoleColor _color;
    public abstract double Get_area();


    public Shape(ConsoleColor c)
    {
        _color = c;
        

    }


    public ConsoleColor Get_color()
    {
        
        return _color;

    }
    
    protected void Set_color(ConsoleColor c)
    {
        _color = c;


    }






}