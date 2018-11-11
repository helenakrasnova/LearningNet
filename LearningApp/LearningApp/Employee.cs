using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp
{
    class Employee : Person
    {
        public Guid SmartCardNumber { get; private set; }
        public Employee(
            string name,
            DateTime birthday,
            string creditcard,
            int totalproductpurchased)
                : base(name, birthday, creditcard, totalproductpurchased)
        {
            SmartCardNumber = Guid.NewGuid();
        }
        public override void Display()
        {
            Console.WriteLine(
                $"Employee with name {Name}" +
                $" with creditcard {Creditcard}" +
                $" and birthday {Birthday.ToLongDateString()}" +
                $" has purchased {Totalproductpurchased}" +
                $"and special card {SmartCardNumber}");
        }
    }
}
