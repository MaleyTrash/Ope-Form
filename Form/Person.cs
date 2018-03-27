using System;

namespace Form
{
    class Person
    {
        string name;
        string gender;
        DateTime born;

        public Person(string n, string g, DateTime b)
        {
            name = n;
            gender = g;
            born = b;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Gender: {1} Birth: {2}", name, gender, born.ToString("dd.MM.yyyy"));
        }
    }
}
