using System;
using System.Buffers;

class Program
{

    public static void Display_menu()
    {
        Console.Clear();
        Console.WriteLine("\n=== Goal Manager ===");
        Console.WriteLine("1. Create Goal");
        Console.WriteLine("2. Record Event");
        Console.WriteLine("3. Show Goals");
        Console.WriteLine("4. Show Score");
        Console.WriteLine("5. Save");
        Console.WriteLine("6. Load");
        Console.WriteLine("7. Quit");


    }

    static void CreateGoal(GoalTracker manager)
    {
        Console.Clear();
        Console.WriteLine("Insert goal type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");

        string type = Console.ReadLine();

        Console.Write("Name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Describe the goal: ");
        string desc = Console.ReadLine();

        Console.Write("How many points is this worth?: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleQuest(name, desc, points));
            break;

            case "2":
                manager.AddGoal(new EternalQuest(name, desc, points));
            break;

            default:
                Console.WriteLine("Invalid type.");
            break;
        }
        
    }

    public static void RecordEvent(GoalTracker g)
    {
        var goals = g.Get_Goals();

        if (goals.Count > 0)
        {
            for (int i = 0; i < goals.Count; i++)
            {
                        var data = goals[i].GetData();
                        var brok_data = data.Split("|");


                    Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {brok_data[2]}");
            }

            Console.Write("Which one?: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }

                int index = choice - 1;

                if (index < 0 || index >= goals.Count)
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }
            
            var daa = goals[index].GetData();

            var bro_data = daa.Split("|");

            if (bro_data[0] == "SimpleQuest"){

                switch (bro_data[1])
                {
                    case "[ ]":
                    g.RecordEvent(index);
                    Console.WriteLine($"You earned {bro_data[4]} points!");
                    Console.WriteLine($"Total Score: {g.Score}");
                    break;
                    case "[X]":
                    Console.WriteLine($"Goal has already been met!");
                    Console.WriteLine($"Total Score: {g.Score}");
                    break;

                }
            }
            else
            {
                
                g.RecordEvent(index);
                Console.WriteLine($"You earned {bro_data[4]} points!");
                Console.WriteLine($"Total Score: {g.Score}");


            }

        




            Thread.Sleep(5000);

            
            




        }


    }

    public static void Save(GoalTracker g)=> g.Save("file");

    public static void Load(GoalTracker g) => g.Load("file");


    











    static void Main()
    {
        GoalTracker manager = new GoalTracker();
        bool running = true;

        Load(manager);

        while (running)
        {
            Display_menu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal(manager);
                    Save(manager);
                    break;

                case "2":
                    RecordEvent(manager);
                    Save(manager);
                    break;

                case "3":
                    manager.DisplayGoals();
                    break;

                case "4":
                    Console.WriteLine($"Score: {manager.Score}");
                    Console.WriteLine($"Streak: {manager.Getstreak()} days");
                            Console.WriteLine("Press enter to exit");
                            Console.ReadLine();
                    break;

                case "5":
                    Save(manager);
                    break;

                case "6":
                    Load(manager);
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}