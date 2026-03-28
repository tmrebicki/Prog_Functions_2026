class TBlock : Block
{
    public TBlock(int x, int y) : base(x, y)
    {
        int i = _rand.Next(0, _blockTypeList.Length);
        _shape = "T";

        DefineShape();
        Update_blocks();
    }

    

    public override void Rotate(Func<Block, int, int, bool> canMove)
    {
        var oldMap = _blockMap.Select(row => row.ToArray()).ToArray();

        int size = _blockMap.Length;
        string[][] rotated = new string[size][];
        for (int i = 0; i < size; i++)
            rotated[i] = new string[size];

        for (int y = 0; y < size; y++)
            for (int x = 0; x < size; x++)
                rotated[x][size - 1 - y] = _blockMap[y][x];

        _blockMap = rotated;

        _shapeBlocks.Clear();
        Update_blocks();

        if (canMove(this, 0, 0)) return;
        if (canMove(this, -1, 0)) { _x--; _shapeBlocks.Clear(); Update_blocks(); return; }
        if (canMove(this, 1, 0))  { _x++; _shapeBlocks.Clear(); Update_blocks(); return; }

        _blockMap = oldMap;
        _shapeBlocks.Clear();
        Update_blocks();
    }
    
    public override void DefineShape()
    {

        _blockMap = [["[]","[]","[]","  "],
                     ["  ","[]","  ","  "],
                     ["  ","  ","  ","  "],
                     ["  ","  ","  ","  "]];
    }




}