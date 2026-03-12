using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
class Word
    {
       
        private string _word;
        private Boolean _hidden;


        public Word(string word)
    {
        
        _word = word;
        _hidden = false;


    }

    public static void flag(string wo, Word w)
    {
        string checker = "";
  
        foreach (char a in w._word)
        {
            if (!Char.IsPunctuation(a))
            {
                
                checker += Char.ToLower(a);

            }


        }


        if (checker == wo)
        {
            
            w._hidden = false;

        }

    }
    public static string Hide(Word k)
    {
        if (k._hidden != true){
            k._hidden = true;
            return "yes";
        }
        else
        {

            return "no";

        }

    }
        public static string Get_word_display(Word word)
    {
        if (word._hidden == true)
        {   
            var ret = "";
            string silly = ";";
            var total = word._word.ToCharArray();

            foreach (char l in total)
            {
                if ( !char.IsPunctuation(l)){
                    
                    ret += "_";

                }
                else
                {   
                    if ( silly != l.ToString())
                    {
                        
                        ret += l;
                    }
                    else
                    {
                        
                        ret += ",";

                    }


                    
                }
                

            }

            return ret;
        }
        else
        {
            
            return word._word;

        }



    }







    }