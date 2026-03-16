using System;

class WrittingAssigment: Assigment
{
    private string _title;

    public WrittingAssigment(string student, string topic, string title) : base(student, topic)
    {
        
        _title = title;

    }

    public string Get_Writting_Info()
    {
        var name = GetStudentName();

        return _title + ": " + name;


    }

}