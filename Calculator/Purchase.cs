using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Purchase
    {
        public List <Product> ProductsList = new List <Product> ();
        public float finalAmmount;
        public Purchase()
        {
            finalAmmount = 0;
        }

        public float ShowProduct()
        {
            int i = 0;
            foreach (Product pro in ProductsList)
            {
                Console.WriteLine(ProductsList[i]);
            }
            
            return 0;
        }

        public float UpdateDiscount()
        {
            float discount;

            return 0;
        }

        public void CalculateFAmmount()
        {
            /*foreach (Product p in ProductsList)
            {
                if ()
                {

                }

            }*/

        }

    }

}
