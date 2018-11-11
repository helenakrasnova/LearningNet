using System;

namespace LearningApp
{
    public abstract class Person
    {
        public Person(string name, DateTime birthday, string creditcard, int totalproductpurchased)
        {
            Name = name;
            Birthday = birthday;
            Creditcard = creditcard;
            Totalproductpurchased = totalproductpurchased;
        }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Creditcard { get; private set; }
        public int Totalproductpurchased { get; private set; }
        public abstract void Display();
    }
}
