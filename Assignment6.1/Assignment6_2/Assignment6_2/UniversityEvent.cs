using System;
namespace Assignment6_2
{
    internal class UniversityEvent
    {
        private HashSet<string> registeredStudents;

        public UniversityEvent()
        {
            registeredStudents = new HashSet<string>();
        }
        public void RegisterStudent(string workshopName, int studentId)
        {

            string uniqueRegistrationKey = $"{workshopName}_{studentId}";
            if (registeredStudents.Add(uniqueRegistrationKey))
            {
                Console.WriteLine($"Student {studentId} successfully registered for {workshopName}.");
            }
            else
            {
                Console.WriteLine($"Student {studentId} is already registered for {workshopName}.");
            }

        }
        public void PrintRegisteredStudents(string workshopName)
        {
            Console.WriteLine($"Students registered for {workshopName}:");


            foreach (var registration in registeredStudents)
            {
                if (registration.StartsWith(workshopName))
                {

                    var studentId = registration.Split('_')[1];
                    Console.WriteLine($"Student ID: {studentId}");
                }
            }



        }
    }
}
