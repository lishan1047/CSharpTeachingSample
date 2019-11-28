using System;

namespace Inheritance
{
    public class Staff : Person
    {
        public Staff(string staffNo, string name, Gender gender, DateTime birthday)
            : base(name, gender, birthday)
        {
            this.StaffNo = staffNo;
        }

        public string StaffNo
        {
            get;
            private set;
        }
    }
}