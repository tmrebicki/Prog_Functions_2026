using System;
using System.Threading.Channels;

class Scripture
{


    private List<Reference> _verses;
    

    public Scripture(int line, int max_of_verses)
    {




        Random randomGenerator = new Random();
        int i = randomGenerator.Next(-5, max_of_verses);

        _verses = set_list(line, 0, max_of_verses);


    }


    public static void Print_all(Scripture s)
    {
        foreach (Reference r in s._verses)
        {
            Reference.Write_verse_hidden(r);

        }



    }


    public static void Hide_Refs(Scripture i)
    {
        foreach (Reference refs in i._verses)
        {
            Reference.Hide_word(refs);


        }

    }

    public static void unhide(string word, Scripture scrip)
    {
        
        foreach (Reference r in scrip._verses)
        {
            
            Reference.unhide_word(word, r);

        }



    }
    private List<Reference> set_list(int num, int ver_amount, int i)
    {
        List<Reference> list_verses = new List<Reference>();

        if (i > 0)
        {
            ver_amount += i;

        }

        var p = ver_amount;
        while (ver_amount > -1){

            Reference ver1 = new Reference(num + ver_amount*-1);


            if (p == ver_amount )
            {

                list_verses.Add(ver1);

            } else if ( Reference.Get_chapter(ver1) == Reference.Get_chapter(list_verses[0]))
            {

                list_verses.Add(ver1);

            }
                        
            
            ver_amount -=1;

        }

        return list_verses;
    }

    




}