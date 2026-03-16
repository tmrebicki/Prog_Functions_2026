using System;

class MathAssigment:Assigment
{
    private string _textbookSection, _problems;


    public MathAssigment(string student , string topic, string textbookSection, string problems) : base(student, topic)
    {
        
        _textbookSection = textbookSection;
        _problems = problems;

    }


    public string Get_Homework()
    {
        return $" Section {_textbookSection}, Problems {_problems}";

    }




}