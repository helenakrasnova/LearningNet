using System;

namespace LearningApp
{
    class BasketItem
    {
        private string name;
        public static int counter = 0;
        public static void DisplayCount()
        {
            Console.WriteLine($"counter={counter}");
        }
        public BasketItem()
        {
            counter++;
        }
        public string Name
        {
            get { return name; } 
            set { name = value; }
        }
        public decimal Price { get; set; }
    }
}
