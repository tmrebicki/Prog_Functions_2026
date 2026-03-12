using System;
using System.ComponentModel;
using System.Threading.Channels;

class Reference
{
   
    private string _book, _chapter, _verses, _text;
    private int _size = -1;
    private List<Word> _list_words;
    private List<string> _data; 


    public Reference(int number)
    {
        
        string[] data;
        data = Get_Scripture(number);
        _book = data[0];
        _chapter = data[1];
        _verses = data[2];
        List<string> words= new List<string>(data[3].Split(' '));
        List<Word> l = new List<Word>();
        foreach (string word in words) {
           


            Word v = new Word(word);
            l.Add(v);
            _size +=1;
           
        }

        _list_words = l;
 
        _text = data[3];
        _data = data.ToList();


    }

    public static string Get_chapter(Reference i)
    {
        
        return i._chapter;

    }

    public static void Write_verse_hidden(Reference Ref)
    {
        string complete = " ";
        
        foreach (Word i in Ref._list_words)
        {
            string q;

            q = Word.Get_word_display(i);

            complete += " " + q;

        }

        Console.WriteLine($"{Ref._book} {Ref._chapter}:{Ref._verses}   {complete}");



    }






    private static string[] Get_Scripture(int number)
    {   
        var _total_lines = 6586;

        if (number < 0)
        {
            number = number*-1;
        }
        if (number > _total_lines)
        {
            
            number = _total_lines;

        }

        
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

    public static void unhide_word(string word, Reference p)
    {
        
        foreach (Word k in p._list_words)
        {
            
            Word.flag(word, k);

        }


    }
    public static void Hide_word(Reference i)
    {
        int attempts = 0;
        string done = "no";

        while (done == "no"){

            attempts +=1;

            if (attempts < i._size)
            {
            Random randomGenerator = new Random();
            int num = randomGenerator.Next(0, i._size);
        
            done = Word.Hide(i._list_words[num]);
            

            }
            else
            {
                
                done = "yes";

            }
        }
    } 





}