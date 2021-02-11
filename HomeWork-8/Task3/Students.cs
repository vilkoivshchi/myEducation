using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Course { get; set; }
        public byte Age { get; set; }

        public Students() { }

        public Students(string firstname, string lastname, byte course, byte age)
        {
            FirstName = firstname;
            LastName = lastname;
            Course = course;
            Age = age;
        }
        
        public override string ToString()
        {
            // немного склонений
            if (Age % 10 == 1)
            {
                return $"{FirstName} {LastName}, {Course} курс, {Age} год";
            }
            else if (Age % 10 > 1 && Age % 10 <= 4)
            {
                return $"{FirstName} {LastName}, {Course} курс, {Age} года";
            }
            else
            {
                return $"{FirstName} {LastName}, {Course} курс, {Age} лет";
            }
        }
        
    }
}
