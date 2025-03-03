namespace Assignment5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityEvent eventSystem = new UniversityEvent();

            // Register students for workshops
            eventSystem.RegisterStudent("C# Programming", 101);
            eventSystem.RegisterStudent("C# Programming", 102);
            eventSystem.RegisterStudent("C# Programming", 101); // Duplicate registration attempt

            eventSystem.RegisterStudent("Web Development", 103);
            eventSystem.RegisterStudent("Web Development", 104);

            // Print out registered students for each workshop
            eventSystem.PrintRegisteredStudents("C# Programming");
            eventSystem.PrintRegisteredStudents("Web Development");
        }
    }
}
    

