using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Discount
    {
        public double total;
        public int defaultDiscount { get; set; }
        public int lowerDiscountLimit { get; set; }
        public int upperDiscountLimit { get; set; }
        public int productCountLimitToHigherDiscount { get; set; }
        public int higherDiscount { get; set; }
        public int productCountLimitToDefaultDiscount { get; set; }
        public int generalDiscount { get; set; }

    }
}
