namespace Assignment6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityEvent eventSystem = new UniversityEvent();

            
            eventSystem.RegisterStudent("C# Programming", 101);
            eventSystem.RegisterStudent("C# Programming", 102);
            eventSystem.RegisterStudent("C# Programming", 101);  
            eventSystem.RegisterStudent("Web Development", 103);
            eventSystem.RegisterStudent("Web Development", 104);

            
            eventSystem.PrintRegisteredStudents("C# Programming");
            eventSystem.PrintRegisteredStudents("Web Development");
        }
    }
}
