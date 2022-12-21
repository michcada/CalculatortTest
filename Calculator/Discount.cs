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
        public int DefaultDiscount { get; set; }
        public int LowerDiscountLimit { get; set; }
        public int UpperDiscountLimit { get; set; }
        public int ProductCountLimitToHigherDiscount { get; set; }
        public int HigherDiscount { get; set; }
        public int ProductCountLimitToDefaultDiscount { get; set; }
        public int GeneralDiscount { get; set; }
    }
}
