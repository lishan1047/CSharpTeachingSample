using System;
namespace OOPSimple
{
    public class Person
    {
        private string _name;
        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }
        private int _age;
        public int Age
        {
            set
            {
                _age = value;
            }
            get
            {
                return _age;
            }
        }
    }
}