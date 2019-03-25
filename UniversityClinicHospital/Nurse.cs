using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityClinicHospital
{
    public class Nurse : Employee
    {
        private const double ActualSalary = 50000.00;
        private const string Type = "Nurse";
        private const bool Blood = true;
        private bool TalkingOnPhone { get; set; }
        public Nurse(string firstName, string lastName, string employeeNumber) : base(firstName, lastName, employeeNumber, Blood, 1)
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
}
