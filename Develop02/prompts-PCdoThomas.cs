class Prompts
{
    public string[] _promptStrings =
    {
     "hello!",
     "what have you done",
     "why is c# like this today"

    };

    public int ProcessPrompts()
    {
         int userResponse = 0;

        do
        {
             Console.Clear();
        foreach(string line in _promptStrings)
        {
            Console.WriteLine(line);
        }
        userResponse = int.Parse(Console.ReadLine());
        }while(userResponse <1 || userResponse > 5);
       
        return userResponse;
    }
}