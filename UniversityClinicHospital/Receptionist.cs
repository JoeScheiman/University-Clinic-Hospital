using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityClinicHospital
{
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
}
