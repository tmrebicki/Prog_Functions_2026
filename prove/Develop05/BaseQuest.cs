using System;


public abstract class BaseQuest
{

    protected string _name,_description;
    protected int _points;


    protected BaseQuest(string name, string description, int points)
    {
        
        _description = description;
        _name= name;
        _points = points;


    }

    public abstract int RecordEvent();
    public abstract bool Complete();
    public abstract string GetStatus();

    public abstract string GetData();









}