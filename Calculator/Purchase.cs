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

        //metodo para agregar productos a la lista
        public void Add(Product item)
        {
            ProductsList.Add(item);
        }

        //calcular el descuento adicional

        public float UpdateDiscountAdditional()
        {
            float discountAdditional = 0;
            if (ProductsList.Count > 3)
            {
                discountAdditional = 5;
            }

            if (ProductsList.Count > 6)
            {
                discountAdditional = 7;
            }
            
            return discountAdditional;
        }

        //metodo para calcular el descuento total de los productos y el descuento adicional
        public float UpdateDiscount()
        {
            float discountTotal = 0;
            foreach (Product item in ProductsList)
            {
                discountTotal += item.discountPercent;
            }
            discountTotal += UpdateDiscountAdditional();
            return discountTotal;
        }

        //metodo para calcular el precio final
        public float UpdateFinalAmmount()
        {
            float finalAmmount = 0;
            int discountTotal = (int)this.UpdateDiscount();

            foreach (Product item in ProductsList)
            {
                finalAmmount += item.price - (item.price * discountTotal / 100);
            }

            return finalAmmount;
        }

    }

}
