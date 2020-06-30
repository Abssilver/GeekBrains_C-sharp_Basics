using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains_CSharpBasics_Ln8_Tsk5.Model
{
    public class StudentData
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Univercity { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public byte Course { get; set; }
        public int Group { get; set; }
        public string City { get; set; }
        public StudentData(string firstName, string secondName, string univercity,
            string faculty, string department, int age, byte course, int group, string city)
        {
            FirstName = firstName;
            SecondName = secondName;
            Univercity = univercity;
            Faculty = faculty;
            Department = department;
            Age = age;
            Course = course;
            Group = group;
            City = city;
        }
        public StudentData() { }
    }
}
