using System;


public class CheckList : BaseQuest
{

    private bool _Complete;
    private int _compl, _prog;
    public  CheckList(string name, string description, int points, int prog, int completion) : 
    base(name,description,points)
    {
        _Complete = false;
        _compl = completion;
        _prog = prog;

    }




    public override int RecordEvent()
    {

        if (_prog >= _compl)
        {
         if (_Complete)
            {
                return 0;
            }
            else
            {
                return _points;
            }
        }
        else
        {
        _prog += 1;
        return 0;
        }



    }
    public override bool Complete() => _Complete;

    public override string GetStatus() => _Complete? "[X]" : $"{_prog}/{_compl}";
    
    public override string GetData() => $"Checklist|{GetStatus()}|{_name}|{_description}|{_points}";


}