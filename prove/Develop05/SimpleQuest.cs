using System;
using System.Drawing;


public class SimpleQuest : BaseQuest
{

    private bool _Complete;


    public SimpleQuest(string name, string description, int points, bool Complete = false)
        : base(name, description, points)
    {
        _Complete = Complete;
    }



    public override int RecordEvent()
    {
        if (_Complete)
        {
        return 0;
        }
        else
        {
        _Complete = true;
        return _points;
        }



    }
    public override bool Complete() => _Complete;

    public override string GetStatus() => _Complete? "[X]" : "[ ]";
    
    public override string GetData() => $"SimpleQuest|{GetStatus()}|{_name}|{_description}|{_points}";


}