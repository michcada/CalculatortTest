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
        public float totalDiscount;
        public Purchase()
        {
            finalAmmount = 0;
        }

        //metodo para agregar productos a la lista
        public void Add(Product item)
        {
            ProductsList.Add(item);
        }

        //metodo para calcular el descuento
        public float UpdateDiscount()
        {
            float discount = 0;
            foreach (Product item in ProductsList)
            {
                discount += item.discountPercent;
            }
            return discount;
        }

        //metodo para calcular el precio final sin descuentos
        public float UpdateFinalAmmount()
        {
            float discount = UpdateDiscount();
            
            foreach (Product item in ProductsList)
            {
                finalAmmount += item.price - item.ApplyDiscount();
            }
            
           // si la cantidad de productos es mayor a 3, se aplica un descuento adicional del 10%

            if (ProductsList.Count > 3)
            {
                finalAmmount = finalAmmount - (finalAmmount * 10 / 100);

            }

            return finalAmmount;
        }

    }

}
