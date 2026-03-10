using System;

class Program
{



    static void set_list(int num, int ver_amount, int i , List<Reference> list_References)
    {

        if (i > 0)
        {
            ver_amount += i;

        }

        var p = ver_amount;
        while (ver_amount > -1){

            Reference ver1 = new Reference(num + ver_amount*-1);


            if (p == ver_amount )
            {

                list_References.Add(ver1);

            } else if (ver1._chapter == list_References[0]._chapter)
            {

                list_References.Add(ver1);

            }
                        
            
            ver_amount -=1;

        }



    }
    static void Main(string[] args)
    {
        
        var x = 6586;
        List<Reference> list_References = new List<Reference>();

        Random randomGenerator = new Random();
        int num = randomGenerator.Next(1, x);

        int i = randomGenerator.Next(-5, 200);

        int ver_amount = 0;



        Console.WriteLine(i + ver_amount);
        set_list(num,ver_amount,i,list_References);
      
        foreach (Reference Reference in list_References)
        {
            Console.WriteLine(Reference._book);
            Console.WriteLine(Reference._chapter);
            Console.WriteLine(Reference._Reference);

        }




    }
}