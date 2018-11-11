using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp
{
    public class MegaSaleDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 20;
        }
    }
}
