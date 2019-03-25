using System;
using System.Collections.Generic;

namespace UniversityClinicHospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var theEmployees = new List<Employee>();
            theEmployees.Add(new Doctor("Joe", "Scheiman", "0000"));
            theEmployees.Add(new Nurse("Billy", "Bobson", "1111"));
            theEmployees.Add(new Janitor("Janet", "Boolean", "7777"));
            theEmployees.Add(new Receptionist("Sam", "Sunk", "8888"));

            Console.WriteLine("\t==== Employees ====");
            Console.WriteLine("FIRST_NAME".PadRight(15)+"LAST_NAME".PadRight(15)+"EMP#".PadRight(6)+
                "SALARY".PadRight(9)+"ROLE".PadRight(14)+"DRAWS_BLOOD");
            foreach (Employee emp in theEmployees)
            {
                Console.WriteLine(emp.ToStringAll());
            }

            var thePatients = new List<Patient>();
            thePatients.Add(new Patient("Phil"));
            thePatients.Add(new Patient("Ken"));
            thePatients.Add(new Patient("Dom"));
            thePatients.Add(new Patient("Melto"));

            Console.WriteLine("\n\n\t==== Patients ====");
            Console.WriteLine("NAME".PadRight(10) + "BLOOD_LEVEL".PadRight(13) + "HEALTH_LEVEL".PadRight(13));
            foreach (Patient pat in thePatients)
            {
                Console.WriteLine(pat.ToStringAll());
            }

            Console.WriteLine("\n\n ==Payments==");
            for (int i = 0; i < theEmployees.Count; i++)
            {
                Console.WriteLine(theEmployees[i].GetRole() + " tries to get paycheck.");
                theEmployees[i].PayEmployee();
            }
            Console.WriteLine("\n\n");
            for (int i = 0; i < theEmployees.Count; i++)
            {
                Console.WriteLine(theEmployees[i].GetRole() + " tries to get paycheck...again.");
                theEmployees[i].PayEmployee();
            }

            Console.WriteLine("\n\n ==Actions==");
            for (int i = 0; i<theEmployees.Count;i++)
            {
                Console.WriteLine(theEmployees[i].GetRole() + " tries to draw blood from " + thePatients[1].GetName());
                thePatients[1].GiveBlood(theEmployees[i]);
            }
            Console.WriteLine("\n\n\t==== Patients Updated ====");
            Console.WriteLine("NAME".PadRight(10) + "BLOOD_LEVEL".PadRight(13) + "HEALTH_LEVEL".PadRight(13));
            foreach (Patient pat in thePatients)
            {
                Console.WriteLine(pat.ToStringAll());
            }
            Console.WriteLine("\n\n");
            for (int i = 0; i < theEmployees.Count; i++)
            {
                Console.WriteLine(theEmployees[i].GetRole() + " tries to infuse blood to " + thePatients[2].GetName());
                thePatients[2].InfuseBlood(theEmployees[i]);
            }
            Console.WriteLine("\n\n\t==== Patients Updated ====");
            Console.WriteLine("NAME".PadRight(10) + "BLOOD_LEVEL".PadRight(13) + "HEALTH_LEVEL".PadRight(13));
            foreach (Patient pat in thePatients)
            {
                Console.WriteLine(pat.ToStringAll());
            }


            Console.WriteLine("......press any key to continue");
            Console.ReadKey();

        }        
    }    
}
