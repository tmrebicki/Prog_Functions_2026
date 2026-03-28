using System;
using System.Collections.Generic;

abstract class Block
{
    public string _shape;
    protected ConsoleColor _color;
    protected int _x, _y;

    protected string[] _blockTypeList = ["O","I","Z","T","J","L","S"];
    protected string[][] _blockMap;

    protected List<Tile> _shapeBlocks;
    protected List<Tile> _eraseList;

    protected static Random _rand = new Random();

    public Block(int x, int y)
    {
        _x = x;
        _y = y;

        _shapeBlocks = new List<Tile>();
        _eraseList = new List<Tile>();

        ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
        _color = colors[_rand.Next(colors.Length)];
    }



    public List<Tile> Get_Block_list(Block a)
    {
        return a._shapeBlocks;
    }

    public string[][] Get_Block_map(Block a)
    {
        return a._blockMap;
    }

    public List<Tile> Get_erase_list()
    {
        return _eraseList;
    }

    public ConsoleColor Get_color()
    {
        return _color;
    }

    public bool ContainsTileAt(int x, int y)
    {
        foreach (Tile t in _shapeBlocks)
        {
            var cord = t.Get_cord();
            if (cord[0] == x && cord[1] == y)
                return true;
        }
        return false;
    }

    public virtual void Move(int x, int y)
    {
        _x += x;
        _y += y;

        foreach (Tile t in _shapeBlocks)
        {
            _eraseList.Add(t);
        }

        _shapeBlocks.Clear();
        Update_blocks();
    }

    public abstract void Rotate(Func<Block, int, int, bool> canMove);

    public int Get_X() => _x;
    public int Get_Y() => _y;
    public abstract void DefineShape();

    public void Update_blocks()
    {
        for (int yy = 0; yy != _blockMap.Length; yy++)
        {
            for (int xx = 0; xx != _blockMap[yy].Length; xx++)
            {
                if (_blockMap[yy][xx] == "[]")
                {
                    _shapeBlocks.Add(new Tile(_x + xx, _y + yy, true, _color));
                }
            }
        }
    }

}