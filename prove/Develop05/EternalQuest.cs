using System;


public class EternalQuest : BaseQuest
{
    public  EternalQuest(string name, string description, int points) : 
    base(name,description,points)
    {
        

    }

    public override int RecordEvent() => _points;
    public override bool Complete() => false;
    public override string GetStatus() => "[Eternal]";
    public override string GetData()=> $"EternalQuest|{GetStatus()}|{_name}|{_description}|{_points}";









}