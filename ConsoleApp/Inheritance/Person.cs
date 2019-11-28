using System;

namespace Inheritance
{
    public enum Gender
    {
        Male,
        Female,
    }

    public class Person
    {
        public Person(string name, Gender gender, DateTime birthday)
        {
            this.Name = name;
            this.Gender = gender;
            this.Birthday = birthday;
        }
        public string Name
        {
            get;
            private set;
        }

        public Gender Gender
        {
            get;
            private set;
        }

        public DateTime Birthday
        {
            get;
            private set;
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.Birthday.Year;
            }
        }

        public string GenderPronoun
        {
            get{
                if(this.Gender == Gender.Female) {
                    return "She";
                } else {
                    return "He";
                }
            }
        }
    }
}