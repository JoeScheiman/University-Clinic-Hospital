using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityClinicHospital
{
    public abstract class Employee
    {
        private double Salary { get; set; }
        private double AmountPaid { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
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
}
