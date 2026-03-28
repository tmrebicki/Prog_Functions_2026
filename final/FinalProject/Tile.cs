using System;

class Tile
{

    private bool _isBlock;
    private int _x,_y;

    private string _display;
    private ConsoleColor _color;

    public Tile(int x, int y, bool block, ConsoleColor color)
    {
        _color = color;
        _isBlock = block;
        _x = x;
        _y = y;
    }


    public void Set_Block(bool set_to, ConsoleColor color)
    {
        
        _isBlock = set_to;
        _color = color;
    }
    public int[] Get_cord()
    {
        
        return [_x,_y];

    }

    public void Set_cord(int[] cord)
    {
        _x = cord[0];
        _y = cord[1];
    }

    public bool Get_tile_Bool()
    {
        
        return _isBlock;

    }



    public void Draw_Block()
    {
        if (_isBlock)
        {
            _display = "[ ]";  
        }else{
            
            _display = " ' ";
        }


        Console.ForegroundColor = _color;
        Console.Write(_display);
        Console.ResetColor();


    }





}