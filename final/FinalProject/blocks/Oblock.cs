class OBlock : Block
{
    public OBlock(int x, int y) : base(x, y)
    {
        int i = _rand.Next(0, _blockTypeList.Length);
        _shape = "O";

        DefineShape();
        Update_blocks();
    }




    public override void Rotate(Func<Block, int, int, bool> canMove)
    {
        Update_blocks();
    }

    
    public override void DefineShape()
    {

                _blockMap = [["[]","[]"],
                             ["[]","[]"]];
    }




    
}