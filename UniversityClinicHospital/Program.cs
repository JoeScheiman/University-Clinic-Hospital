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
    public abstract class Employee
    {
        private double Salary { get; set; }
        private double AmountPaid { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        //public abstract double Salary { get; set; }
        private string EmployeeNumber { get; set; }
        private bool Paid { get; set; } = false; //default value = false
        private bool OnPhone { get; set; } = false; //default value = false
        readonly bool DrawsBlood; //default value = false
        readonly Role EmpRole;
        private enum Role
        {
            Doctor,         //0
            Nurse,          //1
            Receptionist,   //2
            Janitor         //3
        }
        public Employee(string firstName, string lastName, string employeeNumber, bool bloodAbility, int role)
        {
            FirstName = firstName;
            LastName = lastName;
            EmployeeNumber = employeeNumber;
            DrawsBlood = bloodAbility;
            EmpRole = (Role)role;

        }
        public abstract void PayEmployee();
        public void SetSalary(double salary)
        {
            Salary = salary;
        }
        public bool PaidYet()
        {
            return Paid;
        }
        public void MakePayment()
        {
            Paid = true;
        }
        public bool GetBloodDrawingStatus()
        {
            return (DrawsBlood);
        }
        public string GetRole()
        {
            switch (EmpRole)
            {
                case Role.Doctor:
                    return "Doctor";
                case Role.Nurse:
                    return "Nurse";
                case Role.Receptionist:
                    return "Receptionist";
                case Role.Janitor:
                    return "Janitor";
                default:
                    return "No_Role_Set";
            }
        }
        public double GetSalary()
        {
            return (Salary);
        }
        public string ToStringAll()
        {

            return (FirstName.PadRight(15) +
                LastName.PadRight(15) +
                EmployeeNumber.PadRight(6) +
                "$" + GetSalary().ToString().PadRight(8) +
                GetRole().PadRight(14) +
                GetBloodDrawingStatus().ToString());
        }
        public bool IsMedicalEmployee()
        {
            if ((int)EmpRole < 2)
                return (true);
            else
                return (false);
        }
    }
    public class Doctor:Employee
    {
        private const double ActualSalary = 90000.00;
        private const string Type = "Doctor";
        private const bool Blood = true;
        private string Specialty { get; set; } = "Not_Set";
        public Doctor(string firstName, string lastName, string employeeNumber):base (firstName, lastName, employeeNumber, Blood, 0)
        {
            SetSalary(ActualSalary);         
        }
        public override void PayEmployee()
        {
            if (PaidYet())
            {
                Console.WriteLine(Type + " was already PAID $" + ActualSalary + "!");

            }
            else
            {
                MakePayment();
                Console.WriteLine(Type + " just got PAID $" + ActualSalary + "!");
            }
        }
        public void SetSpecialty(string specialty)
        {
            Specialty = specialty;
        }
        public string GetSpecialty()
        {
            return (Specialty);
        }


    }
    public class Nurse : Employee
    {
        private const double ActualSalary = 50000.00;
        private const string Type = "Nurse";
        private const bool Blood = true;
        private bool TalkingOnPhone { get; set; }
        public Nurse(string firstName, string lastName, string employeeNumber) : base(firstName, lastName, employeeNumber, Blood,1)
        {
            SetSalary(ActualSalary);
        }
        public override void PayEmployee()
        {
            if (PaidYet())
            {
                Console.WriteLine(Type + " was already PAID $" + ActualSalary + "!");

            }
            else
            {
                MakePayment();
                Console.WriteLine(Type + " just got PAID $" + ActualSalary + "!");
            }
        }

    }
    public class Receptionist : Employee
    {
        private const double ActualSalary = 45000.00;
        private const string Type = "Receptionist";
        private const bool Blood = false;
        private bool TalkingOnPhone { get; set; } = false;
        public Receptionist(string firstName, string lastName, string employeeNumber) : base(firstName, lastName, employeeNumber, Blood, 2)
        {
            SetSalary(ActualSalary);
        }
        public override void PayEmployee()
        {
            if (PaidYet())
            {
                Console.WriteLine(Type + " was already PAID $" + ActualSalary + "!");

            }
            else
            {
                MakePayment();
                Console.WriteLine(Type + " just got PAID $" + ActualSalary + "!");
            }
        }
        public void MakeCall()
        {
            TalkingOnPhone = true;
        }
        public void EndCall()
        {
            TalkingOnPhone = false;
        }
        public bool IsOnPhone()
        {
            return (TalkingOnPhone);
        }
    }
    public class Janitor : Employee
    {
        private const double ActualSalary = 40000.00;
        private const string Type = "Janitor";
        private const bool Blood = false;
        private bool Sweeping { get; set; } = false;
        public Janitor(string firstName, string lastName, string employeeNumber) : base(firstName, lastName, employeeNumber, Blood, 3)
        {
            SetSalary(ActualSalary);
        }
        public override void PayEmployee()
        {
            if (PaidYet())
            {
                Console.WriteLine(Type + " was already PAID $" + ActualSalary + "!");

            }
            else
            {
                MakePayment();
                Console.WriteLine(Type + " just got PAID $" + ActualSalary + "!");
            }
        }
        public void StartSweeping()
        {
            Sweeping = true;
        }
        public void StopSweeping()
        {
            Sweeping = false;
        }
        public bool IsSweeping()
        {
            return (Sweeping);
        }
    }
    public class Patient
    {
        private int BLOOD_LEVEL { get; set; } = 20;
        private int HEALTH_LEVEL { get; set; } = 10;
        private string Name { get; set; }
        private const int DocBloodAmount = 5;
        private const int NurBloodAmount = 3;
        private const int DocHealthAmount = 2;
        private const int NurHealthAmount = 1;
        public Patient(string name)
        {
            Name = name;
        }
        public int BloodRemaining()
        {
            return (BLOOD_LEVEL);
        }
        public string GetName()
        {
            return (Name);
        }
        public void GiveBlood(Employee bloodTaker)
        {
            if (bloodTaker.IsMedicalEmployee())
            {
                if ( bloodTaker.GetRole().Equals("Doctor"))
                {
                    BLOOD_LEVEL -= DocBloodAmount;
                    HEALTH_LEVEL -= DocHealthAmount;
                    Console.WriteLine("Doctor draws " + DocBloodAmount + " units of blood.");
                }
                else if (bloodTaker.GetRole().Equals("Nurse"))
                {
                    BLOOD_LEVEL -= NurBloodAmount;
                    HEALTH_LEVEL -= NurHealthAmount;
                    Console.WriteLine("Nurse draws " + NurBloodAmount + " units of blood.");
                }
                else
                {
                    Console.WriteLine("No Blood Taken!");
                }
            }
            else
                Console.WriteLine("No Blood Taken!");
        }
        public void InfuseBlood(Employee bloodGiver)
        {
            if (bloodGiver.IsMedicalEmployee())
            {
                if (bloodGiver.GetRole().Equals("Doctor"))
                {
                    BLOOD_LEVEL += DocBloodAmount;
                    HEALTH_LEVEL += DocHealthAmount;
                    Console.WriteLine("Doctor infuses " + DocBloodAmount + " units of blood.");
                }
                else if (bloodGiver.GetRole().Equals("Nurse"))
                {
                    BLOOD_LEVEL += NurBloodAmount;
                    HEALTH_LEVEL += NurHealthAmount;
                    Console.WriteLine("Nurse infuses " + NurBloodAmount + " units of blood.");
                }
                else
                {
                    Console.WriteLine("No Blood Infused!");
                }
            }
            else
                Console.WriteLine("No Blood Infused!");
        }
        public string ToStringAll()
        {
            return (Name.PadRight(10) + HEALTH_LEVEL.ToString().PadRight(13) +
                BLOOD_LEVEL.ToString().PadRight(13));
        }
    }
}
