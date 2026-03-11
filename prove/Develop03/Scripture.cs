using System;
using System.Threading.Channels;

class Scripture
{


    public List<Reference> _verses;

    public string _text; 

    public Scripture(int line, int max_of_verses)
    {
        Random randomGenerator = new Random();

        int i = randomGenerator.Next(-5, max_of_verses);

        _verses = set_list(line, 0, max_of_verses);


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

            } else if (ver1._data[1] == list_verses[0]._data[1])
            {

                list_verses.Add(ver1);

            }
                        
            
            ver_amount -=1;

        }

        return list_verses;
    }





}