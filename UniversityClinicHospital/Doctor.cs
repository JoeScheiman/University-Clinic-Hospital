using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityClinicHospital
{
    public class Doctor : Employee
    {
        private const double ActualSalary = 90000.00;
        private const string Type = "Doctor";
        private const bool Blood = true;
        private string Specialty { get; set; } = "Not_Set";
        public Doctor(string firstName, string lastName, string employeeNumber) : base(firstName, lastName, employeeNumber, Blood, 0)
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
}
