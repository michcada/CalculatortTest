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
       

        //metodo para agregar productos a la lista
        public void Add(Product item)
        {
            ProductsList.Add(item);
        }

        //metodo para calcular el descuento
        public double getDiscount(int defaultDiscount,int lowerDiscountLimit, int upperDiscountLimit,int productCountLimitToHigherDiscount, int higherDiscount, int productCountLimitToGeneralDiscount,int generalDiscount)
        {
            double discount = 0;
            foreach (Product item in ProductsList)
            {
                if (item.discountPercent == 0)
                {
                   
                        if (ProductsList.Count <= productCountLimitToHigherDiscount)
                        {
                            item.discountPercent = defaultDiscount;
                        }
                        else
                        {
                            item.discountPercent = higherDiscount;
                        }
                    
                    discount += item.getDiscount();
                }
                else {
                    if (item.discountPercent <= upperDiscountLimit && item.discountPercent >= lowerDiscountLimit)
                    {
                        discount += item.getDiscount();
                    }
                }
                
            }
            if(ProductsList.Count > productCountLimitToGeneralDiscount)
            {
                double extraDiscount =  FinalAmmount() * generalDiscount/100;
                discount+= extraDiscount;

            }
            return discount;
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
