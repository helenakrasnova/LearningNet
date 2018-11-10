using System;
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
}
