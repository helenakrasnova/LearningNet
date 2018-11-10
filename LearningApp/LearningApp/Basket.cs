using System;
using System.Collections.Generic;

namespace LearningApp
{
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
}
