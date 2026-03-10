using System;
using System.Threading.Channels;

class Reference
{
   
    public string _book, _chapter, _Reference;
    public List<string> _words;

    public string _text;


    public Reference(int number)
    {
        
        string[] data;
        data = Get_Scripture(number);
        _book = data[0];
        _chapter = data[1];
        _Reference = data[2];
        List<string > words= new List<string>( data[3].Split(' '));
        _words = words;
        _text = data[3];


    }
    public static string[] Get_Scripture(int number)
    {


        
        using (var reader = new StreamReader("C:/Users/tmreb/OneDrive - BYU-Idaho/Prog with Func/Prog_Functions_2026/prove/Develop03/bom.csv"))
        {

            while (number > 1)
            {
                
                reader.ReadLine();
                number -=1;
            }

            var line = reader.ReadLine();
            string[] value;
            value = line.Split(',');

            return value;
            


            
            
        }



    }







}