using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

public class GoalTracker
{
    private List<BaseQuest> _goals = new List<BaseQuest>();
    private int _score;

    private DateTime _lastCompletionDate;
    private int _streak = 1;

    public int Score => _score;

    public void AddGoal(BaseQuest goal)
    {
        _goals.Add(goal);
    }

    public List<BaseQuest> Get_Goals() => _goals;

    public void Increase_score(int x)=> _score += x;

    public int Get_score() => _score;

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        
        return;

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"Streak: {_streak} days");
        
        
        UpdateStreak();
        Save("file");
    }

    public int Getstreak() => _streak; 
    public void DisplayGoals()
    {
        Console.Clear();
        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            string status = g.GetStatus();
            var data = g.GetData();
            var brok_data = data.Split("|");
            Console.WriteLine($"{brok_data[1]}: {brok_data[2]}, {brok_data[3]}. Pts: {brok_data[4]}");


        }

        Console.WriteLine("Press any to exit");
        Console.ReadLine();




    }

    public void UpdateStreak()
    {
        DateTime today = DateTime.Today;

        if (_lastCompletionDate == today)
        {

            return;
        }

        if (_lastCompletionDate == today.AddDays(-1))
        {

            _streak++;
        }
        else
        {

            _streak = 1;
        }

        _lastCompletionDate = today;
    }


    public void Save(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine($"{_score}|{_streak}|{_lastCompletionDate}");

            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetData());
            }
        }
    }

    public void Load(string file)
    {
        if (!File.Exists(file)) return;


        string[] lines = File.ReadAllLines(file);       
        var headers = lines.First().Split("|");

        _score = int.Parse(headers[0]);
        _streak = int.Parse(headers[1]);
        _lastCompletionDate = DateTime.Parse(headers[2]);
        _goals.Clear();

        if (lines.Length == 0) return;



        foreach (var i in lines.Skip(1))
        {

            var goal = Break_data(i);
            
            if (goal[0] == "SimpleQuest")
            {
            
            SimpleQuest quest = new SimpleQuest(goal[2],goal[3],int.Parse(goal[4]));
            _goals.Add(quest);
            }
            else
            {
            
            EternalQuest quest = new EternalQuest(goal[2],goal[3],int.Parse(goal[4]));

            _goals.Add(quest);
            }



        }
    }


    public string[] Break_data(string line)
    {

        return line.Split('|');


    }
}