using System;

class Assigment
{
    private string _studentName, _topic;
    
    public Assigment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;



    }
    public string GetStudentName()
    {
        
        return $"{_studentName} : {_topic}";


    }
    public string GetSummary()
    {
        
        return $"{_studentName} : {_topic}";


    }
}