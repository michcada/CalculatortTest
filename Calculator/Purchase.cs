using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    public class Purchase
    {
        public List <Product> ProductsList = new List<Product>();
        public float finalAmmount;
        public Discount discount = new Discount();

        

        //metodo para agregar productos a la lista
        public void Add(Product item)
        {
            ProductsList.Add(item);
        }

        //metodo para calcular el descuento
        public double getDiscount()
        {
            
            foreach (Product item in ProductsList)
            {
                if (item.discountPercent < 0)
                {
                   
                        if (ProductsList.Count <= discount.productCountLimitToHigherDiscount)
                        {
                            item.discountPercent = discount.defaultDiscount;
                        }
                        else
                        {
                            item.discountPercent = discount.higherDiscount;
                        }
                    
                    discount.total += item.getDiscount();
                }
                else {
                    if (item.discountPercent <= discount.upperDiscountLimit && item.discountPercent >= discount.lowerDiscountLimit)
                    {
                        discount.total += item.getDiscount();
                    }
                    else {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                
            }
            if(ProductsList.Count > discount.productCountLimitToDefaultDiscount)
            {
                double extraDiscount =  FinalAmmount() * discount.generalDiscount /100;
                discount.total+= extraDiscount;

            }
            return discount.total;
            ;
        }

        //metodo para calcular el precio final sin descuentos
        public double FinalAmmount()
        {
            //float discount = ApplyDiscount();
            double finalAmmount = 0;
            foreach (Product item in ProductsList)
            {
                finalAmmount += item.price;
            }
            
            return finalAmmount;
        }

    }

}
