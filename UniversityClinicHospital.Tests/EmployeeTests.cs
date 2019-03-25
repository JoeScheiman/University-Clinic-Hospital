using System;
using Xunit;

namespace UniversityClinicHospital.Tests
{
    public class EmployeeTests
    {
        readonly Employee theDoc = new Doctor("Joe", "Scheiman", "0000");
        readonly Employee theNurse = new Nurse("Billy", "Joel", "1111");
        [Fact]
        public void Is_Doctor_Not_Paid_By_Default()
        {
            Employee theEmployee = new Doctor("Joe", "Scheiman", "123456");

            Assert.False(theEmployee.PaidYet());
        }
        [Fact]
        public void Can_Doc_Be_Paid()
        {
            Employee theEmployee = new Doctor("Joe", "Scheiman", "123456");

            theEmployee.PayEmployee();

            Assert.True(theEmployee.PaidYet());
        }
        [Fact]
        public void Get_Doc_Role()
        {
            Assert.Equal("Doctor", theDoc.GetRole());
        }
        [Fact]
        public void Is_Nurse_Paid_By_Default()
        {
            Employee xxx = new Nurse("Joe", "Scheiman", "123456");

            Assert.False(xxx.PaidYet());
        }
        [Fact]
        public void IsReceptionistPaidByDefault()
        {
            Employee theEmployee = new Receptionist("Joe", "Scheiman", "123456");

            Assert.False(theEmployee.PaidYet());
        }
        [Fact]
        public void Is_Nurse_Medical_Employee_()
        {
            Employee theEmployee = new Nurse("Joe", "Scheiman", "123456");

            Assert.True(theEmployee.IsMedicalEmployee());
        }
        [Fact]
        public void Is_Receptionist_Medical_Employee()
        {
            Employee yy = new Receptionist("jj", "bb", "1234");

            Assert.False(yy.IsMedicalEmployee());
        }


    }
}
