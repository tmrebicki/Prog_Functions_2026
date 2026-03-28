using System;
using Microsoft.VisualBasic;
using System.Windows.Input;
class GameBoard
{

    private List<Block> _sequence;
    private int _width;
    private int _legnth;

    public bool _points = false;
    public int Speed_Incerase = 0;
    private List<Block> _blocks;

    private Tile[,] _map;
    
    public GameBoard(int w, int l)
    {

        _width = w;
        _legnth = l;
        _map = new Tile[_width,_legnth];
        _blocks = new List<Block>();
        _sequence = new List<Block>();

        for (int y = 0; y !=_legnth ; y++){   
            for (int x = 0; x != _width; x++){        
           
            _map[x,y] = new Tile(x,y, false, ConsoleColor.DarkGray);
            
            }
    
        }

        


    }




    protected bool Is_tile_in(int x, int y)
    {
        if (x >= 0 && x < _width && y >= 0 && y < _legnth){
                
            return true;

        }
        else
        {
            return false;
        }




    }


    private Block Pick_Block(int x , int y)
    {
                
        Random randomGenerator = new Random();
        int r = randomGenerator.Next(0, 7);
        Block block;
        
        switch (r)
        {
            case 0: block = new OBlock(_width/2 - 2, y); break;
            case 1: block = new TBlock(_width/2 - 2, y); break;
            case 2: block = new ZBlock(_width/2 - 2, y); break;
            case 3: block = new IBlock(_width/2 - 2, y); break;
            case 4: block = new SBlock(_width/2 - 2, y); break;
            case 5: block = new LBlock(_width/2 - 2, y); break;
            case 6: block = new JBlock(_width/2 - 2, y); break;
            default: block = new OBlock(_width/2 - 2, y); break;
        }

        return block;


    }

    public bool Give_points() => _points;
    public Block create_block(int x, int y)
    {

        while (_sequence.Count < 3)
        {
            _sequence.Add(Pick_Block(x,y));
        }

            var create = _sequence.First();
            _blocks.Add(_sequence.First());
            CheckLines();
            _sequence.Remove(_sequence.First());

            return create;

    }

    public List<Block> Get_sequence() => _sequence;


    public void Apply_block(Block block)
    {
        var list = block.Get_Block_list(block);
        var e_list = block.Get_erase_list();


        foreach (Tile item in e_list)
        {
            var cord = item.Get_cord();

            if (Is_tile_in(cord[0],cord[1])){
                
                _map[cord[0],cord[1]].Set_Block(false,ConsoleColor.DarkGray);
            
            }

        }






        foreach (Tile item in list)
        {
            var cord = item.Get_cord();

            if (Is_tile_in(cord[0],cord[1])){
                
                _map[cord[0],cord[1]].Set_Block(true,block.Get_color());
            
            }

        }





    }

    public bool Landed(Block b)
    {
        
        if (!CanMove(b, 0, 1))
        {

            return true;
        }
        else
        {
            
            return false;

        }
    }

    public void Move_Block(int x, int y , Block item)
    {   
       
        var collision = !CanMove(item,x,y);

            if (!collision){
            
            item.Move(x,y);

            }

    }

    public bool CanMove(Block block, int dx, int dy)
    {
        foreach (Tile t in block.Get_Block_list(block))
        {
            var cord = t.Get_cord();
            int newX = cord[0] + dx;
            int newY = cord[1] + dy;

            if (!Is_tile_in(newX, newY))
                return false;

            foreach (Block other in _blocks)
            {
                if (other == block) continue;

                foreach (Tile ot in other.Get_Block_list(other))
                {
                    var ocord = ot.Get_cord();

                    if (ocord[0] == newX && ocord[1] == newY)
                    return false;
                }
            }
        }

        return true;
    }




    public void Update_Board()
    {
        
        for (int y = 0; y !=_legnth ; y++){   
            for (int x = 0; x != _width; x++){        
           
            _map[x,y] = new Tile(x,y, false, ConsoleColor.DarkGray);
            
            }
    
        }


        foreach (Block a in _blocks)
        {

            Apply_block(a);

        }


    }

    public void CheckLines()
    {
        List<int> clearedRows = new List<int>();

        for (int y = _legnth - 1; y >= 0; y--)
        {
            bool fullRow = true;

            for (int x = 0; x < _width; x++)
            {
                if (!_map[x, y].Get_tile_Bool())
                {
                    fullRow = false;
                    break;
                }
            }

            if (fullRow)
            {   
                clearedRows.Add(y);
                Speed_Incerase += 1;
            }
        }

    if (clearedRows.Count > 0)
    {
        ClearLines(clearedRows);
        Collapse(clearedRows);
    }


    }

    private void ClearLines(List<int> row)
    {
        foreach (Block b in _blocks)
        {
            var original = b.Get_Block_list(b);
            var snapshot = original.ToList();

            List<Tile> toRemove = new List<Tile>();

            foreach (Tile t in snapshot)
            {
                if (row.Contains(t.Get_cord()[1]))
                {
                    toRemove.Add(t);
                }
            }

            foreach (Tile t in toRemove)
            {
                original.Remove(t);
            }

            b.Get_erase_list().AddRange(toRemove);
        }


        _points = true; 
        Update_Board();


    }

    private void Collapse(List<int> clearedRows)
    {

        clearedRows.Sort();
    
        foreach (Block b in _blocks)
        {
            var list = b.Get_Block_list(b);
    
            foreach (Tile t in list)
            {
                var cord = t.Get_cord();
                int drop = 0;
    

                foreach (int row in clearedRows)
                {
                    if (cord[1] < row)
                    {
                        drop++;
                    }
                }
    
                if (drop > 0)
                {
                    cord[1] += drop;
                    t.Set_cord(cord);
                }
            }
        }
    }




    public void Draw_Board()
    {
 
        Console.CursorVisible = false;
        Update_Board();
        for (int y = 0; y !=_legnth ; y++){
            Console.WriteLine();
            
            for (int x = 0; x != _width; x++){
            
            _map[x,y].Draw_Block();

        }}

        
        

    }













}