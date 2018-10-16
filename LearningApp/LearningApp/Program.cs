using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Basket basket = new Basket();

            BasketItem panda = new BasketItem();
            panda.Name = "Panda";
            panda.Price = 50;

            var turtle = new BasketItem
            {
                Name = "Turtle",
                Price = 30
            };

            BasketItem ball = new BasketItem();
            ball.Name = "Ball";
            ball.Price = 11.5m;

            basket.AddItem(panda);
            basket.AddItem(panda);
            basket.AddItem(turtle);
            basket.AddItem(ball);
            basket.AddItem(ball);
            basket.AddItem(ball);

            basket.ShowTotalPrice();
            LowDiscount lowDiscount = new LowDiscount();
            
            basket.ApplyDiscount(lowDiscount);
            basket.ShowTotalPrice();

            HighDiscount highDiscount = new HighDiscount();
            basket.ApplyDiscount(highDiscount);
            basket.ShowTotalPrice();
            Console.ReadKey();
        }
    }
    class Basket
    {
        private decimal totalPrice;
        private List<string> basketItems;
        public Basket ()
        {
            totalPrice = 0;
            basketItems = new List<string>();
        }
        public void AddItem(BasketItem item)
        {
            totalPrice = totalPrice + item.Price;
            basketItems.Add(item.Name);
        }
        public void ShowTotalPrice()
        {
            Console.WriteLine($"Total price: {totalPrice}");
        }
        public bool DeleteItem(BasketItem item)
        {
            int foundPosition = -1;
            
            for (int i = 0; i< basketItems.Count; i++)
            {
                if (basketItems[i] == item.Name)
                {
                    foundPosition = i;
                    break;
                }
            }
            if (foundPosition>0)
            {
                basketItems.RemoveAt(foundPosition);
                totalPrice = totalPrice - item.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ApplyDiscount(IDiscount discount)
        {
            totalPrice = totalPrice - discount.GetDiscount();
        }
    }
    class BasketItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    interface IDiscount
    {
        decimal GetDiscount();
    }
    class LowDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 5;
        }
    }
    class HighDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 15;
        }
    }
}
