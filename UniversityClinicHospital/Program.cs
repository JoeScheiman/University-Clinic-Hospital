using System;

namespace UniversityClinicHospital
{
    class Program
    {
        static void Main(string[] args)
        {




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
        public string PrintAll()
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
            if (!PaidYet())
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
            if (!PaidYet())
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
            if (!PaidYet())
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

    }
}
