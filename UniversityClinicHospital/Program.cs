using System;

namespace UniversityClinicHospital
{
    class Program
    {
        enum FormatType
        {
            None,
            BoldFormat,    // Is a format value.
            ItalicsFormat, // Is a format value.
            Hyperlink      // Not a format value.
        }

        static void Main()
        {
            // ... Test enum with switch method.
            FormatType formatValue = (FormatType)2;
            if (IsFormat(formatValue))
            {
                // This is not reached, as None does not return a true value in IsFormat.
                Console.WriteLine("Yep");
            }

            // ... Test another enum with switch.
            formatValue = FormatType.ItalicsFormat;
            if (IsFormat(formatValue))
            {
                // This is printed, as we receive true from IsFormat.
                Console.WriteLine("True");
            }
        }

        /// <summary>
        /// Returns true if the FormatType is Bold or Italics.
        /// </summary>
        static bool IsFormat(FormatType value)
        {
            switch (value)
            {
                case FormatType.BoldFormat:
                case FormatType.ItalicsFormat:
                    {
                        // These 2 values are format values.
                        return true;
                    }
                default:
                    {
                        // The argument is not a format value.
                        return false;
                    }
            }
        }


        /*static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }*/
    }
    public class Employee
    {
        private string Name {get; set;} 
        private double Salary {get; set;}
        private string EmployeeNumber { get; set; }
        private bool Paid { get; set; } = false;
        public enum Role
        {
            Doctor,
            Nurse,
            Receptionist,
            Janitor
        }

        public void Pay()
        {
            Paid = true;
        }
        public bool PaidYet()
        {
            return Paid;
        }
    }
    public class Patient
    {

    }
}
