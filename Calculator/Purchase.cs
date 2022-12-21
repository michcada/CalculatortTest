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
        public Discount discount = new();

        

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
                if (item.discountPercent == 0)
                {
                   
                        if (ProductsList.Count <= discount.ProductCountLimitToHigherDiscount)
                        {
                            item.discountPercent = discount.DefaultDiscount;
                        }
                        else
                        {
                            item.discountPercent = discount.HigherDiscount;
                        }
                    
                    discount.total += item.getDiscount();
                }
                else {
                    if (item.discountPercent <= discount.UpperDiscountLimit && item.discountPercent >= discount.LowerDiscountLimit)
                    {
                        discount.total += item.getDiscount();
                    }
                    else 
                    {
                        throw new Exception($"The discount percentage must be between" +
                            $" {this.discount.LowerDiscountLimit}% and {this.discount.UpperDiscountLimit}%");
                    }
                }
                
            }
            if(ProductsList.Count > discount.ProductCountLimitToDefaultDiscount)
            {
                double extraDiscount =  FinalAmmount() * discount.GeneralDiscount /100;
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
        public void LoadDiscount(Discount discount) 
        {
            this.discount= discount;
        }

    }

}
