using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp
{
    class Client : Person
    {
        public Client(string name, DateTime birthday, string creditcard, int totalproductpurchased)
            : base(name, birthday, creditcard, totalproductpurchased)
        {
        }

        public override void Display()
        {
            Console.WriteLine(
                $"Client with name {Name}" +
                $" with creditcard {Creditcard}" +
                $" and birthday {Birthday.ToLongDateString()}" +
                $" has purchased {Totalproductpurchased}");
        }
    }
}
