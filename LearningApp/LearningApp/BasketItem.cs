using System;

namespace LearningApp
{
    class BasketItem
    {
        public static int counter = 0;
        public static void DisplayCount()
        {
            Console.WriteLine($"counter={counter}");
        }
        public BasketItem()
        {
            counter++;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
