using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

class Program
{

    public class Job
    {
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;
    }

    public class Resume
    {
        
        public string _name;
        public List<Job> job_list = new List<Job>();

    }


    static void Display_stuff1(Job x)
    {
        
        Console.WriteLine( x._jobTitle + " (" + x._company + ") " + x._startYear + " - " + x._endYear);

    }


    static void Display_resume(Resume x)
    {
        Console.WriteLine("Name:" + x._name);
        Console.WriteLine("Jobs:");


        for (int i = 0; i < x.job_list.Count; i++)
        {
            Display_stuff1(x.job_list[i]);
        }

        

    }




    static void Main(string[] args)
    {
        Resume Res = new Resume();
        Res._name = "James jameson";


        Job Job1 = new Job();
        Job1._company = "The company.inc";
        Job1._jobTitle = "Software Engineer";
        Job1._startYear = 2019;
        Job1._endYear = 2022; 

        Res.job_list.Add(Job1);

        Job Job2 = new Job();
        Job2._company = "Business.co";
        Job2._jobTitle = "Intership";
        Job2._startYear = 2017;
        Job2._endYear = 2019; 

        Res.job_list.Add(Job2);

        Display_resume(Res);

    }
}