using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityClinicHospital
{
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
}
