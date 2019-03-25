using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityClinicHospital
{
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
                if (bloodTaker.GetRole().Equals("Doctor"))
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
