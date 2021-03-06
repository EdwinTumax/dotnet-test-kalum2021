using System;

namespace Kalum2021.Models
{
    public class Student : Person
    {
        private string _studentId;
        public Student()
        {

        }

        public Student(string StudentId, string FirstName, string LastName, string Email, DateTime Birthday, string Gender, string Phone) 
            : base(FirstName,LastName,Email,Birthday,Gender,Phone)
        {
            this.StudentId = StudentId;
        }

        public string StudentId
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId = value;
            }
        }

    }
}