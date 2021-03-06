using System;

namespace Kalum2021.Models
{
    public class Teacher : Person
    {
        private string _employeeId;


        public Teacher()
        {

        }

        public Teacher(string EmployeeId, string FirstName, string LastName, string Email, DateTime Birthday, string Gender, string Phone)
            : base(FirstName,LastName,Email,Birthday,Gender,Phone)
        {
            this.EmployeeId = EmployeeId;
        }

        public string EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        }
    }
}